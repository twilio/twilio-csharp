using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (this.FirstName.Equals(user.FirstName) && this.LastName.Equals(user.LastName))
                return true;

            return false;
        }
    }
}
