namespace Twilio.Types
{
    /// <summary>
    /// Twiml endpoint
    /// </summary>
    public class Twiml
    {
        private readonly string _twiml;

        /// <summary>
        /// Create a new Twiml
        /// </summary>
        /// <param name="twiml">Twiml</param>
        public Twiml(string twiml)
        {
            _twiml = twiml;
        }

        /// <summary>
        /// Add implicit constructor for Twiml to make it assignable from string
        /// </summary>
        /// <param name="twiml">Twiml</param>
        /// <returns></returns>
        public static implicit operator Twiml(string twiml)
        {
            return new Twiml(twiml);
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _twiml;
        }
    }
}

