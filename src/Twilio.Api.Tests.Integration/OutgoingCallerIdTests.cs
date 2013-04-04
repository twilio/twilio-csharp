using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class OutgoingCallerIdTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestMethod]
        public void ShouldAddNewOutgoingCallerId()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.AddOutgoingCallerId("", "", null, null);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.ValidationCode);
            Assert.Fail();
        }
        
        [TestMethod]
        public void ShouldListOutgoingCallerIds()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListOutgoingCallerIds();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.OutgoingCallerIds);
        }
        
        [TestMethod]
        public void ShouldListOutgoingCallerIdsAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            OutgoingCallerIdResult result = null;
            client.ListOutgoingCallerIds(callerIds =>
            {
                result = callerIds;
                manualResetEvent.Set();
            });
            
            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.OutgoingCallerIds);
        }
        
        [TestMethod]
        public void ShouldListOutgoingCallerIdsUsingFilters()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListOutgoingCallerIds("","",null,null);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.OutgoingCallerIds);
            Assert.Fail();
        }
        
        [TestMethod]
        public void ShouldGetOutgoingCallerId()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalCallerId = client.AddOutgoingCallerId("", "", null, null);

            var result = client.GetOutgoingCallerId("");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);            
            Assert.Fail();
        }
        
        [TestMethod]
        public void ShouldUpdateOutgoingCallerId()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalCallerId = client.AddOutgoingCallerId("", "", null, null);

            var result = client.UpdateOutgoingCallerIdName("", "");

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);            
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldDeleteOutgoingCallerId()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var status = client.DeleteOutgoingCallerId("");
            Assert.AreEqual(DeleteStatus.Success, status);
            Assert.Fail();
        }
    }
}
