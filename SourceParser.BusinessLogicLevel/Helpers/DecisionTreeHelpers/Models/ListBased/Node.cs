using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models.ListBased
{
    public class Node
    {//Небольшая примесь означает большую однородность, что лучше.
        public int NodeID { get; set; }//идентификатор узла
        public List<int> Rows { get; set; }  // содержит строки ассоциированные с узлом
        public int SplitCol { get; set; } // индекс столбца по которому происходит разделение исходных строк на два подмножетва
        public double SplitVal { get; set; } // значение по которому происходит разделение
        public int[] ClassCounts { get; set; } // индексы классов ассоциированных строк с узлом
        public int PredictedClass { get; set; } // предсказанный класс для этого узла
    }
}
