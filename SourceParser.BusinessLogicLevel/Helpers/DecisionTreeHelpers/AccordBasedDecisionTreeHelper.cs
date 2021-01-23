using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Filters;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers
{
    public class AccordBasedDecisionTreeHelper<T> : IDecisionTreeHelper<T>
    {
        private DecisionTree DecisionTree { get; set; }
        private Codification<T> Codebook { get; set; }
        private DataTable Data { get; set; }

        public void Init(string dataTableName, int classCount, List<DataColumn> columns, List<string[]> rows, List<BaseAttribute<T>> attributes)
        {
            var data = new DataTable(dataTableName);

            data.Columns.AddRange(columns.ToArray());

            foreach (var row in rows)
            {
                data.Rows.Add(row);
            }

            var codebook = new Codification<T>(data);

            var decisionVariables = new List<DecisionVariable>();

            foreach (var attribute in attributes)
            {
                decisionVariables.Add(new DecisionVariable(attribute.Name, attribute.Symbols));
            }

            var tree = new DecisionTree(decisionVariables, classCount);

            DecisionTree = tree;
            Codebook = codebook;
            Data = data;
        }

        public void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn)
        {
            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(DecisionTree);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = Codebook.Apply(Data);

            var columnNames = attributeColumns.Select(attribute => attribute.Name).ToArray();
            int[][] inputs = symbols.ToJagged<int>(columnNames);
            int[] outputs = symbols.ToJagged<int>(outputAttributeColumn.Name).GetColumn(0);

            // Learn the training instances!
            DecisionTree = id3learning.Learn(inputs, outputs);
        }

        public string Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn)
        {
            var columnNames = attributes.Select(attribute => attribute.Name).ToArray();
            var values = attributes.Select(attribute => attribute.Value).ToArray();
            int[] query = Codebook.Transform(columnNames, values);

            int output = DecisionTree.Decide(query);

            var answer = Codebook.Revert(attributeColumn.Name, output);

            return answer.ToString();
        }

        public void Compile(DecisionTree tree)
        {
            var expression = tree.ToExpression();

            // Compiles the expression to IL
            var func = expression.Compile();
        }
    }
}
