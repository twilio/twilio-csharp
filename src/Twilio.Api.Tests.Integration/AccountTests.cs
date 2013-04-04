using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Twilio.Api.Tests.Integration
{
    [TestClass]
    public class AccountTests
    {
        ManualResetEvent manualResetEvent = null;

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void ShouldGetCurrentAccount()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.GetAccount();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(Credentials.AccountSid, result.Sid);
        }

        [TestMethod]
        public void ShouldGetCurrentAccountAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            Account result = null;
            client.GetAccount(account => {
                result = account;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(Credentials.AccountSid, result.Sid);
        }

        [TestMethod]
        public void ShouldGetSubAccount()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var account = client.CreateSubAccount(Utilities.MakeRandomFriendlyName());

            var result = client.GetAccount(account.Sid);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(account.Sid, result.Sid);

            client.ChangeSubAccountStatus(account.Sid, AccountStatus.Closed); //cleanup
        }

        [TestMethod]
        public void ShouldGetSubAccountAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalAccount = client.CreateSubAccount(Utilities.MakeRandomFriendlyName());

            Account result = null;
            client.GetAccount(originalAccount.Sid, account =>
            {
                result = account;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(originalAccount.Sid, result.Sid);

            client.ChangeSubAccountStatus(result.Sid, AccountStatus.Closed); //cleanup
        }

        [TestMethod]
        public void ShouldListSubAccounts()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.ListSubAccounts();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Accounts);
        }

        [TestMethod]
        public void ShouldListSubAccountsAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            AccountResult result = null;
            client.ListSubAccounts(accounts => {
                result = accounts;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Accounts);
        }
        
        [TestMethod]
        public void ShouldCreateSubAccount()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var result = client.CreateSubAccount(Utilities.MakeRandomFriendlyName());

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.ChangeSubAccountStatus(result.Sid, AccountStatus.Closed); //cleanup
        }


        [TestMethod]
        public void ShouldCreateSubAccountAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            Account result = null;
            client.CreateSubAccount(Utilities.MakeRandomFriendlyName(), account => 
            {
                result = account;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.IsNotNull(result.Sid);

            client.ChangeSubAccountStatus(result.Sid, AccountStatus.Closed); //cleanup
        }
        
        [TestMethod]
        public void ShouldChangeSubAccountStatus()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var account = client.CreateSubAccount(Utilities.MakeRandomFriendlyName());
            var result = client.ChangeSubAccountStatus(account.Sid, AccountStatus.Suspended);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), result.Status);

            client.ChangeSubAccountStatus(account.Sid, AccountStatus.Closed); //cleanup
        }

        [TestMethod]
        public void ShouldChangeSubAccountStatusAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            var originalAccount = client.CreateSubAccount(Utilities.MakeRandomFriendlyName());
            
            Account result = null;
            client.ChangeSubAccountStatus(originalAccount.Sid, AccountStatus.Suspended, account =>
            {
                result = account;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), result.Status);

            client.ChangeSubAccountStatus(originalAccount.Sid, AccountStatus.Closed); //cleanup
        }

        [TestMethod]
        public void ShouldUpdateCurrentAccountName()
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            string name = DateTime.Now.ToLongDateString();
            var result = client.UpdateAccountName(name);

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(name, result.FriendlyName);
        }

        [TestMethod]
        public void ShouldUpdateCurrentAccountNameAsynchronously()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            string name = DateTime.Now.ToLongDateString();
            Account result = null;
            client.UpdateAccountName(name, account => {
                result = account;
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();

            Assert.IsNotNull(result);
            Assert.IsNull(result.RestException);
            Assert.AreEqual(name, result.FriendlyName);
        }
    }
}
