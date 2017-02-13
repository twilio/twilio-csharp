using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Sip.Domain;

namespace Twilio.Tests.Rest.Api.V2010.Account.Sip.Domain 
{

    [TestFixture]
    public class RegistrationEndpointTest : TwilioTest 
    {
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/Region/Registrant.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));
            
            try
            {
                RegistrationEndpointResource.Read("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Region", "Registrant", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"registrations\": [],\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?PageSize=50&Page=0\"}"
                                     ));
            
            var response = RegistrationEndpointResource.Read("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Region", "Registrant", client: twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"registrations\": [{\"address_of_record\": \"sip:tor@test.sip.us1.twilio.com\",\"channel_type\": \"public-sip\",\"date_created\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"date_expires\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:00:00 +0000\",\"display_name\": \"display_name\",\"sip_call_id\": \"sip_call_id\",\"sip_contact\": \"sip_contact\",\"sip_cseq\": 100,\"sip_path\": \"sip_path\",\"sip_via\": \"sip_via\",\"user_agent\": \"user_agent\"}],\"start\": 0,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Registrations/region/registrant.json?PageSize=50&Page=0\"}"
                                     ));
            
            var response = RegistrationEndpointResource.Read("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Region", "Registrant", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}