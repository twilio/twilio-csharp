#if NET40
using System.Threading.Tasks;
#endif
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Readers
{
    public abstract class Reader<T> where T : Resource
    {
		private int pageSize = 50;

		#if NET40
        public abstract Task<ResourceSet<T>> ExecuteAsync(ITwilioRestClient client);
		#endif
        public abstract ResourceSet<T> Execute(ITwilioRestClient client);

		public abstract Page<T> NextPage(string nextPageUri, ITwilioRestClient client);

		public int GetPageSize() {
			return this.pageSize;
		}

		public Reader<T> SetPageSize(int pageSize) {
			this.pageSize = pageSize;
			return this;
		}
    }
}