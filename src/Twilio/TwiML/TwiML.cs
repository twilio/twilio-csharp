using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Twilio.Exceptions;

namespace Twilio.TwiML
{

    /// <summary>
    /// Base class for all TwiML Objects.
    /// </summary>
    public class TwiML
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
        private List<KeyValuePair<string,string>> Options { get; }
        /// <summary>
        /// Attribute names to be transformed on the generated xml
        /// </summary>
        private Dictionary<string, string> AttributeNameMapper = new Dictionary<string, string> { { "for_", "for" } };

        /// <summary>
        /// Base constructor to create any TwiML instance.
        /// </summary>
        /// <param name="tagName"> TwiML tag name </param>
        protected TwiML(string tagName)
        {
            this.TagName = tagName;
            this.Children = new List<TwiML>();
            this.Options = new List<KeyValuePair<string,string>>();
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
        protected virtual List<XAttribute> GetElementAttributes()
        {
            return new List<XAttribute>();
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public virtual TwiML Append(TwiML childElem)
        {
            this.Children.Add(childElem);
            return this;
        }

        public TwiML AddText(string text)
        {
            this.Children.Add(new Text(text));
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning the newly created element.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public T Nest<T>(T childElem) where T : TwiML
        {
            this.Children.Add(childElem);
            return childElem;
        }

        /// <summary>
        /// Add a generic child TwiML object
        /// </summary>
        /// <param name="tagName"> TwiML tag name </param>
        public TwiML AddChild(string tagName)
        {
            return this.Nest(new TwiML(tagName));
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public TwiML SetOption(string key, object value)
        {
            if (this.Options.Exists(e => e.Key.Equals(key)))
            {
                this.Options.Remove(this.Options.Find(e => e.Key.Equals(key)));
            }

            this.Options.Add(new KeyValuePair<string, string>(key, value.ToString()));
            return this;
        }

        /// <summary>
        /// Get freeform key-value attributes attached to this class
        /// </summary>
        /// <param name="key"> Option key </param>
        public virtual string GetOption(string key)
        {
            return this.Options.Find(e => e.Key.Equals(key)).Value;
        }

        /// <summary>
        /// Generate XElement from TwiML object
        /// </summary>
        protected virtual XNode ToXml()
        {
            var elem = new XElement(this.TagName, this.GetElementBody());

            this.GetElementAttributes().ForEach(attr =>
            {
                string transformedAttr = attr.Name.LocalName;
                if (AttributeNameMapper.TryGetValue(attr.Name.LocalName, out transformedAttr))
                {
                    elem.Add(new XAttribute(transformedAttr, attr.Value));
                }
                else
                {
                    elem.Add(attr);
                }
            });

            this.Options.ForEach(e =>
            {
                if (e.Key.StartsWith("xml:"))
                {
                    var attribute = new XAttribute(XNamespace.Xml + e.Key.Substring(4), e.Value);
                    elem.Add(attribute);
                }
                else
                {
                    elem.Add(new XAttribute(e.Key, e.Value));
                }
            });

            this.Children.ForEach(child => elem.Add(child.ToXml()));

            return elem;
        }
        
        /// <summary>
        /// Generate XDocument from TwiML object
        /// </summary>
        public XDocument ToXDocument()
        {
            var declaration = new XDeclaration("1.0", "utf-8", null);
            var elem = this.ToXml();
            var document = new XDocument(declaration, elem);
            return document;
        }

        /// <summary>
        /// Generate XML string from TwiML object
        /// </summary>
        /// <param name="formattingOptions"> Change generated string format. </param>
        public string ToString(SaveOptions formattingOptions = SaveOptions.None)
        {
            var document = this.ToXDocument();
            var writer = new Utf8StringWriter();
            document.Save(writer, formattingOptions);
            return writer.GetStringBuilder().ToString();
        }
    }

    /// <summary>
    /// StringWriter which overrides default encoding to use UTF8.
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

}