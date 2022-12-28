using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Twilio.Security;

var summary = BenchmarkRunner.Run<RequestValidationBenchmark>();
Console.Write(summary);

[MemoryDiagnoser]
public class RequestValidationBenchmark
{
    private const string Secret = "12345";
    private const string UnhappyPathUrl = "HTTP://MyCompany.com:8080/myapp.php?foo=1&bar=2";
    private const string UnhappyPathSignature = "eYYN9fMlxrQMXOsr7bIzoPTrbxA=";
    private const string HappyPathUrl = "https://mycompany.com/myapp.php?foo=1&bar=2";
    private const string HappyPathSignature = "3LL3BFKOcn80artVM5inMPFpmtU=";
    private static readonly NameValueCollection UnhappyPathParameters = new()
    {
        {"ToCountry", "US"},
        {"ToState", "OH"},
        {"SmsMessageSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"NumMedia", "0"},
        {"ToCity", "UTICA"},
        {"FromZip", "20705"},
        {"SmsSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"FromState", "DC"},
        {"SmsStatus", "received"},
        {"FromCity", "BELTSVILLE"},
        {"Body", "Ahoy!"},
        {"FromCountry", "US"},
        {"To", "+10123456789"},
        {"ToZip", "43037"},
        {"NumSegments", "1"},
        {"ReferralNumMedia", "0"},
        {"MessageSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"AccountSid", "ACe718619887aac3ee5b21edafbvsdf6h7fgb"},
        {"From", "+10123456789"},
        {"ApiVersion", "2010-04-01"}
    };
    private static readonly Dictionary<string, string> HappyPathParameters = new()
    {
        {"ToCountry", "US"},
        {"ToState", "OH"},
        {"SmsMessageSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"NumMedia", "0"},
        {"ToCity", "UTICA"},
        {"FromZip", "20705"},
        {"SmsSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"FromState", "DC"},
        {"SmsStatus", "received"},
        {"FromCity", "BELTSVILLE"},
        {"Body", "Ahoy!"},
        {"FromCountry", "US"},
        {"To", "+10123456789"},
        {"ToZip", "43037"},
        {"NumSegments", "1"},
        {"ReferralNumMedia", "0"},
        {"MessageSid", "SMcea2a3bd6f50296f8fab60f377db03eb"},
        {"AccountSid", "ACe718619887aac3ee5b21edafbvsdf6h7fgb"},
        {"From", "+10123456789"},
        {"ApiVersion", "2010-04-01"}
    };


    [Benchmark]
    public void OriginalUnhappyPath()
    {
        var requestValidator = new RequestValidatorOriginal(Secret);
        requestValidator.Validate(UnhappyPathUrl, UnhappyPathParameters, UnhappyPathSignature);
    }

    [Benchmark]
    public void CurrentUnhappyPath()
    {
        var requestValidator = new RequestValidator(Secret);
        requestValidator.Validate(UnhappyPathUrl, UnhappyPathParameters, UnhappyPathSignature);
    }

    [Benchmark]
    public void OriginalHappyPath()
    {
        var requestValidator = new RequestValidatorOriginal(Secret);
        requestValidator.Validate(HappyPathUrl, HappyPathParameters, HappyPathSignature);
    }

    [Benchmark]
    public void CurrentHappyPath()
    {
        var requestValidator = new RequestValidator(Secret);
        requestValidator.Validate(HappyPathUrl, HappyPathParameters, HappyPathSignature);
    }
}