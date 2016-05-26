using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Tests.Trunking.V1.Trunk {

    [TestFixture]
    public class IpAccessControlListTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = IpAccessControlListResource.Fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
            
            IpAccessControlListResource.Delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists");
            request.AddPostParam("IpAccessControlListSid", Serialize("ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            var response = IpAccessControlListResource.Create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                IpAccessControlListResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"end\": 0,\"first_page_uri\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists?PageSize=50&Page=0\",\"ip_access_control_lists\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trunk_sid\": \"TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"date_updated\": \"Fri, 17 Jul 2015 21:25:15 +0000\",\"friendly_name\": \"aaaa\",\"sid\": \"ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists/ALaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"last_page_uri\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"total\": 1,\"uri\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists?PageSize=50&Page=0\"}"));
            
            var response = IpAccessControlListResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists?PageSize=50&Page=0\",\"ip_access_control_lists\": [],\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"start\": 0,\"uri\": \"https://trunking.twilio.com/v1/Trunks/TKaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlLists?PageSize=50&Page=0\"}"));
            
            var response = IpAccessControlListResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}