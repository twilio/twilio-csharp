using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple;
using NUnit.Framework;


namespace SimpleRestClient.Tests
{
	[TestFixture]
    public class UriBuilderTests
    {
        private const string BASE_URL = "http://example.com";

        [Test]
        public void GET_with_leading_slash()
        {
            var expected = new Uri("http://example.com/resource");

            var request = new RestRequest();
            request.Resource = "/resource";

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void POST_with_leading_slash()
        {
            var expected = new Uri("http://example.com/resource");

            var request = new RestRequest();
            request.Method = "POST";
            request.Resource = "/resource";

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_leading_slash_and_baseurl_trailing_slash()
        {
            var expected = new Uri("http://example.com/resource?foo=bar");

            var request = new RestRequest();
            request.Resource = "/resource";
            request.AddParameter("foo", "bar");

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_wth_trailing_slash_and_query_parameters()
        {
            var expected = new Uri("http://example.com/resource/?foo=bar");

            var request = new RestRequest();
            request.Resource = "/resource/";
            request.AddParameter("foo", "bar");

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void POST_with_leading_slash_and_baseurl_trailing_slash()
        {
            var expected = new Uri("http://example.com/resource");

            var request = new RestRequest();
            request.Resource = "/resource";
            request.Method = "POST";

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_resource_containing_slashes()
        {
            var expected = new Uri("http://example.com/resource/foo");

            var request = new RestRequest();
            request.Resource = "/resource/foo";

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void POST_with_resource_containing_slashes()
        {
            var expected = new Uri("http://example.com/resource/foo");

            var request = new RestRequest();
            request.Resource = "/resource/foo";
            request.Method = "POST";

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_resource_containing_tokens()
        {
            var expected = new Uri("http://example.com/resource/bar");

            var request = new RestRequest();
            request.Resource = "/resource/{foo}";
            request.AddUrlSegment("foo", "bar");

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void POST_with_resource_containing_tokens()
        {
            var expected = new Uri("http://example.com/resource/bar");

            var request = new RestRequest();
            request.Resource = "/resource/{foo}";
            request.Method = "POST";
            request.AddUrlSegment("foo", "bar");

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_empty_request()
        {
            var expected = new Uri("http://example.com/resource");

            var request = new RestRequest();

            var output = Simple.UriBuilder.Build("http://example.com/resource", request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_empty_request_and_bare_hostname()
        {
            var expected = new Uri("http://example.com/");
            
            var request = new RestRequest();
            
            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void POST_with_querystring_containing_tokens()
        {
            var expected = new Uri("http://example.com/resource?foo=bar");

            var request = new RestRequest();
            request.Resource = "resource";
            request.Method = "POST";
            request.AddParameter("foo", "bar", ParameterType.QueryString);

            var output = Simple.UriBuilder.Build(BASE_URL, request);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void GET_with_multiple_instances_of_same_key()
        {
            var expected = new Uri("http://api.linkedin.com/v1/people/~/network/updates?type=STAT&type=PICT&count=50&start=50");
            
            var request = new RestRequest();
            request.Resource = "v1/people/~/network/updates";
            request.AddParameter("type", "STAT");
            request.AddParameter("type", "PICT");
            request.AddParameter("count", "50");
            request.AddParameter("start", "50");
            
            var output = Simple.UriBuilder.Build("http://api.linkedin.com", request);

            Assert.AreEqual(expected, output);
        }
    }
}
