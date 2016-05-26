using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Usage;

namespace Twilio.Tests.Api.V2010.Account.Usage {

    [TestFixture]
    public class TriggerTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TriggerResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"callback_method\": \"GET\",\"callback_url\": \"http://cap.com/streetfight\",\"current_value\": \"0\",\"date_created\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"date_fired\": null,\"date_updated\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"friendly_name\": \"raphael-cluster-1441544325.86\",\"recurring\": \"yearly\",\"sid\": \"UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trigger_by\": \"price\",\"trigger_value\": \"50\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_category\": \"totalprice\",\"usage_record_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Category=totalprice\"}"));
            
            var response = TriggerResource.Fetch("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TriggerResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"callback_method\": \"GET\",\"callback_url\": \"http://cap.com/streetfight\",\"current_value\": \"0\",\"date_created\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"date_fired\": null,\"date_updated\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"friendly_name\": \"raphael-cluster-1441544325.86\",\"recurring\": \"yearly\",\"sid\": \"UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trigger_by\": \"price\",\"trigger_value\": \"50\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_category\": \"totalprice\",\"usage_record_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Category=totalprice\"}"));
            
            var response = TriggerResource.Update("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TriggerResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
            
            TriggerResource.Delete("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
                        Request request = new Request(System.Net.Http.HttpMethod.Post,
                                                      Domains.API,
                                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers.json");
                        request.AddPostParam("CallbackUrl", Serialize(new Uri("https://example.com")));
            request.AddPostParam("TriggerValue", Serialize("triggerValue"));
            request.AddPostParam("UsageCategory", Serialize(TriggerResource.UsageCategory.AUTHY_AUTHENTICATIONS));
                        
                        twilioRestClient.Request(request)
                                        .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                              "null"));
            
            try {
                TriggerResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Uri("https://example.com"), "triggerValue", TriggerResource.UsageCategory.AUTHY_AUTHENTICATIONS).Execute(twilioRestClient);
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
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"callback_method\": \"GET\",\"callback_url\": \"http://cap.com/streetfight\",\"current_value\": \"0\",\"date_created\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"date_fired\": null,\"date_updated\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"friendly_name\": \"raphael-cluster-1441544325.86\",\"recurring\": \"yearly\",\"sid\": \"UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trigger_by\": \"price\",\"trigger_value\": \"50\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_category\": \"totalprice\",\"usage_record_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Category=totalprice\"}"));
            
            var response = TriggerResource.Create("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new Uri("https://example.com"), "triggerValue", TriggerResource.UsageCategory.AUTHY_AUTHENTICATIONS).Execute(twilioRestClient);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers.json");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                TriggerResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
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
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers?PageSize=1&Page=626\",\"next_page_uri\": null,\"num_pages\": 627,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 627,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers\",\"usage_triggers\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"callback_method\": \"GET\",\"callback_url\": \"http://cap.com/streetfight\",\"current_value\": \"0\",\"date_created\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"date_fired\": null,\"date_updated\": \"Sun, 06 Sep 2015 12:58:45 +0000\",\"friendly_name\": \"raphael-cluster-1441544325.86\",\"recurring\": \"yearly\",\"sid\": \"UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"trigger_by\": \"price\",\"trigger_value\": \"50\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers/UTaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"usage_category\": \"totalprice\",\"usage_record_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Records?Category=totalprice\"}]}"));
            
            var response = TriggerResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers?PageSize=1&Page=626\",\"next_page_uri\": null,\"num_pages\": 627,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 627,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Usage/Triggers\",\"usage_triggers\": []}"));
            
            var response = TriggerResource.Read("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Execute(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}