namespace Twilio.Types
{
    /// <summary>
    /// Enum object for strings
    /// </summary>
    public abstract class StringEnum
    {
        private string _value;

        /// <summary>
        /// Generic constructor
        /// </summary>
        protected StringEnum() {}

        /// <summary>
        /// Create from string
        /// </summary>
        /// <param name="value">String value</param>
        protected StringEnum(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Generate from string
        /// </summary>
        /// <param name="value">String value</param>
        public void FromString(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}

