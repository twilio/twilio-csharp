/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// VerificationAttemptsSummaryResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Verify.V2
{

    public class VerificationAttemptsSummaryResource : Resource
    {
        public sealed class ChannelsEnum : StringEnum
        {
            private ChannelsEnum(string value) : base(value) {}
            public ChannelsEnum() {}
            public static implicit operator ChannelsEnum(string value)
            {
                return new ChannelsEnum(value);
            }

            public static readonly ChannelsEnum Sms = new ChannelsEnum("sms");
            public static readonly ChannelsEnum Call = new ChannelsEnum("call");
            public static readonly ChannelsEnum Email = new ChannelsEnum("email");
            public static readonly ChannelsEnum Whatsapp = new ChannelsEnum("whatsapp");
        }

        private static Request BuildFetchRequest(FetchVerificationAttemptsSummaryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                "/v2/Attempts/Summary",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Get a summary of how many attempts were made and how many were converted.
        /// </summary>
        /// <param name="options"> Fetch VerificationAttemptsSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of VerificationAttemptsSummary </returns>
        public static VerificationAttemptsSummaryResource Fetch(FetchVerificationAttemptsSummaryOptions options,
                                                                ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Get a summary of how many attempts were made and how many were converted.
        /// </summary>
        /// <param name="options"> Fetch VerificationAttemptsSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of VerificationAttemptsSummary </returns>
        public static async System.Threading.Tasks.Task<VerificationAttemptsSummaryResource> FetchAsync(FetchVerificationAttemptsSummaryOptions options,
                                                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Get a summary of how many attempts were made and how many were converted.
        /// </summary>
        /// <param name="verifyServiceSid"> Filter the verification attempts considered on the summary by verify service.
        ///                        </param>
        /// <param name="dateCreatedAfter"> Consider verification attempts create after this date on the summary. </param>
        /// <param name="dateCreatedBefore"> Consider verification attempts created before this date on the summary. </param>
        /// <param name="country"> Filter verification attempts considered on the summary by destination country. </param>
        /// <param name="channel"> Filter verification attempts considered on the summary by communication channel. </param>
        /// <param name="destinationPrefix"> Filters the attempts considered on the summary by destination prefix. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of VerificationAttemptsSummary </returns>
        public static VerificationAttemptsSummaryResource Fetch(string verifyServiceSid = null,
                                                                DateTime? dateCreatedAfter = null,
                                                                DateTime? dateCreatedBefore = null,
                                                                string country = null,
                                                                VerificationAttemptsSummaryResource.ChannelsEnum channel = null,
                                                                string destinationPrefix = null,
                                                                ITwilioRestClient client = null)
        {
            var options = new FetchVerificationAttemptsSummaryOptions(){VerifyServiceSid = verifyServiceSid, DateCreatedAfter = dateCreatedAfter, DateCreatedBefore = dateCreatedBefore, Country = country, Channel = channel, DestinationPrefix = destinationPrefix};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Get a summary of how many attempts were made and how many were converted.
        /// </summary>
        /// <param name="verifyServiceSid"> Filter the verification attempts considered on the summary by verify service.
        ///                        </param>
        /// <param name="dateCreatedAfter"> Consider verification attempts create after this date on the summary. </param>
        /// <param name="dateCreatedBefore"> Consider verification attempts created before this date on the summary. </param>
        /// <param name="country"> Filter verification attempts considered on the summary by destination country. </param>
        /// <param name="channel"> Filter verification attempts considered on the summary by communication channel. </param>
        /// <param name="destinationPrefix"> Filters the attempts considered on the summary by destination prefix. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of VerificationAttemptsSummary </returns>
        public static async System.Threading.Tasks.Task<VerificationAttemptsSummaryResource> FetchAsync(string verifyServiceSid = null,
                                                                                                        DateTime? dateCreatedAfter = null,
                                                                                                        DateTime? dateCreatedBefore = null,
                                                                                                        string country = null,
                                                                                                        VerificationAttemptsSummaryResource.ChannelsEnum channel = null,
                                                                                                        string destinationPrefix = null,
                                                                                                        ITwilioRestClient client = null)
        {
            var options = new FetchVerificationAttemptsSummaryOptions(){VerifyServiceSid = verifyServiceSid, DateCreatedAfter = dateCreatedAfter, DateCreatedBefore = dateCreatedBefore, Country = country, Channel = channel, DestinationPrefix = destinationPrefix};
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a VerificationAttemptsSummaryResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> VerificationAttemptsSummaryResource object represented by the provided JSON </returns>
        public static VerificationAttemptsSummaryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<VerificationAttemptsSummaryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// Total of attempts made.
        /// </summary>
        [JsonProperty("total_attempts")]
        public int? TotalAttempts { get; private set; }
        /// <summary>
        /// Total of attempts confirmed by the end user.
        /// </summary>
        [JsonProperty("total_converted")]
        public int? TotalConverted { get; private set; }
        /// <summary>
        /// Total of attempts made that were not confirmed by the end user.
        /// </summary>
        [JsonProperty("total_unconverted")]
        public int? TotalUnconverted { get; private set; }
        /// <summary>
        /// Percentage of the confirmed messages over the total.
        /// </summary>
        [JsonProperty("conversion_rate_percentage")]
        public decimal? ConversionRatePercentage { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private VerificationAttemptsSummaryResource()
        {

        }
    }

}