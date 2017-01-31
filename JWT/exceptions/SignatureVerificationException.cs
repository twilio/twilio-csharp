using System;

namespace JWT.exceptions
{
    public class SignatureVerificationException : Exception
    {
        public SignatureVerificationException(string message)
            : base(message)
        {
        }
    }
}
