using System;
using System.Text;

namespace Twilio.AuthStrategies
{
    public class BasicAuthStrategy : AuthStrategy
    {
        private string username;
        private string password;

        public BasicAuthStrategy(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string GetAuthString()
        {
            var credentials = username + ":" + password;
            var encoded = System.Text.Encoding.UTF8.GetBytes(credentials);
            var finalEncoded = Convert.ToBase64String(encoded);
            return $"Basic {finalEncoded}";
        }

        public override bool RequiresAuthentication()
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            var that = (BasicAuthStrategy)obj;
            return username == that.username && password == that.password;
        }

        public override int GetHashCode()
        {
            int hash = 17;
           hash = hash * 31 + (username != null ? username.GetHashCode() : 0);
           hash = hash * 31 + (password != null ? password.GetHashCode() : 0);
           return hash;
        }

    }
}
