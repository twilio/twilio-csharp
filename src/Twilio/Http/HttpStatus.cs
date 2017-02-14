using System;

namespace Twilio.Http
{
    public class HttpStatus
    {
        public const int OK=200;
        public const int Created=201;
        public const int NoContent=204;
        public const int ServerError=500;
        public const int NotFound=404;

        private int value;

        public HttpStatus() {
        }

        public HttpStatus(int status) {
            value = status;
        }

        public override string ToString() {
            return this.value.ToString();
        }
    }
}

