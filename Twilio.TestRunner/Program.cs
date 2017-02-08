using System;
using System.Reflection;
using NUnitLite;
using Twilio.Tests;

namespace Twilio.TestRunner
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
