/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML.Voice
{

    /// <summary>
    /// Stop TwiML Verb
    /// </summary>
    public class Stop : TwiML
    {
        /// <summary>
        /// Create a new Stop
        /// </summary>
        public Stop() : base("Stop")
        {
        }

        /// <summary>
        /// Create a new <Stream/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Friendly name given to the Stream </param>
        /// <param name="connectorName"> Unique name for Stream Connector </param>
        /// <param name="url"> URL of the remote service where the Stream is routed </param>
        /// <param name="track"> Track to be streamed to remote service </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL method </param>
        public Stop Stream(string name = null,
                           string connectorName = null,
                           string url = null,
                           Stream.TrackEnum track = null,
                           string statusCallback = null,
                           Stream.StatusCallbackMethodEnum statusCallbackMethod = null)
        {
            var newChild = new Stream(name, connectorName, url, track, statusCallback, statusCallbackMethod);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Stream/> element as a child of this element
        /// </summary>
        /// <param name="stream"> A Stream instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Stop Stream(Stream stream)
        {
            this.Append(stream);
            return this;
        }

        /// <summary>
        /// Create a new <Siprec/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Friendly name given to SIPREC </param>
        /// <param name="connectorName"> Unique name for Connector </param>
        /// <param name="track"> Track to be streamed to remote service </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL method </param>
        public Stop Siprec(string name = null,
                           string connectorName = null,
                           Siprec.TrackEnum track = null,
                           string statusCallback = null,
                           Siprec.StatusCallbackMethodEnum statusCallbackMethod = null)
        {
            var newChild = new Siprec(name, connectorName, track, statusCallback, statusCallbackMethod);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Siprec/> element as a child of this element
        /// </summary>
        /// <param name="siprec"> A Siprec instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Stop Siprec(Siprec siprec)
        {
            this.Append(siprec);
            return this;
        }

        /// <summary>
        /// Create a new <Transcription/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Friendly name given to the Transcription </param>
        /// <param name="track"> Track to be analyze by the provider </param>
        /// <param name="statusCallbackUrl"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL method </param>
        /// <param name="inboundTrackLabel"> Friendly name given to the Inbound Track </param>
        /// <param name="outboundTrackLabel"> Friendly name given to the Outbound Track Label </param>
        /// <param name="partialResults"> Indicates if partial results are going to be send to the customer </param>
        /// <param name="languageCode"> Language Code used by the transcription engine </param>
        /// <param name="transcriptionEngine"> Transcription Engine to be used </param>
        /// <param name="profanityFilter"> Enable Profanity Filter </param>
        /// <param name="speechModel"> Speech Model used by the transcription engine </param>
        /// <param name="hints"> Hints to be provided to the transcription engine </param>
        /// <param name="enableAutomaticPunctuation"> Enable Automatic Punctuation </param>
        /// <param name="intelligenceService"> The SID or the unique name of the Intelligence Service to be used </param>
        public Stop Transcription(string name = null,
                                  Transcription.TrackEnum track = null,
                                  string statusCallbackUrl = null,
                                  Transcription.StatusCallbackMethodEnum statusCallbackMethod = null,
                                  string inboundTrackLabel = null,
                                  string outboundTrackLabel = null,
                                  bool? partialResults = null,
                                  string languageCode = null,
                                  string transcriptionEngine = null,
                                  bool? profanityFilter = null,
                                  string speechModel = null,
                                  string hints = null,
                                  bool? enableAutomaticPunctuation = null,
                                  string intelligenceService = null)
        {
            var newChild = new Transcription(
                name,
                track,
                statusCallbackUrl,
                statusCallbackMethod,
                inboundTrackLabel,
                outboundTrackLabel,
                partialResults,
                languageCode,
                transcriptionEngine,
                profanityFilter,
                speechModel,
                hints,
                enableAutomaticPunctuation,
                intelligenceService
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Transcription/> element as a child of this element
        /// </summary>
        /// <param name="transcription"> A Transcription instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Stop Transcription(Transcription transcription)
        {
            this.Append(transcription);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Stop Append(TwiML childElem)
        {
            return (Stop) base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Stop SetOption(string key, object value)
        {
            return (Stop) base.SetOption(key, value);
        }
    }

}