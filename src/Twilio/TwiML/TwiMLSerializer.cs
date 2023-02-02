using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Stream = System.IO.Stream;
#if !NET35
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
#endif

namespace Twilio.TwiML
{
    /// <summary>
    /// Base class for all TwiML Objects.
    /// </summary>
    public partial class TwiML
    {
        /// <summary>
        /// Attribute names to be transformed on the generated xml
        /// </summary>
        private static Dictionary<string, string> AttributeNameMapper = new Dictionary<string, string> { { "for_", "for" } };

        /// <summary>
        /// Generate XElement from TwiML object
        /// </summary>
        [Obsolete]
        protected virtual XNode ToXml()
        {
            var elem = new XElement(TagName, GetElementBody());

            foreach (var attr in GetElementAttributes())
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
            }

            Options.ForEach(e =>
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

            Children.ForEach(child => elem.Add(child.ToXml()));

            return elem;
        }

        /// <summary>
        /// Generate XDocument from TwiML object
        /// </summary>
        [Obsolete("ToXDocument will be removed in the future. Please use ToString, Save, or SaveAsync.")]
        public XDocument ToXDocument()
        {
            var declaration = new XDeclaration("1.0", "utf-8", null);
            var elem = ToXml();
            var document = new XDocument(declaration, elem);
            return document;
        }

        /// <summary>
        /// Write TwiML to TextWriter as XML.
        /// </summary>
        /// <param name="textWriter">TextWriter to write XML string to.</param>
        public void Save(TextWriter textWriter)
        {
            Save(textWriter, SaveOptions.None);
        }

        /// <summary>
        /// Write TwiML to TextWriter as XML.
        /// </summary>
        /// <param name="textWriter">TextWriter to write XML string to.</param>
        /// <param name="formattingOptions">Change generated string format.</param>
        public void Save(TextWriter textWriter, SaveOptions formattingOptions)
        {
            var ws = GetXmlWriterSettings(formattingOptions);
            using (var writer = XmlWriter.Create(textWriter, ws))
                Save(writer);
        }

        /// <summary>
        /// Write TwiML to Stream as XML.
        /// </summary>
        /// <param name="stream">Stream to write XML string to.</param>
        public void Save(Stream stream)
        {
            Save(stream, SaveOptions.None);
        }

        /// <summary>
        /// Write TwiML to Stream as XML.
        /// </summary>
        /// <param name="stream">Stream to write XML string to.</param>
        /// <param name="formattingOptions">Change generated string format.</param>
        public void Save(Stream stream, SaveOptions formattingOptions)
        {
            var ws = GetXmlWriterSettings(formattingOptions);
            using (var writer = XmlWriter.Create(stream, ws))
                Save(writer);
        }

        /// <summary>
        /// Write TwiML to XmlWriter as XML. Configure the XmlWriter before invoking Save.
        /// </summary>
        /// <param name="writer">XmlWriter to write XML string to.</param>
        public void Save(XmlWriter writer)
        {
            writer.WriteStartDocument();
            WriteContent(writer);
            writer.WriteEndDocument();
            writer.Flush();
        }

        /// <summary>
        /// Write the Element, Attributes, and inner XML of this TwiML object.
        /// </summary>
        /// <param name="writer">XmlWriter to write XML string to.</param>
        protected virtual void WriteContent(XmlWriter writer)
        {
            writer.WriteStartElement(null, TagName, null);

            foreach (var attribute in GetElementAttributes())
            {
                var attributeName = attribute.Name.LocalName;
                string mappedName;
                if (AttributeNameMapper.TryGetValue(attributeName, out mappedName))
                {
                    writer.WriteAttributeString(
                        null,
                        mappedName,
                        attribute.Name.NamespaceName,
                        attribute.Value
                    );
                }
                else
                {
                    writer.WriteAttributeString(
                        null,
                        attributeName,
                        attribute.Name.NamespaceName,
                        attribute.Value
                    );
                }
            }

            foreach (var option in Options)
            {
                if (option.Key.StartsWith("xml:"))
                {
                    writer.WriteAttributeString(
                        null,
                        option.Key.Substring(4),
                        XNamespace.Xml.NamespaceName,
                        option.Value
                    );
                }
                else
                {
                    writer.WriteAttributeString(null, option.Key, null, option.Value);
                }
            }

            var body = GetElementBody();
            if (!string.IsNullOrEmpty(body))
            {
                writer.WriteString(body);
            }
            else
            {
                foreach (var child in Children)
                {
                    child.WriteContent(writer);
                }
            }

            writer.WriteEndElement();
        }

#if !NET35
        /// <summary>
        /// Write TwiML to TextWriter as XML.
        /// </summary>
        /// <param name="textWriter">TextWriter to write XML string to.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public Task SaveAsync(TextWriter textWriter, CancellationToken cancellationToken)
        {
            return SaveAsync(textWriter, SaveOptions.None, cancellationToken);
        }

