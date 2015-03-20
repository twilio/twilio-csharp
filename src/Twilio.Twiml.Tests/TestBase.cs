using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.Schema;
using System.Xml;

namespace Twilio.TwiML.Tests
{
	public class TestBase
	{
		public XmlSchemaSet Schemas { get; set; }

		public TestBase()
		{
			Schemas = new XmlSchemaSet();
			Schemas.Add("", XmlReader.Create("TwiML.xsd"));
		}

		public bool IsValidTwiML(XDocument doc)
		{
			Console.Write(doc.ToString());

			var valid = true;
			doc.Validate(Schemas, (o, e) => {
                Console.WriteLine(e);
                valid = false; 
            });
			return valid;
		}
	}
}
