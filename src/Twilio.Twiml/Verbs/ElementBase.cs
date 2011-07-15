using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Twilio.TwiML.Verbs;

namespace Twilio.TwiML
{
	public abstract class ElementBase
	{
		public List<string> AllowedChildren { get; set; }
		public List<string> AllowedAttributes { get; set; }
		public XElement Element { get; set; }
		protected Stack<ElementBase> Current { get; set; }

		public ElementBase()
		{
			AllowedAttributes = new List<string>();
			AllowedChildren = new List<string>();
			Current = new Stack<ElementBase>();
		}

		protected ElementBase Add(ElementBase verb)
		{
			var root = Element;
			var elementToAdd = verb.Element;
			var allowed = AllowedChildren;

			if (Current.Any())
			{
				root = Current.Peek().Element;
				allowed = Current.Peek().AllowedChildren;
			}

			if (allowed.Contains(verb.Element.Name.ToString()))
			{
				root.Add(elementToAdd);
			}

			return this;
		}

		public void AddAttributesFromObject(object attributes)
		{
			foreach (var prop in attributes.GetType().GetProperties())
			{
				Element.SetAttributeValue(prop.Name, prop.GetValue(attributes, null));
			}
		}

		public T GetAttributeValue<T>(string key)
		{
			if (Element.Attributes(key) != null)
			{
				return (T)Element.Attributes(key);
			}

			return default(T);
		}

		public void SetAttributeValue(string key, object value)
		{
			if (AllowedAttributes.Contains(key))
			{
				Element.Add(new XAttribute(key, value));
			}
		}
	}
}
