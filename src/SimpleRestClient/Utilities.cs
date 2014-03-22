using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple;

namespace Simple
{
    public class Utilities
    {
        public static string EncodeParameters(IEnumerable<Parameter> parameters)
        {
            var querystring = new StringBuilder();
            foreach (var param in parameters) //.Where(p => p.Type == ParameterType.GetOrPost))
            {
                if (querystring.Length > 1)
                {
                    querystring.Append("&");
                }
                querystring.AppendFormat("{0}={1}", param.Name.UrlEncode(), param.Value.ToString().UrlEncode());
            }

            return querystring.ToString();
        }
    }
}
