using System;
using System.Collections.Generic;
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
    }
}
