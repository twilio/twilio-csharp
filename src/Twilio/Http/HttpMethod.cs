namespace Twilio.Http
{
    /// <summary>
    /// Represents an HTTP Method
    /// </summary>
    public class HttpMethod
    {
        /// <summary>
        /// Constant for GET method
        /// </summary>
        public static readonly HttpMethod Get = new HttpMethod("GET");
        
        /// <summary>
        /// Constant for POST method
        /// </summary>
        public static readonly HttpMethod Post = new HttpMethod("POST");
        
        /// <summary>
        /// Constant for PUT method
        /// </summary>
        public static readonly HttpMethod Put = new HttpMethod("PUT");
        
        /// <summary>
        /// Constant for DELETE method
        /// </summary>
        public static readonly HttpMethod Delete = new HttpMethod("DELETE");

        private readonly string _value;

        /// <summary>
        /// Create a method from a string
        /// </summary>
        /// <param name="method">Method name</param>
        public HttpMethod(string method)
        {
            _value = method.ToUpper();
        }

        /// <summary>
        /// Convert from string to HttpMethod
        /// </summary>
        /// <param name="value">value to convert</param>
        public static implicit operator HttpMethod(string value)
        {
            return new HttpMethod(value);
        }

        /// <summary>
        /// Compare HttpMethod
        /// </summary>
        /// <param name="obj">object to compare with</param>
        /// <returns>true if the HttpMethod are equal; false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(HttpMethod))
            {
                return false;
            }

            var other = (HttpMethod)obj;
            return _value == other._value;
        }

        /// <summary>
        /// Get the hash code of the HttpMethod
        /// </summary>
        /// <returns>the hash code of the HttpMethod</returns>
        public override int GetHashCode()
        {
            unchecked { return _value?.GetHashCode () ?? 0; }
        }

        /// <summary>
        /// Get the string representation of the HttpMethod
        /// </summary>
        /// <returns>string representation of the HttpMethod</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}

