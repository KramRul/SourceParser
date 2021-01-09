using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using SourceParser.BusinessLogicLevel.Services;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.TestAlgoritms.Tests
{
    public class DTTest
    {
        private readonly IDecisionTreeService<string> _accordBasedDecisionTreeService = new DecisionTreeService<string>(new UnitOfWork(), new AccordBasedDecisionTreeHelper<string>());
        private readonly IDecisionTreeService<string> _listBasedDecisionTreeService = new DecisionTreeService<string>(new UnitOfWork(), new ListBasedDecisionTreeHelper<string>());
        private readonly IDecisionTreeService<string> _classicBasedDecisionTreeService = new DecisionTreeService<string>(new UnitOfWork(), new ClassicBasedDecisionTreeHelper<string>());

        public void Test()
        {
            TestAccordBasedDecisionTree();
            TestListBasedDecisionTree();
            TestClassicBasedDecisionTree();
        }

        public void TestAccordBasedDecisionTree()
        {
            var columns = new List<DataColumn>()
            {
                new DataColumn("Day"),
                new DataColumn("Outlook"),
                new DataColumn("Temperature"),
                new DataColumn("Humidity"),
                new DataColumn("Wind"),
                new DataColumn("PlayTennis")
            };

            var rows = new List<string[]>
            {
                new string[] { "D1", "Sunny", "Hot", "High", "Weak", "No" },
                new string[] { "D2", "Sunny", "Hot", "High", "Strong", "No" },
                new string[] { "D3", "Overcast", "Hot", "High", "Weak", "Yes" },
                new string[] { "D4", "Rain", "Mild", "High", "Weak", "Yes" },
                new string[] { "D5", "Rain", "Cool", "Normal", "Weak", "Yes" },
                new string[] { "D6", "Rain", "Cool", "Normal", "Strong", "No" },
                new string[] { "D7", "Overcast", "Cool", "Normal", "Strong", "Yes" },
                new string[] { "D8", "Sunny", "Mild", "High", "Weak", "No" },
                new string[] { "D9", "Sunny", "Cool", "Normal", "Weak", "Yes" },
                new string[] { "D10", "Rain", "Mild", "Normal", "Weak", "Yes" },
                new string[] { "D11", "Sunny", "Mild", "Normal", "Strong", "Yes" },
                new string[] { "D12", "Overcast", "Mild", "High", "Strong", "Yes" },
                new string[] { "D13", "Overcast", "Hot", "Normal", "Weak", "Yes" },
                new string[] { "D14", "Rain", "Mild", "High", "Strong", "No" }
            };

            var attributes = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "Outlook" , Symbols = 3 },// 3 possible values (Sunny, overcast, rain)
                new BaseAttribute<string>() { Name = "Temperature" , Symbols = 3 },// 3 possible values (Hot, mild, cool)  
                new BaseAttribute<string>() { Name = "Humidity" , Symbols = 2 }, // 2 possible values (High, normal)  
                new BaseAttribute<string>() { Name = "Wind" , Symbols = 2 },// 2 possible values (Weak, strong)
            };

            int classCount = 2; // 2 possible output values for playing tennis: yes or no

            _accordBasedDecisionTreeService.Init("Mitchell's Tennis Example", classCount, columns, rows, attributes);

            var outputAttributeColumn = new BaseAttribute<string>() { Name = "PlayTennis", Symbols = 2 };

            _accordBasedDecisionTreeService.Learn(attributes, outputAttributeColumn);

            var attributeNames = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "Outlook" , Value = "Sunny", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Temperature" , Value = "Hot", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Humidity" , Value = "High", Symbols = 2 },
                new BaseAttribute<string>() { Name = "Wind" , Value = "Strong", Symbols = 2 },
            };

            var answer = _accordBasedDecisionTreeService.Decide(attributeNames, outputAttributeColumn); // answer will be "No".
        }

        public void TestListBasedDecisionTree()
        {
            var columns = new List<DataColumn>()
            {
                new DataColumn("SepalLength"),//длинна чашелистика
                new DataColumn("SepalWidth"),//ширина чашелистика
                new DataColumn("PetalLength"),//длинна лепестка
                new DataColumn("PetalWidth"),//ширина лепестка
                new DataColumn("Species")//вид растения
            };

            var rows = new List<string[]>
            {
                new string[] { "5.1", "3.5", "1.4", "0.2", "0" },// 0
                new string[] { "4.9", "3.0", "1.4", "0.2", "0" },
                new string[] { "4.7", "3.2", "1.3", "0.2", "0" },
                new string[] { "4.6", "3.1", "1.5", "0.2", "0" },
                new string[] { "5.0", "3.6", "1.4", "0.2", "0" },
                new string[] { "5.4", "3.9", "1.7", "0.4", "0" },
                new string[] { "4.6", "3.4", "1.4", "0.3", "0" },
                new string[] { "5.0", "3.4", "1.5", "0.2", "0" },
                new string[] { "4.4", "2.9", "1.4", "0.2", "0" },
                new string[] { "4.9", "3.1", "1.5", "0.1", "0" },
                new string[] { "7.0", "3.2", "4.7", "1.4", "1" },// 1
                new string[] { "6.4", "3.2", "4.5", "1.5", "1" },
                new string[] { "6.9", "3.1", "4.9", "1.5", "1" },
                new string[] { "5.5", "2.3", "4.0", "1.3", "1" },
                new string[] { "6.5", "2.8", "4.6", "1.5", "1" },
                new string[] { "5.7", "2.8", "4.5", "1.3", "1" },
                new string[] { "6.3", "3.3", "4.7", "1.6", "1" },
                new string[] { "4.9", "2.4", "3.3", "1.0", "1" },
                new string[] { "6.6", "2.9", "4.6", "1.3", "1" },
                new string[] { "5.2", "2.7", "3.9", "1.4", "1" },
                new string[] { "6.3", "3.3", "6.0", "2.5", "2" },// 2
                new string[] { "5.8", "2.7", "5.1", "1.9", "2" },
                new string[] { "7.1", "3.0", "5.9", "2.1", "2" },
                new string[] { "6.3", "2.9", "5.6", "1.8", "2" },
                new string[] { "6.5", "3.0", "5.8", "2.2", "2" },
                new string[] { "7.6", "3.0", "6.6", "2.1", "2" },
                new string[] { "4.9", "2.5", "4.5", "1.7", "2" },
                new string[] { "7.3", "2.9", "6.3", "1.8", "2" },
                new string[] { "6.7", "2.5", "5.8", "1.8", "2" },
                new string[] { "7.2", "3.6", "6.1", "2.5", "2" }
            };

            var attributes = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "SepalLength" },
                new BaseAttribute<string>() { Name = "SepalWidth" },
                new BaseAttribute<string>() { Name = "PetalLength" },
                new BaseAttribute<string>() { Name = "PetalWidth" },
            };

            int classCount = 3;

            _listBasedDecisionTreeService.Init(String.Empty, 3, columns, rows, attributes);
            
            //dt.Show();  // show all nodes in tree

            var outputAttributeColumn = new BaseAttribute<string>() { Name = "Species" };

            _accordBasedDecisionTreeService.Learn(attributes, outputAttributeColumn);

            //double acc = dt.Accuracy(dataX, dataY);
            var attributeNames = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "SepalLength" , Value = "6.0" },
                new BaseAttribute<string>() { Name = "SepalWidth" , Value = "2.0" },
                new BaseAttribute<string>() { Name = "PetalLength" , Value = "3.0" },
                new BaseAttribute<string>() { Name = "PetalWidth" , Value = "4.0" },
            };

            var answer = _accordBasedDecisionTreeService.Decide(attributeNames, outputAttributeColumn); // answer will be "No".
        }

        public void TestClassicBasedDecisionTree()
        {

        }
    }
}
