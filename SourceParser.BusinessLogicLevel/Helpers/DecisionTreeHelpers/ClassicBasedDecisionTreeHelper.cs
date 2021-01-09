using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers
{
    public class ClassicBasedDecisionTreeHelper<T> : IDecisionTreeHelper<T>
    {
        public string Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn)
        {
            throw new NotImplementedException();
        }

        public void Init(string dataTableName, int classCount, List<DataColumn> columns, List<string[]> rows, List<BaseAttribute<T>> attributes)
        {
            throw new NotImplementedException();
        }

        public void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn)
        {
            throw new NotImplementedException();
        }
    }
}
