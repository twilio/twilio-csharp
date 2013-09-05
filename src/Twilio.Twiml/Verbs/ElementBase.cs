using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Twilio.TwiML.Verbs;

namespace Twilio.TwiML
{
    /// <summary>
    /// Provides an abstract base class for TwiML nouns and verbs
    /// </summary>
	public abstract class ElementBase
	{
		public List<string> AllowedChildren { get; set; }
		public List<string> AllowedAttributes { get; set; }
		public XElement Element { get; set; }
		protected Stack<ElementBase> Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the ElementBase class
        /// </summary>
		public ElementBase()
		{
			AllowedAttributes = new List<string>();
			AllowedChildren = new List<string>();
			Current = new Stack<ElementBase>();
		}

        /// <summary>
        /// Adds a new element to the TwiML response
        /// </summary>
        /// <param name="verb"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Enumerates the properties of the provided object and converts them to element attributes
        /// </summary>
        /// <param name="attributes"></param>
		public void AddAttributesFromObject(object attributes)
		{
            if (attributes != null)
            {
                foreach (var prop in attributes.GetType().GetProperties())
                {
                    Element.SetAttributeValue(prop.Name, prop.GetValue(attributes, null));
                }
            }
		}

        /// <summary>
        /// Returns the value of an element attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
		public T GetAttributeValue<T>(string key)
		{
			if (Element.Attributes(key) != null)
			{
				return (T)Element.Attributes(key);
			}

			return default(T);
		}

        /// <summary>
        /// Sets the value of an element attribute
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
		public void SetAttributeValue(string key, object value)
		{
			if (AllowedAttributes.Contains(key))
			{
				Element.Add(new XAttribute(key, value));
			}
		}
	}
}
