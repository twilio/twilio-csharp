using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Base class for all TwiML Objects.
    /// </summary>
    public partial class TwiML
    {
        /// <summary>
        /// Tag name
        /// </summary>
        private string TagName { get; }

        /// <summary>
        /// Children elements
        /// </summary>
        private List<TwiML> Children { get; }

        /// <summary>
        /// Additional tag attributes to set on the generated xml
        /// </summary>
        private List<KeyValuePair<string, string>> Options { get; }

        /// <summary>
        /// Base constructor to create any TwiML instance.
        /// </summary>
        /// <param name="tagName"> TwiML tag name </param>
        protected TwiML(string tagName)
        {
            TagName = tagName;
            Children = new List<TwiML>();
            Options = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Get the TwiML element body.
        /// </summary>
        protected virtual string GetElementBody()
        {
            return string.Empty;
        }

        /// <summary>
        /// Get the TwiML element attributes.
        /// </summary>
        protected virtual IEnumerable<XAttribute> GetElementAttributes()
        {
            return Enumerable.Empty<XAttribute>();
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public virtual TwiML Append(TwiML childElem)
        {
            Children.Add(childElem);
            return this;
        }

        public TwiML AddText(string text)
        {
            Children.Add(new Text(text));
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning the newly created element.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public T Nest<T>(T childElem) where T : TwiML
        {
            Children.Add(childElem);
            return childElem;
        }

        /// <summary>
        /// Add a generic child TwiML object
        /// </summary>
        /// <param name="tagName"> TwiML tag name </param>
        public TwiML AddChild(string tagName)
        {
            return Nest(new TwiML(tagName));
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public TwiML SetOption(string key, object value)
        {
            if (Options.Exists(e => e.Key.Equals(key)))
            {
                Options.Remove(Options.Find(e => e.Key.Equals(key)));
            }

            Options.Add(new KeyValuePair<string, string>(key, value.ToString()));
            return this;
        }

        /// <summary>
        /// Get freeform key-value attributes attached to this class
        /// </summary>
        /// <param name="key"> Option key </param>
        public virtual string GetOption(string key)
        {
            return Options.Find(e => e.Key.Equals(key)).Value;
        }
    }
}