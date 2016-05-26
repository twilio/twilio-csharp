using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Tests.Api.V2010.Account.Sip {

    [TestFixture]
    public class IpAccessControlListTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"ip_access_control_lists\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\"}"));
            
            var response = IpAccessControlListResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"ip_access_control_lists\": [],\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"num_pages\": 1,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json?PageSize=50&Page=0\"}"));
            
            var response = IpAccessControlListResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists.json");
            request.AddPostParam("FriendlyName", Serialize("friendlyName"));
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = IpAccessControlListResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = IpAccessControlListResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            request.AddPostParam("FriendlyName", Serialize("friendlyName"));
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestUpdateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"ip_addresses\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAddresses.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = IpAccessControlListResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "friendlyName").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException e) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.NoContent,
                                                  "null"));
            
            IpAccessControlListResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    }
}