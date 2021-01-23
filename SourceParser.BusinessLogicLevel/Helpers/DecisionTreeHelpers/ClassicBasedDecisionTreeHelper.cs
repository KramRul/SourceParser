using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models.ClassicBased;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers
{
    public class ClassicBasedDecisionTreeHelper<T> : IDecisionTreeHelper<T>
    {
        private Tree DecisionTree { get; set; }
        private DataTable Data { get; set; }

        public string Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn)
        {
            var valuesForQuery = new Dictionary<string, string>();
            foreach (var attribute in attributes)
            {
                valuesForQuery.Add(attribute.Name, attribute.Value.ToString());
            }
            var result = Tree.CalculateResult(DecisionTree.Root, valuesForQuery, "");
            return result;
        }

        public void Init(string dataTableName, int classCount, List<DataColumn> columns, List<string[]> rows, List<BaseAttribute<T>> attributes)
        {
            DecisionTree = new Tree();
            var data = new DataTable(dataTableName);

            data.Columns.AddRange(columns.ToArray());

            foreach (var row in rows)
            {
                data.Rows.Add(row);
            }

            Data = data;
        }

        public void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn)
        {
            DecisionTree.Root = Tree.Learn(Data, "");
        }
    }
}
