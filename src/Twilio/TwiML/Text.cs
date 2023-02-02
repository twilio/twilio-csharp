#if !NET35
using System.Threading;
using System.Threading.Tasks;
#endif
using System.Xml;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    internal class Text : TwiML
    {
        private readonly string _content;

        internal Text(string content) : base(null)
        {
            _content = content;
        }

        protected override XNode ToXml()
        {
            return new XText(_content);
        }

#if !NET35
        protected override async Task WriteXml(XmlWriter writer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteStringAsync(_content).ConfigureAwait(false);
        }
#endif

        protected override void WriteContent(XmlWriter writer)
        {
            writer.WriteString(_content);
        }
    }
}