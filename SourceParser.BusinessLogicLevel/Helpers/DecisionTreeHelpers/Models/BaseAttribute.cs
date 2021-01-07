using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models
{
    public class BaseAttribute<T>
    {
        public string Name { get; set; }
        public int Symbols { get; set; }
        public T Value { get; set; }
    }
}
