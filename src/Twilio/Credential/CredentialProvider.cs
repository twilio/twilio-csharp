using Twilio.AuthStrategies;

namespace Twilio.Credential
{
    public abstract class CredentialProvider
    {
        protected CredentialProvider(){}
        public abstract AuthStrategy ToAuthStrategy();
    }
}
