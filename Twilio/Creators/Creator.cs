using System.Threading.Tasks;
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Creators
{
    public abstract class Creator<T> where T : Resource
    {
		public abstract Task<T> ExecuteAsync(ITwilioRestClient client);
    }
}