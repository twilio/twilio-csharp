using System;
using System.Reflection;
using NUnitLite;

namespace Twilio.Tests
{
    class Program
    {
        static int Main(string[] args)
        {
#if NET35
            return new AutoRun(typeof(TwilioTest).Assembly).Execute(args);
#else
            return new AutoRun(typeof(TwilioTest).GetTypeInfo().Assembly).Execute(args);
#endif
        }
    }
}