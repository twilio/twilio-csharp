namespace Twilio.Types
{
    public abstract class StringEnum
    {
        private string _value;

        protected StringEnum() {}

        protected StringEnum(string value)
        {
            _value = value;
        }

        public void FromString(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}

