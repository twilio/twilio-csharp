using System.Threading.Tasks;
using Twilio.Resources;

namespace Twilio.Creators
{
    public abstract class Creator<T> where T : Resource
    {
        public T execute(Twilio.Http.HttpClient client) {
            var task = executeAsync(client);
            task.Wait();
            
            return task.Result;
        }
        
        public abstract Task<T> executeAsync(Twilio.Http.HttpClient client);
    }
}