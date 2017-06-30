using System;

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

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(GetType()))
            {
                return false;
            }

            var o = (StringEnum) Convert.ChangeType(obj, GetType());
            if (o == null)
            {
                return false;
            }

            return o._value.Equals(_value);
        }

        public static bool operator ==(StringEnum a, StringEnum b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            
            return a.Equals(b);
        }

        public static bool operator!=(StringEnum a, StringEnum b)
        {
            return !(a == b);
        }

    }
}

