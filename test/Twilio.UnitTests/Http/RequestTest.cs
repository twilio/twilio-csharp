using System;
using Twilio.Http;
using Twilio.Rest;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.UnitTests.Http
{
    public class RequestTest
    {
        [Fact]
        public void TestNoEdgeOrRegionInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.twilio.com");

            Assert.Equal(new Uri("https://api.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.Equal(new Uri("https://api.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.Equal(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.Equal(new Uri("https://api.edge.us1.twilio.com"), request.buildUri());
        }

        [Fact]
        public void TestRegionInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.urlRegion.twilio.com");

            Assert.Equal(new Uri("https://api.urlRegion.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.Equal(new Uri("https://api.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.Equal(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.Equal(new Uri("https://api.edge.urlRegion.twilio.com"), request.buildUri());
        }

        [Fact]
        public void TestRegionAndEdgeInUrl()
        {
            var request = new Request(HttpMethod.Get, "https://api.urlEdge.urlRegion.twilio.com");

            Assert.Equal(new Uri("https://api.urlEdge.urlRegion.twilio.com"), request.buildUri());

            request.Region = "region";
            Assert.Equal(new Uri("https://api.urlEdge.region.twilio.com"), request.buildUri());

            request.Edge = "edge";
            Assert.Equal(new Uri("https://api.edge.region.twilio.com"), request.buildUri());

            request.Region = null;
            Assert.Equal(new Uri("https://api.edge.urlRegion.twilio.com"), request.buildUri());
        }

        [Fact]
        public void TestRegionAndEdgeInConstrcutor()
        {
            var request = new Request(HttpMethod.Get, Domain.Accounts, "/path/to/something.json?foo=12.34", region: "region", edge: "edge");

            Assert.Equal(new Uri("https://accounts.edge.region.twilio.com/path/to/something.json?foo=12.34"), request.buildUri());
        }
    }
}
