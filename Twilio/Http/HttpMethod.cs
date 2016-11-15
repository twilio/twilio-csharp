namespace Twilio.Http
{
	public class HttpMethod
	{
		public static readonly HttpMethod Get = new HttpMethod("GET");
		public static readonly HttpMethod Post = new HttpMethod("POST");
		public static readonly HttpMethod Put = new HttpMethod("PUT");
		public static readonly HttpMethod Delete = new HttpMethod("DELETE");

		private readonly string _value;

		public HttpMethod(string method)
		{
			_value = method.ToUpper();
		}

        public static implicit operator HttpMethod(string value)
        {
            return new HttpMethod(value);
        }

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

		public override int GetHashCode()
		{
			unchecked { return _value?.GetHashCode () ?? 0; }
		}

		public override string ToString()
		{
			return _value;
		}
	}
}

