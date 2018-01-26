using System.Net;

namespace Twilio.Types {

    public class EmptyUri : System.Uri 
    {
        public static readonly string Uri = "https://this.is.empty.url";

        public EmptyUri() : base(Uri) {}
    }

}
