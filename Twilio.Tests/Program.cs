using System;
using System.Reflection;
using NUnitLite;

namespace Twilio.Tests
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            return new AutoRun(typeof(TwilioTest).GetTypeInfo().Assembly).Execute(args);
        }
    }
}