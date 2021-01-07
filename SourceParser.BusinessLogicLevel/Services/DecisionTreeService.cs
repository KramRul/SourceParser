using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Filters;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Interfaces;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class DecisionTreeService<T> : BaseService, IDecisionTreeService<T>
    {
        private readonly IDecisionTreeHelper<T> _helper;
        public DecisionTreeService(IBaseUnitOfWork unitOfWork, IDecisionTreeHelper<T> helper)
            : base(unitOfWork)
        {
            _helper = helper;
        }

        public void Init(string dataTableName, int classCount, List<DataColumn> columns, List<object[]> rows, List<BaseAttribute<T>> attributes)
        {
            _helper.Init(dataTableName, classCount, columns, rows, attributes);
        }

        public void Learn(List<BaseAttribute<T>> attributeColumns, BaseAttribute<T> outputAttributeColumn)
        {
            _helper.Learn(attributeColumns, outputAttributeColumn);
        }

        public T Decide(List<BaseAttribute<T>> attributes, BaseAttribute<T> attributeColumn)
        {
            return _helper.Decide(attributes, attributeColumn);
        }
    }
}
