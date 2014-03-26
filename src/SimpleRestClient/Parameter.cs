using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple
{
    /// <summary>
    /// Holds a single HTTP request parameter
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Name of the parameter
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value of the parameter
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Type of the parameter
        /// </summary>
        public ParameterType Type { get; set; }

        /// <summary>
        /// Return a human-readable representation of this parameter
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }
    }
}
