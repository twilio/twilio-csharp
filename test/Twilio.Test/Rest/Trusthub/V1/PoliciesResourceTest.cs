/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Trusthub.V1;

namespace Twilio.Tests.Rest.Trusthub.V1
{

    [TestFixture]
    public class PoliciesTest : TwilioTest
    {
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Trusthub,
                "/v1/Policies",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PoliciesResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"results\": [],\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://trusthub.twilio.com/v1/Policies?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://trusthub.twilio.com/v1/Policies?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"results\"}}"
                                     ));

            var response = PoliciesResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"meta\": {\"page\": 0,\"page_size\": 50,\"first_page_url\": \"https://trusthub.twilio.com/v1/Policies?PageSize=50&Page=0\",\"previous_page_url\": null,\"url\": \"https://trusthub.twilio.com/v1/Policies?PageSize=50&Page=0\",\"next_page_url\": null,\"key\": \"results\"},\"results\": [{\"url\": \"https://trusthub.twilio.com/v1/Policies/RNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"requirements\": {\"end_user\": [{\"url\": \"/EndUserTypes/customer_profile_business_information\",\"fields\": [\"business_type\",\"business_registration_number\",\"business_name\",\"business_registration_identifier\",\"business_identity\",\"business_industry\",\"website_url\",\"business_regions_of_operation\",\"social_media_profile_urls\"],\"type\": \"customer_profile_business_information\",\"name\": \"Business Information\",\"requirement_name\": \"customer_profile_business_information\"},{\"url\": \"/EndUserTypes/authorized_representative_1\",\"fields\": [\"first_name\",\"last_name\",\"email\",\"phone_number\",\"business_title\",\"job_position\"],\"type\": \"authorized_representative_1\",\"name\": \"Authorized Representative 1\",\"requirement_name\": \"authorized_representative_1\"},{\"url\": \"/EndUserTypes/authorized_representative_2\",\"fields\": [\"first_name\",\"last_name\",\"email\",\"phone_number\",\"business_title\",\"job_position\"],\"type\": \"authorized_representative_2\",\"name\": \"Authorized Representative 2\",\"requirement_name\": \"authorized_representative_2\"}],\"supporting_trust_products\": [],\"supporting_document\": [[{\"description\": \"Customer Profile HQ Physical Address\",\"type\": \"document\",\"name\": \"Physical Business Address\",\"accepted_documents\": [{\"url\": \"/SupportingDocumentTypes/customer_profile_address\",\"fields\": [\"address_sids\"],\"type\": \"customer_profile_address\",\"name\": \"Physical Business Address\"}],\"requirement_name\": \"customer_profile_address\"}]],\"supporting_customer_profiles\": []},\"friendly_name\": \"Primary Customer Profile of type Business\",\"sid\": \"RNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"
                                     ));

            var response = PoliciesResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Trusthub,
                "/v1/Policies/RNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                PoliciesResource.Fetch("RNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"url\": \"https://trusthub.twilio.com/v1/Policies/RNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"requirements\": {\"end_user\": [{\"url\": \"/EndUserTypes/customer_profile_business_information\",\"fields\": [\"business_type\",\"business_registration_number\",\"business_name\",\"business_registration_identifier\",\"business_identity\",\"business_industry\",\"website_url\",\"business_regions_of_operation\",\"social_media_profile_urls\"],\"type\": \"customer_profile_business_information\",\"name\": \"Business Information\",\"requirement_name\": \"customer_profile_business_information\"},{\"url\": \"/EndUserTypes/authorized_representative_1\",\"fields\": [\"first_name\",\"last_name\",\"email\",\"phone_number\",\"business_title\",\"job_position\"],\"type\": \"authorized_representative_1\",\"name\": \"Authorized Representative 1\",\"requirement_name\": \"authorized_representative_1\"},{\"url\": \"/EndUserTypes/authorized_representative_2\",\"fields\": [\"first_name\",\"last_name\",\"email\",\"phone_number\",\"business_title\",\"job_position\"],\"type\": \"authorized_representative_2\",\"name\": \"Authorized Representative 2\",\"requirement_name\": \"authorized_representative_2\"}],\"supporting_trust_products\": [],\"supporting_document\": [[{\"description\": \"Customer Profile HQ Physical Address\",\"type\": \"document\",\"name\": \"Physical Business Address\",\"accepted_documents\": [{\"url\": \"/SupportingDocumentTypes/customer_profile_address\",\"fields\": [\"address_sids\"],\"type\": \"customer_profile_address\",\"name\": \"Physical Business Address\"}],\"requirement_name\": \"customer_profile_address\"}]],\"supporting_customer_profiles\": []},\"friendly_name\": \"Primary Customer Profile of type Business\",\"sid\": \"RNaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = PoliciesResource.Fetch("RNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}