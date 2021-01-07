using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Filters;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Services.Interfaces
{
    public interface IDecisionTreeService<T>
    {
        void Init(string dataTableName, int classCount, List<DataColumn> columns, List<object[]> rows, List<BaseAttribute<T>> attributes);
        void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn);
        T Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn);
    }
}
