using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Monitor.V1;

namespace Twilio.Tests.Monitor.V1 {

    [TestFixture]
    public class AlertTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alert_text\": \"sourceComponent=14100&httpResponse=500&url=https%3A%2F%2F2Fv1%2Fsms%2Ftwilio&ErrorCode=11200&LogLevel=ERROR&Msg=Internal+Server+Error&EmailNotification=false\",\"api_version\": \"2008-08-01\",\"date_created\": \"2015-08-29T17:20:16Z\",\"date_generated\": \"2015-08-29T17:20:14Z\",\"date_updated\": \"2015-08-29T17:20:16Z\",\"error_code\": \"11200\",\"log_level\": \"error\",\"more_info\": \"https://www.twilio.com/docs/errors/11200\",\"request_method\": \"POST\",\"request_url\": \"https://www.example.com\",\"request_variables\": \"ToCountry=US&ToState=CA&SmsMessageSid=SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa&NumMedia=0&ToCity=&FromZp&FromState=CA&SmsStatus=received&FromCity=SAN+FRANCISCO&Body=plan+5+potato&FromCountry=US&To=%2B1&ToZip=&NumSegments=1&MessageSid=SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa&AccountSid=ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa&From=%2B1&ApiVersion=2010-04-01\",\"resource_sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"response_body\": \"blahblah\",\"response_headers\": \"X-Cache=MISS+from+ip-10-.Google+Frontend&X-Cache-Lookup=MISS+from+ip&Alt-Svc=quic%3D%22%3A443%22%3B+p%3D%221%22%3B+ma%3D604800&Content-Length=323&Content-Type=text%2Fhtml%3B+charset%3DUTF-8&Date=Sat%2C+29+Aug+2015+17%3A20%3A16+GMT&Alternate-Protocol=443%3Aquic%2Cp%3D1\",\"sid\": \"NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://monitor.twilio.com/v1/Alerts/NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}")));
            
            var task = AlertResource.Fetch("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.NoContent,
                                             "null")));
            
            var task = AlertResource.Delete("NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
            task.Wait();
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"alerts\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"alert_text\": \"sourceComponent=14100&httpResponse=500&url=https%3A%2F%2Fcommunicate-indonesia-staging.appspot.com%2Fv1%2Fsms%2Ftwilio&ErrorCode=11200&LogLevel=ERROR&Msg=Internal+Server+Error&EmailNotification=false\",\"api_version\": \"2008-08-01\",\"date_created\": \"2015-08-29T17:20:16Z\",\"date_generated\": \"2015-08-29T17:20:14Z\",\"date_updated\": \"2015-08-29T17:20:16Z\",\"error_code\": \"11200\",\"log_level\": \"error\",\"more_info\": \"https://www.twilio.com/docs/errors/11200\",\"request_method\": \"POST\",\"request_url\": \"https://www.example.com\",\"resource_sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"sid\": \"NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://monitor.twilio.com/v1/Alerts/NOaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Alerts?PageSize=1&Page=0\",\"key\": \"alerts\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Alerts?PageSize=1&Page=0\"}}")));
            
            var task = AlertResource.Read().ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(System.Threading.Tasks.Task.FromResult(
                                new Response(System.Net.HttpStatusCode.OK,
                                             "{\"alerts\": [],\"meta\": {\"first_page_url\": \"https://monitor.twilio.com/v1/Alerts?PageSize=1&Page=0\",\"key\": \"alerts\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://monitor.twilio.com/v1/Alerts?PageSize=1&Page=0\"}}")));
            
            var task = AlertResource.Read().ExecuteAsync(twilioRestClient);
            task.Wait();
            Assert.NotNull(task.Result);
        }
    }
}