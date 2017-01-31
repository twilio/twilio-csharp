using System;

namespace JWT.exceptions
{
    public class CryptographicException : Exception
    {
        public CryptographicException(string message)
            : base(message)
        {
        }
    }
}
