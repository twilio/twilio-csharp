namespace Twilio.AuthStrategies
{
    public abstract class AuthStrategy
    {
        protected AuthStrategy(){}

        public abstract string GetAuthString();

        public abstract bool RequiresAuthentication();
    }
}