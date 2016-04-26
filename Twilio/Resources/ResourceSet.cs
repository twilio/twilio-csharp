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
			iterator = page.getRecords().GetEnumerator();
			autoPaging = true;
		}

		public IEnumerator<E> GetEnumerator() {
			return new ResourceSetIterator<E>(this);
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return new ResourceSetIterator<E>(this);
		}

		protected void fetchNextPage() {
			if (page.getNextPageUri() == null) {
				return;
			}

			page = reader.NextPage(page.getNextPageUri(), client);
			if (page != null) {
				iterator = page.getRecords().GetEnumerator ();
			}
		}

		public bool isAutoPaging() {
			return autoPaging;
		}

		public void setAutoPaging(bool autoPaging) {
			this.autoPaging = autoPaging;
		}

		public int getPageSize() {
			return this.page.getPageSize();
		}

		public void setPageSize(int pageSize) {
			reader.SetPageSize(pageSize);
		}

		public class ResourceSetIterator<R> : IEnumerator<R> where R : Resource
		{
			private ResourceSet<R> resourceSet;

			public ResourceSetIterator(ResourceSet<R> resourceSet) {
				this.resourceSet = resourceSet;
			}

			public R Current {
				get { return resourceSet.GetEnumerator().Current; }
			}

			object System.Collections.IEnumerator.Current {
				get { return resourceSet.GetEnumerator().Current; }
			}

			public bool MoveNext() {
				return resourceSet.GetEnumerator().MoveNext();
			}

			public void Reset() {
				resourceSet.GetEnumerator().Reset();
			}

			public void Dispose(){}
		}
    }
}