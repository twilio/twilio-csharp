using System;
using System.Collections.Generic;
using System.Text;
using Simple;

namespace Simple
{
    /// <summary>
    /// Utility methods
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Encodes a parameters collection as a set of form encoded values
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

    /// <summary>
    /// Helper methods for validating required values
    /// </summary>
    public class Require
    {
        /// <summary>
        /// Require a parameter to not be null
        /// </summary>
        /// <param name="argumentName">Name of the parameter</param>
        /// <param name="argumentValue">Value of the parameter</param>
        public static void Argument(string argumentName, object argumentValue)
        {
            if (argumentValue == null)
            {
                throw new ArgumentException("Argument cannot be null.", argumentName);
            }
        }
    }

    /// <summary>
    /// Helper methods for validating values
    /// </summary>
    public class Validate
    {
        /// <summary>
        /// Validate an integer value is between the specified values (exclusive of min/max)
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Exclusive minimum value</param>
        /// <param name="max">Exclusive maximum value</param>
        public static void IsBetween(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(string.Format("Value ({0}) is not between {1} and {2}.", value, min, max));
            }
        }

        /// <summary>
        /// Validate a string length
        /// </summary>
        /// <param name="value">String to be validated</param>
        /// <param name="maxSize">Maximum length of the string</param>
        public static void IsValidLength(string value, int maxSize)
        {
            if (value == null)
                return;

            if (value.Length > maxSize)
            {
                throw new ArgumentException(string.Format("String is longer than max allowed size ({0}).", maxSize));
            }
        }
    }
}

