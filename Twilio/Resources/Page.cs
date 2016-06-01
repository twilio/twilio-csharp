using System;
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

		public Page() {
			this.records = new List<T>();
		}

		public List<T> GetRecords() {
			return records;
		}

		public string GetFirstPageUri() {
			return firstPageUri;
		}

		public string GetNextPageUri() {
			return nextPageUri;
		}

		public string GetPreviousPageUri() {
			return previousPageUri;
		}

		public string GetUri() {
			return uri;
		}

		public int GetPageSize() {
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
				uri = new Uri(meta["url"].Value<string>()).PathAndQuery;
				nextPageNode = meta["next_page_url"];
				previousPageNode = meta["previous_page_url"];

				firstPageUri = new Uri(meta["first_page_url"].Value<string>()).PathAndQuery;
				pageSize = meta["page_size"].Value<int>();

				nextPageUri = nextPageNode.Value<string>();
				if (nextPageUri != null) {
					nextPageUri = new Uri(nextPageUri).PathAndQuery;
				}
				previousPageUri = previousPageNode.Value<string>();
				if (previousPageUri != null) {
					previousPageUri = new Uri(previousPageUri).PathAndQuery;
				}
			}
		}
	}
}