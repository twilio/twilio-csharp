using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;
using Twilio.Monitor.Model;

namespace Twilio.Monitor.Tests
{
    [TestFixture]
    public class AlertTests
    {
        private const string ALERT_SID = "AE123";

        ManualResetEvent manualResetEvent = null;

        private Mock<MonitorClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<MonitorClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetAlert()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Alert>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Alert());
            var client = mockClient.Object;

            client.GetAlert(ALERT_SID);

            mockClient.Verify(trc => trc.Execute<Alert>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts/{AlertSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var alertSidParam = savedRequest.Parameters.Find(x => x.Name == "AlertSid");
            Assert.IsNotNull(alertSidParam);
            Assert.AreEqual(ALERT_SID, alertSidParam.Value);
        }

        [Test]
        public void ShouldGetAlertAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Alert>(It.IsAny<IRestRequest>(), It.IsAny<Action<Alert>>()))
                .Callback<IRestRequest, Action<Alert>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetAlert(ALERT_SID, Alert =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Alert>(It.IsAny<IRestRequest>(), It.IsAny<Action<Alert>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts/{AlertSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var alertSidParam = savedRequest.Parameters.Find(x => x.Name == "AlertSid");
            Assert.IsNotNull(alertSidParam);
            Assert.AreEqual(ALERT_SID, alertSidParam.Value);
        }

        [Test]
        public void ShouldListAlerts()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AlertResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AlertResult());
            var client = mockClient.Object;

            client.ListAlerts();

            mockClient.Verify(trc => trc.Execute<AlertResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAlertsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AlertResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AlertResult>>()))
                .Callback<IRestRequest, Action<AlertResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListAlerts(workers =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AlertResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AlertResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListAlertsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<AlertResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new AlertResult());
            var client = mockClient.Object;
            var date = DateTime.UtcNow;

            client.ListAlerts("error", date, date);

            mockClient.Verify(trc => trc.Execute<AlertResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var startDateNameParam = savedRequest.Parameters.Find(x => x.Name == "StartDate");
            Assert.IsNotNull(startDateNameParam);
            Assert.AreEqual(date.ToString("yyyy-MM-ddTHH:mm:ssK"), startDateNameParam.Value);
            var endDateNameParam = savedRequest.Parameters.Find(x => x.Name == "EndDate");
            Assert.IsNotNull(endDateNameParam);
            Assert.AreEqual(date.ToString("yyyy-MM-ddTHH:mm:ssK"), endDateNameParam.Value);
            var logLevel = savedRequest.Parameters.Find(x => x.Name == "LogLevel");
            Assert.IsNotNull(logLevel);
            Assert.AreEqual("error", logLevel.Value);
        }

        [Test]
        public void ShouldListAlertsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<AlertResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AlertResult>>()))
                .Callback<IRestRequest, Action<AlertResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var date = DateTime.UtcNow;

            client.ListAlerts("error", date, date, alerts =>
            {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<AlertResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<AlertResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Alerts", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var startDateNameParam = savedRequest.Parameters.Find(x => x.Name == "StartDate");
            Assert.IsNotNull(startDateNameParam);
            Assert.AreEqual(date.ToString("yyyy-MM-ddTHH:mm:ssK"), startDateNameParam.Value);
            var endDateNameParam = savedRequest.Parameters.Find(x => x.Name == "EndDate");
            Assert.IsNotNull(endDateNameParam);
            Assert.AreEqual(date.ToString("yyyy-MM-ddTHH:mm:ssK"), endDateNameParam.Value);
            var logLevel = savedRequest.Parameters.Find(x => x.Name == "LogLevel");
            Assert.IsNotNull(logLevel);
            Assert.AreEqual("error", logLevel.Value);
        }
    }
}

