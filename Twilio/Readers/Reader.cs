using System.Threading.Tasks;
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Readers
{
    public abstract class Reader<T> where T : Resource
    {
		private int pageSize = 50;

        public abstract Task<ResourceSet<T>> execute(TwilioRestClient client);

		public abstract Page<T> nextPage(string nextPageUri, TwilioRestClient client);

		public int getPageSize() {
			return this.pageSize;
		}

		public Reader<T> setPageSize(int pageSize) {
			this.pageSize = pageSize;
			return this;
		}
    }
}