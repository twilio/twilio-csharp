using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Twilio.Security;

namespace Twilio.Tests.Security
{
    [TestFixture]
    public class RequestValidatorTest
    {
        private const string Url = "https://mycompany.com/myapp.php?foo=1&bar=2";
        private const string Body = "{\"property\": \"value\", \"boolean\": true}";
        private const string BodyHash = "0a1ff7634d9ab3b95db5c9a2dfe9416e41502b283a80c7cf19632632f96e6620";
        private readonly NameValueCollection _parameters = new NameValueCollection();
        private readonly RequestValidator _validator = new RequestValidator("12345");

        public RequestValidatorTest()
        {
            // Intentionally out of alphabetical order
            _parameters.Add("CallSid", "CA1234567890ABCDE");
            _parameters.Add("From", "+14158675309");
            _parameters.Add("Digits", "1234");
            _parameters.Add("To", "+18005551212");
            _parameters.Add("Caller", "+14158675309");
        }

        [Test]
        public void TestValidateDictionary()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsTrue(_validator.Validate(Url, _parameters, signature), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateDictionaryMixedCase()
        {
            const string signature = "g9IN/x4Cft2g517EjYvEvM/W7LU=";
            const string url = "https://MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), "Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateDictionaryMixedCaseWithPort()
        {
            const string signature = "PCqOZm8cnu/L6+u5i5fuEd+Iac4=";
            const string url = "https://MyCompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), "Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateDictionaryMixedCaseAddsPortHttp()
        {
            const string signature = "XY7AlKOKL6im4yWyX84gldUrtis=";
            const string url = "http://MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), "Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateCredentialsArePreserved()
        {
            const string signature = "PJ08CxXr7KLPjEQCTc8LkUSMwSM=";
            const string url = "http://username:password@MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), $"Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateCredentialsArePreservedUpperCaseScheme()
        {
            const string signature = "hy/l8pca+LFms4cvRdv8uiP6NGc=";
            const string url = "HTTP://username:password@MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), $"Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateCredentialsArePreservedMixedCaseCreds()
        {
            const string signature = "SkTSKyDJH9kUlhItI0slbgZ1UsI=";
            const string url = "http://Username:Password@MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, signature), $"Request should have passed validation but didn't");
        }

        [Test]
        public void TestValidateDictionaryMixedCaseWithIncorrectSignature()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            const string url = "https://MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsFalse(_validator.Validate(url, _parameters, signature), "Request should have failed validation but didn't");
        }

        [Test]
        public void TestValidateDictionaryMixedCaseWithPortWithIncorrectSignature()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            const string url = "https://MyCompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsFalse(_validator.Validate(url, _parameters, signature), "Request should have failed validation but didn't");
        }

        [Test]
        public void TestValidateDictionaryMixedCaseAddsPortHttpWithIncorrectSignature()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            const string url = "http://MyCompany.com/myapp.php?foo=1&bar=2";
            Assert.IsFalse(_validator.Validate(url, _parameters, signature), "Request should have failed validation but didn't");
        }

        [Test]
        public void TestValidateFailsWhenIncorrect()
        {
            const string signature = "NOTRSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsFalse(_validator.Validate(Url, _parameters, signature), "Request should have failed validation but didn't");
        }

        [Test]
        public void TestValidateCollection()
        {
            const string signature = "RSOYDt4T1cUTdK1PDd93/VVr8B8=";
            Assert.IsTrue(_validator.Validate(Url, _parameters, signature), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateBody()
        {
            Assert.IsTrue(RequestValidator.ValidateBody(Body, BodyHash), "Request body validation failed");
        }

        [Test]
        public void TestValidateWithBody()
        {
            const string url = Url + "&bodySHA256=" + BodyHash;
            Assert.IsTrue(_validator.Validate(url, Body, "a9nBmqA0ju/hNViExpshrM61xv4="), "Request signature or body validation failed");
        }

        [Test]
        public void TestValidateWithOnlyHash()
        {
            const string url = "https://mycompany.com/myapp.php?bodySHA256=" + BodyHash;
            Assert.IsTrue(_validator.Validate(url, Body, "y77kIzt2vzLz71DgmJGsen2scGs="), "Request signature or body validation failed");
        }

        [Test]
        public void TestValidateWithBodyWithoutSignature()
        {
            Assert.IsFalse(_validator.Validate(Url, Body, "RSOYDt4T1cUTdK1PDd93/VVr8B8="), "Request signature or body validation failed");
        }

        [Test]
        public void TestValidateRemovesPortHttps()
        {
            const string url = "https://mycompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, "RSOYDt4T1cUTdK1PDd93/VVr8B8="), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateRemovesPortHttp()
        {
            const string url = "http://mycompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, "Zmvh+3yNM1Phv2jhDCwEM3q5ebU="), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateAddsPortHttps()
        {
            Assert.IsTrue(_validator.Validate(Url, _parameters, "kvajT1Ptam85bY51eRf/AJRuM3w="), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateAddsPortHttp()
        {
            const string url = "http://mycompany.com/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, "0ZXoZLH/DfblKGATFgpif+LLRf4="), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateAddsCustomPortHttps()
        {
            const string url = "https://mycompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, "CYn1h0gLBdNxDGkKJg6hYohgeD8="), "Request does not match provided signature");
        }

        [Test]
        public void TestValidateAddsCustomPortHttp()
        {
            const string url = "http://mycompany.com:1234/myapp.php?foo=1&bar=2";
            Assert.IsTrue(_validator.Validate(url, _parameters, "Zmvh+3yNM1Phv2jhDCwEM3q5ebU="), "Request does not match provided signature");
        }

        [Test]
        public void TestIsThreadSafe()
        {
            var validator = new RequestValidator("secret");
            var thread1 = new Thread(Validate);
            var thread2 = new Thread(Validate);

            Assert.DoesNotThrow(() =>
            {
                thread1.Start(validator);
                thread2.Start(validator);
                thread1.Join();
                thread2.Join();
            });
        }

        private static void Validate(object obj)
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < 5000)
            {
                ((RequestValidator)obj).Validate("https://foo.com", "123", "foo");
            }
        }
    }
}
