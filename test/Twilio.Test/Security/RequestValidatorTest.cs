using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Security;

namespace Twilio.Tests.Security
{
    [TestFixture]
    public class RequestValidatorTest
    {

        [Test]
        public void TestValidate()
        {
            var validator = new RequestValidator("12345");

            const string url = "https://mycompany.com/myapp.php?foo=1&bar=2";
            var parameters = new Dictionary<string, string>
            {
                {"CallSid", "CA1234567890ABCDE"},
                {"Caller", "+14158675309"},
                {"Digits", "1234"},
                {"From", "+14158675309"},
                {"To", "+18005551212"}
            };

            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsTrue(validator.Validate(url, parameters, signature), "Request does not match provided signature");
        }
    }
}
