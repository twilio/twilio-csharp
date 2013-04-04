using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class AvailablePhoneNumberTests
    {
        ManualResetEvent manualResetEvent = null;
        
        [TestMethod]
        public void ShouldListAvailableLocalPhoneNumbers()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            
            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            var result = client.ListAvailableLocalPhoneNumbers("US",options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableLocalPhoneNumbersWithOptions()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            options.AreaCode = "314";
            options.Contains = "EA"; //contains must be 2 or more characters, unless using * alone
            options.Distance = 50;
            
            var result = client.ListAvailableLocalPhoneNumbers("US", options);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableLocalPhoneNumbersAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();

            AvailablePhoneNumberResult result = null;
            client.ListAvailableLocalPhoneNumbers("US", options, numbers => {
                result = numbers;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableTollFreePhoneNumbers()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            var result = client.ListAvailableTollFreePhoneNumbers("US");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableTollFreePhoneNumbersAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();

            AvailablePhoneNumberResult result = null;
            client.ListAvailableTollFreePhoneNumbers("US", numbers =>
            {
                result = numbers;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableTollFreePhoneNumbersThatContain()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            var result = client.ListAvailableTollFreePhoneNumbers("US", "EA");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

        [TestMethod]
        public void ShouldListAvailableTollFreePhoneNumbersAsynchronouslyThatContain()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AvailablePhoneNumberListRequest options = new AvailablePhoneNumberListRequest();
            AvailablePhoneNumberResult result = null;
            client.ListAvailableTollFreePhoneNumbers("US", "EA", numbers => { 
                result = numbers;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();
            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.AvailablePhoneNumbers);
        }

    }
}
