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
//   --require-clr2        fail unless running on the .NET Framework 2.0-3.5 runtime (CLR 2.0)
//   --app-callback        the app sets its own ServicePointManager callback first, which must still be called
//   --other-request       afterwards, the app's own HttpWebRequest to api.twilio.com must connect, distrusted or not
//   --legacy-policy       the app sets an accept-all CertificatePolicy first; afterwards, its own request to a
//                         self-signed site must still pass it
//   --late-legacy-policy  the same, but the app sets the policy after the SDK's first request
//   --repeat              list messages twice, and require the expected outcome both times
// Exits 0 when the outcome is the expected one, 1 otherwise.
static class Program
{
    private const string DigiCertG2Intermediate = "59e738e674221702af1edb87c5200c1a4b75f64fae3d2c3d265124c61bd83c79";

    private static int Main(string[] args)
    {
        var distrustDigiCert = args.Contains("--distrust-digicert");
        var expectRefused = distrustDigiCert;
#if NET35
        var sdkBuild = "net35";
#else
        var sdkBuild = typeof(TwilioClient).Assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
#endif
        var hasRequestCallback = typeof(HttpWebRequest).GetProperty("ServerCertificateValidationCallback") != null;
        Console.WriteLine($"runtime {Environment.Version}, SDK build {sdkBuild}, " +
            $"HttpWebRequest.ServerCertificateValidationCallback {(hasRequestCallback ? "present" : "missing")}, " +
            $"expect {(expectRefused ? "REFUSED" : "CONNECTED")}");
        if (args.Contains("--require-clr2") && Environment.Version.Major != 2)
        {
            Console.WriteLine("FAIL: not running on CLR 2.0");
            return 1;
        }

#if NETFRAMEWORK
        // Apps targeting .NET Framework 4.5.x don't enable TLS 1.2 by default, and api.twilio.com requires it.
        ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072;
#endif
        var appCallbackCalls = 0;
        if (args.Contains("--app-callback"))
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
            {
                appCallbackCalls++;
                var request = sender as HttpWebRequest;
                Console.WriteLine($"app callback: {request?.RequestUri.Host}, group '{request?.ConnectionGroupName}', {errors}");
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
        }
        if (args.Contains("--legacy-policy"))
        {
#if NETFRAMEWORK
#pragma warning disable 618
            ServicePointManager.CertificatePolicy = new AcceptAllPolicy();
#pragma warning restore 618
#else
            Console.WriteLine("FAIL: --legacy-policy is for .NET Framework only");
            return 1;
#endif
        }
        if (distrustDigiCert)
        {
            var field = typeof(DistrustedIntermediates).GetField("DistrustedSpkiSha256",
                BindingFlags.NonPublic | BindingFlags.Static);
            ((ICollection<string>)field.GetValue(null)).Add(DigiCertG2Intermediate);
        }

        var refused = ListMessages();
        var passed = refused == expectRefused;
        if (args.Contains("--repeat"))
        {
            passed &= ListMessages() == expectRefused;
        }
        if (args.Contains("--late-legacy-policy"))
        {
#if NETFRAMEWORK
#pragma warning disable 618
            ServicePointManager.CertificatePolicy = new AcceptAllPolicy();
#pragma warning restore 618
#endif
        }
        if (args.Contains("--app-callback"))
        {
            Console.WriteLine($"app callback called {appCallbackCalls} times");
            passed &= appCallbackCalls > 0;
        }
        if (args.Contains("--other-request"))
        {
            passed &= AppRequestConnects("https://api.twilio.com/2010-04-01.json");
        }
        if (args.Contains("--legacy-policy") || args.Contains("--late-legacy-policy"))
        {
            passed &= AppRequestConnects("https://self-signed.badssl.com/");
        }
        Console.WriteLine(passed ? "PASS" : "FAIL");
        return passed ? 0 : 1;
    }

    // The app's own request, outside the SDK. Any HTTP response means the TLS connection succeeded.
    private static bool AppRequestConnects(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            using (request.GetResponse())
            {
            }
        }
        catch (WebException e) when (e.Response != null)
        {
            e.Response.Close();
        }
        catch (WebException e)
        {
            Console.WriteLine($"app request to {url} FAILED: {e.Message}");
            return false;
        }
        Console.WriteLine($"app request to {url} CONNECTED");
        return true;
    }

#if NETFRAMEWORK
#pragma warning disable 618
    private sealed class AcceptAllPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            WebRequest request, int certificateProblem)
        {
            return true;
        }
    }
#pragma warning restore 618
#endif

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
            Console.WriteLine("ERROR: " + string.Join(" -> ", messages.ToArray()));
            // Only a certificate failure counts as refused; any other error (DNS, timeout) fails both modes.
            return Regex.IsMatch(string.Join(" ", messages.ToArray()), "certificate|trust relationship|SSL",
                RegexOptions.IgnoreCase);
        }
    }
}
