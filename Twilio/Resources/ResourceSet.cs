using System.Collections.Generic;
using Twilio.Readers;

namespace Twilio.Resources
{
	public class ResourceSet<E> : IEnumerable<E> where E : Resource
    {
		protected Page<E> page;
		protected bool autoPaging;
		protected Reader<E> reader;
		// TwilioRestClient object
		protected object client;
		protected IEnumerator<E> iterator;

		public ResourceSet(Reader<E> reader, object client, Page<E> page) {
			this.reader = reader;
			this.client = client;
			this.page = page;
			iterator = page.getRecords().GetEnumerator();
			autoPaging = true;
		}

		override System.Collections.IEnumerator GetEnumerator() {
			return new ResourceSetIterator<>(this);
		}

		protected void fetchNextPage() {
			if (page.getNextPageUri() == null) {
				return;
			}

			page = reader.nextPage(page.getNextPageUri (), client);
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
			reader.setPageSize(pageSize);
		}

		public class ResourceSetIterator<E> : IEnumerator<E> where E : Resource
		{
			private ResourceSet<E> resourceSet;

			public ResourceSetIterator(ResourceSet<E> resourceSet) {
				this.resourceSet = resourceSet;
			}

			public E Current {
				get { resourceSet.GetEnumerator().Current; }
			}

			public bool MoveNext() {
				return resourceSet.GetEnumerator().MoveNext();
			}

			public void Reset() {
				resourceSet.GetEnumerator().Reset();
			}
		}
    }
}