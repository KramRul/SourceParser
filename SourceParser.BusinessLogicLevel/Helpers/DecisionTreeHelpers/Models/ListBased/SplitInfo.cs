using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models.ListBased
{
    public class SplitInfo  // helper struc
    {
        public int SplitCol { get; set; }
        public double SplitVal { get; set; }
        public List<int> LessRows { get; set; }
        public List<int> GreaterRows { get; set; }
    }
}
