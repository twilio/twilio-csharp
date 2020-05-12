using NUnit.Framework;
using System;
using Twilio.Http;
using Twilio.Rest;

namespace Twilio.Tests.Http
{
    [TestFixture]
    public class RequestTest
    {
        [Test]
        public void TestNoEdgeOrRegionInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.twilio.com");

            Assert.AreEqual(new Uri("https://api.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.AreEqual(new Uri("https://api.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.AreEqual(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.AreEqual(new Uri("https://api.edge.us1.twilio.com"), request.buildUri());
        }

        [Test]
        public void TestRegionInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.urlRegion.twilio.com");

            Assert.AreEqual(new Uri("https://api.urlRegion.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.AreEqual(new Uri("https://api.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.AreEqual(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.AreEqual(new Uri("https://api.edge.urlRegion.twilio.com"), request.buildUri());
        }

        [Test]
        public void TestRegionAndEdgeInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.urlEdge.urlRegion.twilio.com");

            Assert.AreEqual(new Uri("https://api.urlEdge.urlRegion.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.AreEqual(new Uri("https://api.urlEdge.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.AreEqual(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.AreEqual(new Uri("https://api.edge.urlRegion.twilio.com"), request.buildUri());
        }

        [Test]
        public void TestRegionAndEdgeInConstrcutor()
        {
            var request = new Request(HttpMethod.Get, Domain.Accounts, "/path/to/something.json?foo=12.34", region: "region", edge: "edge");

            Assert.AreEqual(new Uri("https://accounts.edge.region.twilio.com/path/to/something.json?foo=12.34"), request.buildUri());
        }
    }
}
