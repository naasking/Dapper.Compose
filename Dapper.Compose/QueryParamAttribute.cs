using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Compose
{
    /// <summary>
    /// Decorates fields or properties with default query parameter values for query validation purposes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class QueryParamAttribute : Attribute
    {
        /// <summary>
        /// Describe a test query parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public QueryParamAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Describe a test query parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public QueryParamAttribute(string name, params object[] values)
            : this(name, values as object)
        {
        }

        /// <summary>
        /// The default value to use.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// The default parameter name.
        /// </summary>
        public string Name { get; private set; }
    }
}
