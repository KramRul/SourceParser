using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces
{
    public interface IDecisionTreeHelper<T>
    {
        void Init(string dataTableName, int classCount, List<DataColumn> columns, List<string[]> rows, List<BaseAttribute<T>> attributes);

        void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn);

        string Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn);
    }
}
