using System;

namespace Twilio.Exceptions
{
    public class InvalidInputException : ArgumentException
    {
        public InvalidInputException(string paramName)
            : base($"The parameter '{paramName}' cannot be null or empty.", paramName)
        {
        }
    }
}