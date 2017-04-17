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
        public QueryParamAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }

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
