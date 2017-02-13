using System;

namespace Twilio.Exceptions
{
    public class ApiException : TwilioException
    {
        public int Code { get; }
        public int Status { get; }
        public string MoreInfo { get; }

        public ApiException(string message) : base(message) {}

        public ApiException(string message, Exception exception) : base(message, exception) {}

        public ApiException(
            int code,
            int status,
            string message,
            string moreInfo,
            Exception exception = null
        ) : base(message, exception)
        {
            Code = code;
            Status = status;
            MoreInfo = moreInfo;
        }
    }
}

