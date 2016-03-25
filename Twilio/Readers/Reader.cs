using System.Threading.Tasks;
using Twilio.Resources;

namespace Twilio.Readers
{
    public abstract class Reader<T> where T : Resource
    {
		private int pageSize = 50;

        public T execute(Twilio.Http.HttpClient client) {
            var task = executeAsync(client);
            task.Wait();
            
            return task.Result;
        }
        
        public abstract Task<T> executeAsync(Twilio.Http.HttpClient client);

		public abstract Page<T> nextPage(string nextPageUri, Twilio.Http.HttpClient client);

		public int getPageSize() {
			return this.pageSize;
		}

		public Reader<T> setPageSize(int pageSize) {
			this.pageSize = pageSize;
			return this;
		}
    }
}