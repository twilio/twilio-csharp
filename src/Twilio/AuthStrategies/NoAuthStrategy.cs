namespace Twilio.AuthStrategies
{
    public class NoAuthStrategy : AuthStrategy
    {
        public NoAuthStrategy(){}

        public override string GetAuthString()
        {
            return string.Empty;
        }

        public override bool RequiresAuthentication()
        {
            return false;
        }
    }
}
