using System;
using NUnit.Framework;
using Twilio.Types;

namespace Twilio.Tests.Types
{
    [TestFixture]
    public class StringEnumTest
    {
        public sealed class Enum1 : StringEnum
        {
            private Enum1(string value) : base(value) { }
            public Enum1() { }

            public static readonly Enum1 V1 = new Enum1("v1");
            public static readonly Enum1 V2 = new Enum1("v2");
        }

        public sealed class Enum2 : StringEnum
        {
            private Enum2(string value) : base(value) { }
            public Enum2() { }

            public static readonly Enum2 V1 = new Enum2("v1");
            public static readonly Enum2 V2 = new Enum2("v2");
        }

        [Test]
        public void TestEnumComparison()
        {
            Assert.AreNotEqual(Enum1.V1, Enum1.V2);
            Assert.AreNotEqual(Enum2.V2, Enum1.V2);
            Assert.AreEqual(Enum1.V1, Enum1.V1);
        }

        public class Instance
        {
            public Enum1 E1 { get; set; }
        }

        [Test]
        public void TestInstance()
        {
            var i = new Instance
            {
                E1 = Enum1.V1
            };

            Assert.AreNotEqual(i.E1, Enum2.V1);
            Assert.AreEqual(i.E1, Enum1.V1);
        }
    }
}
