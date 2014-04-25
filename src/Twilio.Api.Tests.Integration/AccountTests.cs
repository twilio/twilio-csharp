using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class AccountTests
    {
        private const string ACCOUNT_SID = "AC123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetCurrentAccount()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.GetAccount();

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldGetCurrentAccountAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<IRestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAccount(account => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldGetSubAccount()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.GetAccount(ACCOUNT_SID);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var accountSidParam = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSidParam);
            Assert.AreEqual(ACCOUNT_SID, accountSidParam.Value);
        }

        [Test]
        public void ShouldGetSubAccountAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<IRestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAccount(ACCOUNT_SID, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var accountSidParam = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSidParam);
            Assert.AreEqual(ACCOUNT_SID, accountSidParam.Value);
        }

        [Test]
        public void ShouldListSubAccounts()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AccountResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AccountResult());
            var client = mockClient.Object;

            client.ListSubAccounts();

            mockClient.Verify(trc => trc.Execute<AccountResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListSubAccountsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AccountResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AccountResult>>()))
                .Callback<IRestRequest, Action<AccountResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListSubAccounts(accounts => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AccountResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AccountResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }
        
        [Test]
        public void ShouldCreateSubAccount()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.CreateSubAccount(friendlyName);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }


        [Test]
        public void ShouldCreateSubAccountAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<IRestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName ();

            client.CreateSubAccount(friendlyName, account => 
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }
        
        [Test]
        public void ShouldChangeSubAccountStatus()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.ChangeSubAccountStatus(ACCOUNT_SID, AccountStatus.Suspended);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var accountSid = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull (accountSid);
            Assert.AreEqual (ACCOUNT_SID, accountSid.Value);
            var status = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(status);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), status.Value);
        }

        [Test]
        public void ShouldChangeSubAccountStatusAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<IRestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ChangeSubAccountStatus(ACCOUNT_SID, AccountStatus.Suspended, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var accountSid = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull (accountSid);
            Assert.AreEqual (ACCOUNT_SID, accountSid.Value);
            var status = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(status);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), status.Value);
        }

        [Test]
        public void ShouldUpdateCurrentAccountName()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;
            string name = DateTime.Now.ToLongDateString();

            client.UpdateAccountName(name);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(name, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldUpdateCurrentAccountNameAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<IRestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            string name = DateTime.Now.ToLongDateString();

            client.UpdateAccountName(name, account => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<IRestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(name, friendlyNameParam.Value);
        }
    }
}
