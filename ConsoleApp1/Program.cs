using SourceParser.Excel;
using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<ImportLinkDataModel>();
            var excelParseUtil = new ExcelParseUtil();
            var t = excelParseUtil.Load("D:\\УНИВЕР\\6 КУРС\\МАГ РАБОТА\\Таблица обучающей выборки2.xlsx");
        }
    }
}