        /// <summary>
        /// Write TwiML to TextWriter as XML.
        /// </summary>
        /// <param name="textWriter">TextWriter to write XML string to.</param>
        /// <param name="formattingOptions">Change generated string format.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public async Task SaveAsync(
            TextWriter textWriter, SaveOptions
            formattingOptions,
            CancellationToken cancellationToken
        )
        {
            var ws = GetXmlWriterSettings(formattingOptions);
            ws.Async = true;
            var writer = XmlWriter.Create(textWriter, ws);
#if NET6_0_OR_GREATER
            await using (writer.ConfigureAwait(false))
            {
#else
            using (writer)
            {
#endif
                await SaveAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Write TwiML to Stream as XML.
        /// </summary>
        /// <param name="stream">Stream to write XML string to.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public Task SaveAsync(Stream stream, CancellationToken cancellationToken)
        {
            return SaveAsync(stream, SaveOptions.None, cancellationToken);
        }

        /// <summary>
        /// Write TwiML to Stream as XML.
        /// </summary>
        /// <param name="stream">Stream to write XML string to.</param>
        /// <param name="formattingOptions">Change generated string format.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public async Task SaveAsync(Stream stream, SaveOptions formattingOptions, CancellationToken cancellationToken)
        {
            var ws = GetXmlWriterSettings(formattingOptions);
            ws.Async = true;
            var writer = XmlWriter.Create(stream, ws);
#if NET6_0_OR_GREATER
            await using (writer.ConfigureAwait(false))
            {
#else
            using (writer)
            {
#endif
                await SaveAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Write TwiML to XmlWriter as XML. Configure the XmlWriter before invoking Save.
        /// </summary>
        /// <param name="writer">XmlWriter to write XML string to.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public async Task SaveAsync(XmlWriter writer, CancellationToken cancellationToken)
        {
            await writer.WriteStartDocumentAsync().ConfigureAwait(false);
            await WriteXml(writer, cancellationToken).ConfigureAwait(false);
            await writer.WriteEndDocumentAsync().ConfigureAwait(false);
            await writer.FlushAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Write the Element, Attributes, and inner XML of this TwiML object.
        /// </summary>
        /// <param name="writer">XmlWriter to write XML string to.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        protected virtual async Task WriteXml(XmlWriter writer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await writer.WriteStartElementAsync(null, TagName, null).ConfigureAwait(false);

            foreach (var attribute in GetElementAttributes())
            {
                var attributeName = attribute.Name.LocalName;
                string mappedName;
                if (AttributeNameMapper.TryGetValue(attributeName, out mappedName))
                {
                    await writer.WriteAttributeStringAsync(
                        null,
                        mappedName,
                        attribute.Name.NamespaceName,
                        attribute.Value
                    ).ConfigureAwait(false);
                }
                else
                {
                    await writer.WriteAttributeStringAsync(
                        null,
                        attributeName,
                        attribute.Name.NamespaceName,
                        attribute.Value
                    ).ConfigureAwait(false);
                }
            }

            foreach (var option in Options)
            {
                if (option.Key.StartsWith("xml:"))
                {
                    await writer.WriteAttributeStringAsync(
                        null,
                        option.Key.Substring(4),
                        XNamespace.Xml.NamespaceName,
                        option.Value
                    ).ConfigureAwait(false);
                }
                else
                {
                    await writer.WriteAttributeStringAsync(null, option.Key, null, option.Value)
                        .ConfigureAwait(false);
                }
            }

            var body = GetElementBody();
            if (!string.IsNullOrEmpty(body))
            {
                await writer.WriteStringAsync(body).ConfigureAwait(false);
            }
            else
            {
                foreach (var child in Children)
                {
                    await child.WriteXml(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            await writer.WriteEndElementAsync().ConfigureAwait(false);
        }
#endif

        private static XmlWriterSettings GetXmlWriterSettings(SaveOptions saveOptions)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
           
            if ((saveOptions & SaveOptions.DisableFormatting) == 0) settings.Indent = true;
#if !NET35
            if ((saveOptions & SaveOptions.OmitDuplicateNamespaces) != 0)
                settings.NamespaceHandling |= NamespaceHandling.OmitDuplicates;
#endif
            return settings;
        }

        /// <summary>
        /// Generate XML string from TwiML object.
        /// </summary>
        public override string ToString()
        {
            return ToString(SaveOptions.None);
        }

        /// <summary>
        /// Generate XML string from TwiML object.
        /// </summary>
        /// <param name="formattingOptions">Change generated string format.</param>
        public string ToString(SaveOptions formattingOptions)
        {
            using (var writer = new Utf8StringWriter())
            {
                Save(writer, formattingOptions);
                return writer.ToString();
            }
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