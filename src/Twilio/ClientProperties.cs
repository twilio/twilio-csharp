using Twilio.Clients;
using Twilio.Clients.BearerToken;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;

namespace Twilio
{
    public class ClientProperties
    {
        public static string region;
        public static string edge;
        public static string logLevel;

        public ClientProperties() { }


        /// <summary>
        /// Set the client region
        /// </summary>
        /// <param name="region">Client region</param>
        public static void SetRegion(string region)
        {
            region = region;
        }

        /// <summary>
        /// Set the client edge
        /// </summary>
        /// <param name="edge">Client edge</param>
        public static void SetEdge(string edge)
        {
            edge = edge;
        }

        /// <summary>
        /// Set the logging level
        /// </summary>
        /// <param name="loglevel">log level</param>
        public static void SetLogLevel(string loglevel)
        {
            logLevel = loglevel;
        }

    }
}
