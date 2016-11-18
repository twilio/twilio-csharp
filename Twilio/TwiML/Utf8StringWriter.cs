using System.IO;
using System.Text;

namespace Twilio.TwiML
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}