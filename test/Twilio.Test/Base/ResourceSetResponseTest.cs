using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using Twilio.Base;

#if !NET35
using System.Net.Http;
#endif

namespace Twilio.Tests.Base
{
    [TestFixture]
    public class ResourceSetResponseTest
    {
        // Mock resource class for testing
        private class MockResource : Resource
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        // Mock ReadOptions for testing
        private class MockReadOptions : ReadOptions<MockResource>
        {
        }

#if !NET35
        private ResourceSet<MockResource> CreateMockResourceSet(List<MockResource> records)
        {
            // Create a JSON string that Page<T>.FromJson can parse
            var json = CreatePageJson(records);
            var page = Page<MockResource>.FromJson("records", json);
            var options = new MockReadOptions();
            return new ResourceSet<MockResource>(page, options, null);
        }

        private string CreatePageJson(List<MockResource> records)
        {
            var recordsJson = string.Join(",", records.Select(r =>
                $"{{\"Id\":\"{r.Id}\",\"Name\":\"{r.Name}\"}}"));
            return $"{{\"records\":[{recordsJson}],\"page_size\":{records.Count},\"uri\":\"/test\"}}";
        }

        [Test]
        public void TestResourceSetResponseProperties()
        {
            var records = new List<MockResource>
            {
                new MockResource { Id = "1", Name = "First" },
                new MockResource { Id = "2", Name = "Second" }
            };
            var resourceSet = CreateMockResourceSet(records);
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new ResourceSetResponse<MockResource>(resourceSet, headers, statusCode);

            Assert.AreEqual(resourceSet, response.Records);
            Assert.AreEqual(headers, response.Headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void TestResourceSetResponseEnumeration()
        {
            var records = new List<MockResource>
            {
                new MockResource { Id = "1", Name = "First" },
                new MockResource { Id = "2", Name = "Second" },
                new MockResource { Id = "3", Name = "Third" }
            };
            var resourceSet = CreateMockResourceSet(records);
            resourceSet.AutoPaging = false;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new ResourceSetResponse<MockResource>(resourceSet, headers, statusCode);

            // Test enumeration through the response
            var enumeratedRecords = response.ToList();
            Assert.AreEqual(3, enumeratedRecords.Count);
            Assert.AreEqual("1", enumeratedRecords[0].Id);
            Assert.AreEqual("2", enumeratedRecords[1].Id);
            Assert.AreEqual("3", enumeratedRecords[2].Id);
        }

        [Test]
        public void TestResourceSetResponseWithEmptySet()
        {
            var records = new List<MockResource>();
            var resourceSet = CreateMockResourceSet(records);
            resourceSet.AutoPaging = false;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new ResourceSetResponse<MockResource>(resourceSet, headers, statusCode);

            var enumeratedRecords = response.ToList();
            Assert.AreEqual(0, enumeratedRecords.Count);
        }

        [Test]
        public void TestResourceSetResponseWithDifferentStatusCodes()
        {
            var records = new List<MockResource>
            {
                new MockResource { Id = "1", Name = "Test" }
            };
            var resourceSet = CreateMockResourceSet(records);
            var headers = new HttpResponseMessage().Headers;

            var okResponse = new ResourceSetResponse<MockResource>(resourceSet, headers, HttpStatusCode.OK);
            Assert.AreEqual(HttpStatusCode.OK, okResponse.StatusCode);

            var partialResponse = new ResourceSetResponse<MockResource>(resourceSet, headers, HttpStatusCode.PartialContent);
            Assert.AreEqual(HttpStatusCode.PartialContent, partialResponse.StatusCode);
        }

        [Test]
        public void TestResourceSetResponseForeachEnumeration()
        {
            var records = new List<MockResource>
            {
                new MockResource { Id = "A", Name = "Alpha" },
                new MockResource { Id = "B", Name = "Beta" }
            };
            var resourceSet = CreateMockResourceSet(records);
            resourceSet.AutoPaging = false;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new ResourceSetResponse<MockResource>(resourceSet, headers, statusCode);

            // Test foreach enumeration
            var ids = new List<string>();
            foreach (var record in response)
            {
                ids.Add(record.Id);
            }

            Assert.AreEqual(2, ids.Count);
            Assert.Contains("A", ids);
            Assert.Contains("B", ids);
        }

        [Test]
        public void TestResourceSetResponseLinqOperations()
        {
            var records = new List<MockResource>
            {
                new MockResource { Id = "1", Name = "Apple" },
                new MockResource { Id = "2", Name = "Banana" },
                new MockResource { Id = "3", Name = "Cherry" }
            };
            var resourceSet = CreateMockResourceSet(records);
            resourceSet.AutoPaging = false;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new ResourceSetResponse<MockResource>(resourceSet, headers, statusCode);

            // Test LINQ operations
            var firstRecord = response.First();
            Assert.AreEqual("1", firstRecord.Id);

            var count = response.Count();
            Assert.AreEqual(3, count);

            var filtered = response.Where(r => r.Name.StartsWith("B")).ToList();
            Assert.AreEqual(1, filtered.Count);
            Assert.AreEqual("Banana", filtered[0].Name);
        }
#endif
    }
}
