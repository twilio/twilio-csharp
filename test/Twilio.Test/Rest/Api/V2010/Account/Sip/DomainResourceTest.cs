using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Sip;

namespace Twilio.Tests.Rest.Api.V2010.Account.Sip 
{

    [TestFixture]
    public class DomainTest : TwilioTest 
    {
        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                DomainResource.Read(client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadFullResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"domains\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"\",\"date_created\": \"Fri, 06 Sep 2013 18:48:50 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 18:48:50 -0000\",\"domain_name\": \"dunder-mifflin-scranton.api.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\"}"
                                     ));

            var response = DomainResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"domains\": [],\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\",\"next_page_uri\": null,\"page\": 0,\"page_size\": 50,\"previous_page_uri\": null,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json?PageSize=50&Page=0\"}"
                                     ));

            var response = DomainResource.Read(client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains.json",
                ""
            );
            request.AddPostParam("DomainName", Serialize("DomainName"));
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                DomainResource.Create("DomainName", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}"
                                     ));

            var response = DomainResource.Create("DomainName", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                DomainResource.Fetch("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}"
                                     ));

            var response = DomainResource.Fetch("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                DomainResource.Update("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"auth_type\": \"IP_ACL\",\"date_created\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"date_updated\": \"Fri, 06 Sep 2013 19:18:30 -0000\",\"domain_name\": \"dunder-mifflin-scranton.sip.twilio.com\",\"friendly_name\": \"Scranton Office\",\"sid\": \"SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"subresource_uris\": {\"credential_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/CredentialListMappings.json\",\"ip_access_control_list_mappings\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/IpAccessControlListMappings.json\"},\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\",\"voice_fallback_method\": \"POST\",\"voice_fallback_url\": null,\"voice_method\": \"POST\",\"voice_status_callback_method\": \"POST\",\"voice_status_callback_url\": null,\"voice_url\": \"https://dundermifflin.example.com/twilio/app.php\"}"
                                     ));

            var response = DomainResource.Update("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Api,
                "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/SIP/Domains/SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json",
                ""
            );
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                DomainResource.Delete("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = DomainResource.Delete("SDaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}