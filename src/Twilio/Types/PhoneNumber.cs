namespace Twilio.Types
{
    /// <summary>
    /// Phone number endpoint
    /// </summary>
    public class PhoneNumber : IEndpoint
    {
        private readonly string _number;

        /// <summary>
        /// Create a new PhoneNumber
        /// </summary>
        /// <param name="number">Phone number</param>
        public PhoneNumber(string number)
        {
            _number = number;
        }

        /// <summary>
        /// Add implicit constructor for PhoneNumber to make it assignable from string
        /// </summary>
        /// <param name="number">Phone number</param>
        /// <returns></returns>
        public static implicit operator PhoneNumber(string number)
        {
            return new PhoneNumber(number);
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _number;
        }
    }
}

