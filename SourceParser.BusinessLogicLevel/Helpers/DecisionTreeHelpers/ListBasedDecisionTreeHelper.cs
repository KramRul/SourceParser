using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models.ListBased;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers
{


    public class ListBasedDecisionTreeHelper<T> : IDecisionTreeHelper<T>
    {
        private Tree DecisionTree { get; set; }
        private double[][] DataX { get; set; }
        private int[] DataY { get; set; }

        public void Init(string dataTableName, int classCount, List<DataColumn> columns, List<string[]> rows, List<BaseAttribute<T>> attributes)
        {
            var tree = new Tree(7, classCount);

            DecisionTree = tree;

            DataX = rows.Select(row =>
            {
                var rowWithoutLastColumn = row.Take(row.Count() - 1).ToArray();
                return Array.ConvertAll(rowWithoutLastColumn, double.Parse);
            }).ToArray();

            DataY = rows.Select(row =>
            {
                var lastElement = row[row.Length - 1];
                return int.Parse(lastElement);
            }).ToArray();
        }

        public void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn)
        {
            DecisionTree.BuildTree(DataX, DataY);
        }

        public string Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn)
        {
            double[] x = attributes.Select(attr=>double.Parse(attr.Value.ToString())).ToArray();
            int predClass = DecisionTree.Predict(x, verbose: true);
            return predClass.ToString();
        }
    }
}
