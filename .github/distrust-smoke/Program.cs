using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;

// Lists messages through the SDK's default client against api.twilio.com and checks the outcome:
//   (no args)             the connection must succeed (a 401 for dummy credentials counts)
//   --distrust-digicert   the intermediate api.twilio.com sends is added to the SDK's list for this run, so the
//                         connection must be refused
// Exits 0 when the outcome is the expected one, 1 otherwise.
static class Program
{
    private const string DigiCertG2Intermediate = "59e738e674221702af1edb87c5200c1a4b75f64fae3d2c3d265124c61bd83c79";

    private static int Main(string[] args)
    {
        var expectRefused = args.Contains("--distrust-digicert");
        var sdkBuild = typeof(TwilioClient).Assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
        Console.WriteLine($"runtime {Environment.Version}, SDK build {sdkBuild}, expect {(expectRefused ? "REFUSED" : "CONNECTED")}");

#if NETFRAMEWORK
        // Apps targeting .NET Framework 4.5.x don't enable TLS 1.2 by default, and api.twilio.com requires it.
        ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072;
#endif
        if (expectRefused)
        {
            var field = typeof(DistrustedIntermediates).GetField("DistrustedSpkiSha256",
                BindingFlags.NonPublic | BindingFlags.Static);
            ((ICollection<string>)field.GetValue(null)).Add(DigiCertG2Intermediate);
        }

        var refused = ListMessages();
        var passed = refused == expectRefused;
        Console.WriteLine(passed ? "PASS" : "FAIL");
        return passed ? 0 : 1;
    }

    // Returns true when the TLS connection was refused.
    private static bool ListMessages()
    {
        TwilioClient.Init(Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID") ?? "AC00000000000000000000000000000000",
            Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN") ?? "dummy");
        try
        {
            var count = MessageResource.Read(limit: 5).Count();
            Console.WriteLine($"CONNECTED: listed {count} messages");
            return false;
        }
        catch (ApiException e)
        {
            Console.WriteLine($"CONNECTED ({e.Status} from Twilio): {e.Message}");
            return false;
        }
        catch (Exception e)
        {
            var messages = new List<string>();
            for (var inner = e; inner != null; inner = inner.InnerException)
            {
                messages.Add($"{inner.GetType().Name}: {inner.Message}");
            }
            Console.WriteLine("ERROR: " + string.Join(" -> ", messages));
            // Only a certificate failure counts as refused; any other error (DNS, timeout) fails both modes.
            return Regex.IsMatch(string.Join(" ", messages), "certificate|trust relationship|SSL", RegexOptions.IgnoreCase);
        }
    }
}
