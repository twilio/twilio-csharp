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
    }
}
