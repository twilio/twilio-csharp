using System;

namespace Twilio.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Beta : Attribute
    {
        public string Message { get; }

        public Beta(string message = "This feature is in beta and may change in future versions.")
        {
            Message = message;
        }
    }
}
