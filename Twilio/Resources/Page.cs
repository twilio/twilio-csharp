using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Resources
{
	public class Page<T> where T : Resource
	{
		protected List<T> records;
		protected string firstPageUri;
		protected string nextPageUri;
		protected string previousPageUri;
		protected string uri;
		protected int pageSize;

		public List<T> getRecords() {
			return records;
		}

		public string getFirstPageUri() {
			return firstPageUri;
		}

		public string getNextPageUri() {
			return nextPageUri;
		}

		public string getPreviousPageUri() {
			return previousPageUri;
		}

		public string getUri() {
			return uri;
		}

		public int getPageSize() {
			return pageSize;
		}

		public void deserialize(string recordKey, string json) {
			JObject root = JObject.Parse(json);
			var records = root[recordKey];
			foreach (JToken record in records.Children()) {
				T result = JsonConvert.DeserializeObject<T>(record.ToString());
				this.records.Add(result);
			}

			var nextPageNode = root["next_page_uri"];
			var previousPageNode = root["previous_page_uri"];
			var uriNode = root["uri"];

			if (uriNode != null) {
				uri = uriNode.Value<string> ();
				firstPageUri = root ["first_page_uri"].Value<string> ();
				pageSize = root ["page_size"].Value<int> ();

				nextPageUri = nextPageNode.Value<string> ();
				previousPageUri = previousPageNode.Value<string> ();
			} else {
				var meta = root["meta"];
				uri = 
			}
		}
	}
}