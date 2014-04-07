using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple;

namespace SimpleRestClient.Tests
{
	public class Oddball
	{
		public string Sid { get; set; }
		public string FriendlyName { get; set; }

		[DeserializeAs(Name = "oddballPropertyName")]
		public string GoodPropertyName { get; set; }
	}
}
