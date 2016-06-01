using System.Collections.Generic;
using Twilio.Readers;
using Twilio.Clients;

namespace Twilio.Resources
{
	public class ResourceSet<E> : IEnumerable<E> where E : Resource
    {
		protected Page<E> page;
		protected bool autoPaging;
		protected Reader<E> reader;
		protected ITwilioRestClient client;
		protected IEnumerator<E> iterator;

		public ResourceSet(Reader<E> reader, ITwilioRestClient client, Page<E> page) {
			this.reader = reader;
			this.client = client;
			this.page = page;
			if (page == null) {
				throw new System.Exception("page is null");
			}
			iterator = page.GetRecords().GetEnumerator();
			autoPaging = true;
		}

		public IEnumerator<E> GetEnumerator() {
			return NewEnumerator();
		}

		public IEnumerator<E> NewEnumerator() {
			while (page != null) {
				iterator.Reset();
				while (iterator.MoveNext()) {
					yield return iterator.Current;
				}

				if (IsAutoPaging() && page.GetNextPageUri () != "") {
					FetchNextPage();
				}
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return NewEnumerator();
		}

		protected void FetchNextPage() {
			if (page.GetNextPageUri() == null || page.GetNextPageUri() == "") {
				page = null;
				iterator = null;
				return;
			}

			page = reader.NextPage(page.GetNextPageUri(), client);
			if (page != null) {
				iterator = page.GetRecords().GetEnumerator ();
			}
		}

		public bool IsAutoPaging() {
			return autoPaging;
		}

		public void SetAutoPaging(bool autoPaging) {
			this.autoPaging = autoPaging;
		}

		public int GetPageSize() {
			return this.page.GetPageSize();
		}

		public void SetPageSize(int pageSize) {
			reader.SetPageSize(pageSize);
		}
    }
}