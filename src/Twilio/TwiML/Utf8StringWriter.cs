using System.IO;
using System.Text;

namespace Twilio.TwiML
{
    /// <summary>
    /// UTF8 writer
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        /// <summary>
        /// Override default encoding
        /// </summary>
        public override Encoding Encoding => Encoding.UTF8;
    }
}