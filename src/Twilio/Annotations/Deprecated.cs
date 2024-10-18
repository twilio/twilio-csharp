using System;

namespace Twilio.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Deprecated : Attribute
    {
        public string Message { get; }

        public Deprecated(string message = "This feature is deprecated")
        {
            Message = message;
        }
    }
}
