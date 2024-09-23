using System;

namespace Twilio.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public sealed class Preview : Attribute
    {
        public string Value { get; }

        public Preview(string value = "This class/method is under preview and is subject to change. Use with caution.")
        {
            Value = value;
        }
    }
}
