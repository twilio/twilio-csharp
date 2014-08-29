using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using Simple;
using System.Threading.Tasks;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private const string ACCOUNT_SID = "AC123";

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public async Task ShouldGetCurrentAccount()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Account>();
            tcs.SetResult(new Account());

            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>() ))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            
            var client = mockClient.Object;
            await client.GetAccount();

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public async Task ShouldGetSubAccount()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Account>();
            tcs.SetResult(new Account());
            
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.GetAccount(ACCOUNT_SID);

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
        public async Task ShouldListSubAccounts()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<AccountResult>();
            tcs.SetResult(new AccountResult());

            mockClient.Setup(trc => trc.Execute<AccountResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.ListSubAccounts();

            mockClient.Verify(trc => trc.Execute<AccountResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public async Task ShouldCreateSubAccount()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Account>();
            tcs.SetResult(new Account());
            
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            await client.CreateSubAccount(friendlyName);

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
        public async Task ShouldChangeSubAccountStatus()
        {
            RestRequest savedRequest = null;

            var tcs = new TaskCompletionSource<Account>();
            tcs.SetResult(new Account());
            
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;

            await client.ChangeSubAccountStatus(ACCOUNT_SID, AccountStatus.Suspended);

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
        public async Task ShouldUpdateCurrentAccountName()
        {
            RestRequest savedRequest = null;
            
            var tcs = new TaskCompletionSource<Account>();
            tcs.SetResult(new Account());
            
            mockClient.Setup(trc => trc.Execute<Account>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(tcs.Task);
            var client = mockClient.Object;
            string name = DateTime.Now.ToLongDateString();

            await client.UpdateAccountName(name);

            mockClient.Verify(trc => trc.Execute<Account>(It.IsAny<RestRequest>()), Times.Once);
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