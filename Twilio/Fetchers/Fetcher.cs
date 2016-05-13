using System.Threading.Tasks;
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Fetchers
{
    public abstract class Fetcher<T> where T : Resource
    {
        public abstract Task<T> ExecuteAsync(ITwilioRestClient client);
    }
}