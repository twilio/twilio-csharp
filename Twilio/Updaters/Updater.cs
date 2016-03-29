using System.Threading.Tasks;
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Updaters
{
    public abstract class Updater<T> where T : Resource
    {
        public abstract Task<T> execute(TwilioRestClient client);
    }
}