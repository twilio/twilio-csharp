using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest;
using Twilio.Rest.Api.V2010.Account.Sip.Domain;

namespace Twilio.Tests.Rest.Api.V2010.Account.Sip.Domain 
{

    [TestFixture]
    public class RegistrationEndpointTest : TwilioTest 
    {
        [SetUp]
        public void SetUp()
        {
        }
    
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(HttpMethod.GET,
                                      Domains.API,
                                      "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try
            {
                RegistrationEndpointResource.Reader("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "region", "registrant", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException))
                    {
                        throw e;
                    }
            
                    return true;
                });
            }
            catch (ApiException)
            {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": -1,\"first_page_uri\": \"/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?Page=0PageSize=50\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 0,\"previous_page_uri\": null,\"registrations\": [],\"start\": 0,\"uri\": \"/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json\"}"));
            
            var response = RegistrationEndpointResource.Reader("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "region", "registrant", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?Page=0PageSize=50\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"registrations\": [{\"address_of_record\": \"address_of_record\",\"channel_type\": \"channel_type\",\"date_created\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"date_expires\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"display_name\": \"display_name\",\"sip_call_id\": \"sip_call_id\",\"sip_contact\": \"sip_contact\",\"sip_cseq\": 100,\"sip_path\": \"sip_path\",\"sip_via\": \"sip_via\",\"user_agent\": \"user_agent\"}],\"start\": 0,\"uri\": \"/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json\"}"));
            
            var response = RegistrationEndpointResource.Reader("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "region", "registrant", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}