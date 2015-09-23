using System;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Twilio.Trunking.Tests.Model
{
    [TestFixture]
    public class PhoneNumberTests
    {
        [Test]
        public void testDeserializeResponse()
        {
            var doc = File.ReadAllText(Path.Combine("Resources", "phone_number.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<AssociatedPhoneNumber>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.NotNull(output.DateCreated);
            Assert.AreEqual("867-5309 (Jenny)", output.FriendlyName);
        }
    }
}
