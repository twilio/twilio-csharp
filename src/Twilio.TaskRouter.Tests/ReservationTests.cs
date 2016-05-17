using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class ReservationTests
    {
        private const string RESERVATION_SID = "WR123";

        private const string TASK_SID = "WT123";

        private const string WORKER_SID = "WK123";

        private const string WORKSPACE_SID = "WS123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TaskRouterClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TaskRouterClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetReservation()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Reservation>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Reservation());
            var client = mockClient.Object;

            client.GetReservation(WORKSPACE_SID, TASK_SID, RESERVATION_SID);

            mockClient.Verify(trc => trc.Execute<Reservation>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationSidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationSid");
            Assert.IsNotNull(reservationSidParam);
            Assert.AreEqual(RESERVATION_SID, reservationSidParam.Value);
        }

        [Test]
        public void ShouldGetReservationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Reservation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Reservation>>()))
                .Callback<IRestRequest, Action<Reservation>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetReservation(WORKSPACE_SID, TASK_SID, RESERVATION_SID, reservation => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Reservation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Reservation>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationSidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationSid");
            Assert.IsNotNull(reservationSidParam);
            Assert.AreEqual(RESERVATION_SID, reservationSidParam.Value);
        }

        [Test]
        public void ShouldListReservations()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ReservationResult());
            var client = mockClient.Object;

            client.ListReservations(WORKSPACE_SID, TASK_SID);

            mockClient.Verify(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldListReservationsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ReservationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ReservationResult>>()))
                .Callback<IRestRequest, Action<ReservationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListReservations(WORKSPACE_SID, TASK_SID, reservations => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ReservationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ReservationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldListReservationsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ReservationResult());
            var client = mockClient.Object;

            client.ListReservations(WORKSPACE_SID, TASK_SID, "reservationStatus", "afterSid", "beforeSid", 10);

            mockClient.Verify(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationStatusParam = savedRequest.Parameters.Find(x => x.Name == "ReservationStatus");
            Assert.IsNotNull(reservationStatusParam);
            Assert.AreEqual("reservationStatus", reservationStatusParam.Value);
            var afterSidParam = savedRequest.Parameters.Find(x => x.Name == "AfterSid");
            Assert.IsNotNull(afterSidParam);
            Assert.AreEqual("afterSid", afterSidParam.Value);
            var beforeSidParam = savedRequest.Parameters.Find(x => x.Name == "BeforeSid");
            Assert.IsNotNull(beforeSidParam);
            Assert.AreEqual("beforeSid", beforeSidParam.Value);
            var countSidParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countSidParam);
            Assert.AreEqual(10, countSidParam.Value);
        }

        [Test]
        public void ShouldListReservationsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ReservationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ReservationResult>>()))
                .Callback<IRestRequest, Action<ReservationResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListReservations(WORKSPACE_SID, TASK_SID, "reservationStatus", "afterSid", "beforeSid", 10, reservations => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ReservationResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ReservationResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationStatusParam = savedRequest.Parameters.Find(x => x.Name == "ReservationStatus");
            Assert.IsNotNull(reservationStatusParam);
            Assert.AreEqual("reservationStatus", reservationStatusParam.Value);
            var afterSidParam = savedRequest.Parameters.Find(x => x.Name == "AfterSid");
            Assert.IsNotNull(afterSidParam);
            Assert.AreEqual("afterSid", afterSidParam.Value);
            var beforeSidParam = savedRequest.Parameters.Find(x => x.Name == "BeforeSid");
            Assert.IsNotNull(beforeSidParam);
            Assert.AreEqual("beforeSid", beforeSidParam.Value);
            var countSidParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countSidParam);
            Assert.AreEqual(10, countSidParam.Value);
        }

        [Test]
        public void ShouldListReservationsForWorker()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ReservationResult());
            var client = mockClient.Object;

            client.ListReservationsForWorker(WORKSPACE_SID, WORKER_SID);

            mockClient.Verify(trc => trc.Execute<ReservationResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Reservations", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
        }

        [Test]
        public void ShouldUpdateReservation()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Reservation>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Reservation());
            var client = mockClient.Object;

            client.UpdateReservation(WORKSPACE_SID, TASK_SID, RESERVATION_SID, "reservationStatus", "WA123");

            mockClient.Verify(trc => trc.Execute<Reservation>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/{Resource}/{ResourceSid}/Reservations/{ReservationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "ResourceSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationSidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationSid");
            Assert.IsNotNull(reservationSidParam);
            Assert.AreEqual(RESERVATION_SID, reservationSidParam.Value);
            var reservationStatusParam = savedRequest.Parameters.Find(x => x.Name == "ReservationStatus");
            Assert.IsNotNull(reservationStatusParam);
            Assert.AreEqual("reservationStatus", reservationStatusParam.Value);
            var workerActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerActivitySid");
            Assert.IsNotNull(workerActivitySidParam);
            Assert.AreEqual("WA123", workerActivitySidParam.Value);
        }

        [Test]
        public void ShouldUpdateReservationAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Reservation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Reservation>>()))
                .Callback<IRestRequest, Action<Reservation>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.UpdateReservation(WORKSPACE_SID, TASK_SID, RESERVATION_SID, "reservationStatus", "WA123", reservation => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Reservation>(It.IsAny<IRestRequest>(), It.IsAny<Action<Reservation>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/{Resource}/{ResourceSid}/Reservations/{ReservationSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "ResourceSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var reservationSidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationSid");
            Assert.IsNotNull(reservationSidParam);
            Assert.AreEqual(RESERVATION_SID, reservationSidParam.Value);
            var reservationStatusParam = savedRequest.Parameters.Find(x => x.Name == "ReservationStatus");
            Assert.IsNotNull(reservationStatusParam);
            Assert.AreEqual("reservationStatus", reservationStatusParam.Value);
            var workerActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerActivitySid");
            Assert.IsNotNull(workerActivitySidParam);
            Assert.AreEqual("WA123", workerActivitySidParam.Value);
        }
    }
}

