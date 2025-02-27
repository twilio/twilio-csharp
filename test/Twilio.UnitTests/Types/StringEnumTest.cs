using System;

using Twilio.Types;

namespace Twilio.UnitTests.Types
{
    
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

        [Fact]
        public void TestEnumComparison()
        {
            Assert.NotEqual(Enum1.V1, Enum1.V2);
            Assert.False(Enum2.V2 == Enum1.V2);
            Assert.Equal(Enum1.V1, Enum1.V1);
        }

        public class Instance
        {
            public required Enum1 E1 { get; set; }
        }

        [Fact]
        public void TestInstance()
        {
            var i = new Instance
            {
                E1 = Enum1.V1
            };

            Assert.False(i.E1 == Enum2.V1);
            Assert.Equal(i.E1, Enum1.V1);
            Assert.True(i.E1 == Enum1.V1);
        }
    }
}
