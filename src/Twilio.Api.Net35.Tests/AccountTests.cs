using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;

namespace Twilio.Api.Tests
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
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.GetAccount();

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldGetCurrentAccountAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<RestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAccount(account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldGetSubAccount()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.GetAccount(ACCOUNT_SID);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var accountSidParam = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSidParam);
            Assert.AreEqual(ACCOUNT_SID, accountSidParam.Value);
        }

        [Test]
        public void ShouldGetSubAccountAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<RestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAccount(ACCOUNT_SID, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var accountSidParam = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSidParam);
            Assert.AreEqual(ACCOUNT_SID, accountSidParam.Value);
        }

        [Test]
        public void ShouldListSubAccounts()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AccountResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new AccountResult());
            var client = mockClient.Object;

            client.ListSubAccounts();

            mockClient.Verify(trc => trc.Execute<AccountResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListSubAccountsAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AccountResult>(It.IsAny<RestRequest>(), It.IsAny<Action<AccountResult>>()))
                .Callback<RestRequest, Action<AccountResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListSubAccounts(accounts =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AccountResult>(It.IsAny<RestRequest>(), It.IsAny<Action<AccountResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldCreateSubAccount()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.CreateSubAccount(friendlyName);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }


        [Test]
        public void ShouldCreateSubAccountAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<RestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.CreateSubAccount(friendlyName, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldChangeSubAccountStatus()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;

            client.ChangeSubAccountStatus(ACCOUNT_SID, AccountStatus.Suspended);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var accountSid = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSid);
            Assert.AreEqual(ACCOUNT_SID, accountSid.Value);
            var status = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(status);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), status.Value);
        }

        [Test]
        public void ShouldChangeSubAccountStatusAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<RestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ChangeSubAccountStatus(ACCOUNT_SID, AccountStatus.Suspended, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var accountSid = savedRequest.Parameters.Find(x => x.Name == "AccountSid");
            Assert.IsNotNull(accountSid);
            Assert.AreEqual(ACCOUNT_SID, accountSid.Value);
            var status = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(status);
            Assert.AreEqual(AccountStatus.Suspended.ToString().ToLower(), status.Value);
        }

        [Test]
        public void ShouldUpdateCurrentAccountName()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Account());
            var client = mockClient.Object;
            string name = DateTime.Now.ToLongDateString();

            client.UpdateAccountName(name);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(name, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldUpdateCurrentAccountNameAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()))
                .Callback<RestRequest, Action<Account>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            string name = DateTime.Now.ToLongDateString();

            client.UpdateAccountName(name, account =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Account>(It.IsAny<RestRequest>(), It.IsAny<Action<Account>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(name, friendlyNameParam.Value);
        }
    }
}