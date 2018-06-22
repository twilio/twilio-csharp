using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using Twilio.Security;

namespace Twilio.Tests.Security
{
    [TestFixture]
    public class RequestValidatorTest
    {
        private readonly string url = "https://mycompany.com/myapp.php?foo=1&bar=2";
        private readonly string body = "{\"property\": \"value\", \"boolean\": true}";
        private readonly string bodySignature = "Ch/3Y02as7ldtcmi3+lBbkFQKyg6gMfPGWMmMvluZiA=";
        private NameValueCollection parameters = new NameValueCollection();
        private RequestValidator validator = new RequestValidator("12345");

        public RequestValidatorTest()
        {
            // Intentionally out of alphabetical order
            parameters.Add("CallSid", "CA1234567890ABCDE");
            parameters.Add("From", "+14158675309");
            parameters.Add("Digits", "1234");
            parameters.Add("To", "+18005551212");
            parameters.Add("Caller", "+14158675309");
        }

        [Test]
        public void TestValidateDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (var k in parameters.AllKeys)
            {
                dict.Add(k, parameters[k]);
            }

            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsTrue(validator.Validate(url, parameters, signature), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateFailsWhenIncorrect()
        {
            const string signature = "NOTRSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsFalse(validator.Validate(url, parameters, signature), "Request should have failed validation but didn't");
        }

        [Test]
        public void TestValidateCollection()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsTrue(validator.Validate(url, parameters, signature), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateBody()
        {
            Assert.IsTrue(validator.ValidateBody(body, bodySignature), "Request body validation failed");
        }

        [Test]
        public void TestValidateWithBody()
        {
            parameters.Add("bodySHA256", bodySignature);

            Assert.IsTrue(validator.Validate(url, parameters, body, "lhN9sMASXtkij921mMLP/O8yo04="), "Request signature or body validation failed");
        }

        [Test]
        public void TestValidateWithBodyWithoutSignature()
        {
            Assert.IsFalse(validator.Validate(url, parameters, body, "RSOYDt4T1cUTdK1PDd93/VVr8B8="), "Request signature or body validation failed");
        }
    }
}
