using System;

namespace Twilio.TaskRouter
{
    public class ReservationRequest
    {
        private string WorkspaceSid; 
        private string TaskSid; 
        private string ReservationSid; 
        private string ReservationStatus;
        private string WorkerActivitySid; 
        private string Instruction;
        private string DequeueFrom;
        private string DequeuePostWorkActivitySid;
        private string CallFrom;
        private string CallUrl;
        private string CallAccept;
        private string CallStatusCallbackUrl;

        public ReservationRequest(string workspaceSid, string taskSid, string reservationSid, string reservationStatus)
        {
            this.WorkspaceSid = workspaceSid;
            this.TaskSid = taskSid;
            this.ReservationSid = reservationSid;
            this.ReservationStatus = reservationStatus;
        }

        public string GetWorkspaceSid()
        {
            return this.WorkspaceSid;
        }

        public string GetTaskSid()
        {
            return this.TaskSid;
        }

        public string GetReservationSid()
        {
            return this.ReservationSid;
        }

        public string GetReservationStatus()
        {
            return this.ReservationStatus;
        }

        public string GetWorkerActivitySid()
        {
            return this.WorkerActivitySid;
        }

        public string GetInstruction()
        {
            return this.Instruction;
        }

        public string GetDequeueFrom()
        {
            return this.DequeueFrom;
        }

        public string GetDequeuePostWorkActivitySid()
        {
            return this.DequeuePostWorkActivitySid;
        }

        public string GetCallFrom()
        {
            return this.CallFrom;
        }

        public string GetCallUrl()
        {
            return this.CallUrl;
        }

        public string GetCallAccept()
        {
            return this.CallAccept;
        }

        public string GetCallStatusCallbackUrl()
        {
            return this.CallStatusCallbackUrl;
        }

        public ReservationRequest WithWorkerActivitySid(string workerActivitySid)
        {
            this.WorkerActivitySid = workerActivitySid;
            return this;
        }

        public ReservationRequest WithInstruction(string instruction)
        {
            this.Instruction = instruction;
            return this;
        }

        public ReservationRequest WithDequeueFrom(string dequeueFrom)
        {
            this.DequeueFrom = dequeueFrom;
            return this;
        }

        public ReservationRequest WithDequeuePostWorkActivitySid(string dequeuePostWorkActivitySid)
        {
            this.DequeuePostWorkActivitySid = dequeuePostWorkActivitySid;
            return this;
        }

        public ReservationRequest WithCallFrom(string callFrom)
        {
            this.CallFrom = callFrom;
            return this;
        }

        public ReservationRequest WithCallUrl(string callUrl)
        {
            this.CallUrl = callUrl;
            return this;
        }

        public ReservationRequest WithCallAccept(string callAccept)
        {
            this.CallAccept = callAccept;
            return this;
        }

        public ReservationRequest WithCallStatusCallbackUrl(string callStatusCallbackUrl)
        {
            this.CallStatusCallbackUrl = callStatusCallbackUrl;
            return this;
        }
    }
}

