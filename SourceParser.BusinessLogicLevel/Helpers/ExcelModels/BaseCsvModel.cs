using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.Excel
{
    public class BaseCsvModel
    {

        [CsvColumn(Name = "SKU", FieldIndex = 1)]
        public string SKU { get; set; } = Guid.NewGuid().ToString();

        [CsvColumn(Name = "Исходная ссылка", FieldIndex = 2)]
        public string SourceLink { get; set; }

        [CsvColumn(Name = "Bibl Link Class", FieldIndex = 3)]
        public string BiblLinkClass { get; set; }

        [CsvColumn(Name = "учеб.", FieldIndex = 4, CanBeNull = true)]
        public string SearchParameter0 { get; set; }

        [CsvColumn(Name = "Университет", FieldIndex = 5, CanBeNull = true)]
        public string SearchParameter1 { get; set; }

        [CsvColumn(Name = "учеб. пособие", FieldIndex = 6, CanBeNull = true)]
        public string SearchParameter2 { get; set; }

        [CsvColumn(Name = "довідник", FieldIndex = 7, CanBeNull = true)]
        public string SearchParameter3 { get; set; }

        [CsvColumn(Name = "tutorials", FieldIndex = 8, CanBeNull = true)]
        public string SearchParameter4 { get; set; }

        [CsvColumn(Name = "tutorial", FieldIndex = 9, CanBeNull = true)]
        public string SearchParameter5 { get; set; }

        [CsvColumn(Name = "guide", FieldIndex = 10, CanBeNull = true)]
        public string SearchParameter6 { get; set; }

        [CsvColumn(Name = "книга", FieldIndex = 11, CanBeNull = true)]
        public string SearchParameter7 { get; set; }

        [CsvColumn(Name = "Book", FieldIndex = 12, CanBeNull = true)]
        public string SearchParameter8 { get; set; }

        [CsvColumn(Name = "Volume", FieldIndex = 13, CanBeNull = true)]
        public string SearchParameter9 { get; set; }

        [CsvColumn(Name = "Т. {d}", FieldIndex = 14, CanBeNull = true)]
        public string SearchParameter10 { get; set; }

        [CsvColumn(Name = "Litres", FieldIndex = 15, CanBeNull = true)]
        public string SearchParameter11 { get; set; }

        [CsvColumn(Name = "Избранные произведения", FieldIndex = 16, CanBeNull = true)]
        public string SearchParameter12 { get; set; }

        [CsvColumn(Name = "dictionary", FieldIndex = 17, CanBeNull = true)]
        public string SearchParameter13 { get; set; }

        [CsvColumn(Name = "словарь", FieldIndex = 18, CanBeNull = true)]
        public string SearchParameter14 { get; set; }

        [CsvColumn(Name = "Т. {d}–{d}", FieldIndex = 19, CanBeNull = true)]
        public string SearchParameter15 { get; set; }

        [CsvColumn(Name = "Vols. {d}–{d}", FieldIndex = 20, CanBeNull = true)]
        public string SearchParameter16 { get; set; }

        [CsvColumn(Name = "Vol. {d}", FieldIndex = 21, CanBeNull = true)]
        public string SearchParameter17 { get; set; }

        [CsvColumn(Name = "Ред.", FieldIndex = 22, CanBeNull = true)]
        public string SearchParameter18 { get; set; }

        [CsvColumn(Name = "Ed.", FieldIndex = 23, CanBeNull = true)]
        public string SearchParameter19 { get; set; }

        [CsvColumn(Name = "Eds.", FieldIndex = 24, CanBeNull = true)]
        public string SearchParameter20 { get; set; }

        [CsvColumn(Name = "doi", FieldIndex = 25, CanBeNull = true)]
        public string SearchParameter21 { get; set; }

        [CsvColumn(Name = "[CD]", FieldIndex = 26, CanBeNull = true)]
        public string SearchParameter22 { get; set; }

        [CsvColumn(Name = "http://www.{l}", FieldIndex = 27, CanBeNull = true)]
        public string SearchParameter23 { get; set; }

        [CsvColumn(Name = "http://{l}", FieldIndex = 28, CanBeNull = true)]
        public string SearchParameter24 { get; set; }

        [CsvColumn(Name = "№{d}", FieldIndex = 29, CanBeNull = true)]
        public string SearchParameter25 { get; set; }

        [CsvColumn(Name = "№ {d}", FieldIndex = 30, CanBeNull = true)]
        public string SearchParameter26 { get; set; }

        [CsvColumn(Name = "{d}(d)", FieldIndex = 31, CanBeNull = true)]
        public string SearchParameter27 { get; set; }

        [CsvColumn(Name = "{d}(Suppl. {d})", FieldIndex = 32, CanBeNull = true)]
        public string SearchParameter28 { get; set; }

        [CsvColumn(Name = "No. {d}", FieldIndex = 33, CanBeNull = true)]
        public string SearchParameter29 { get; set; }

        [CsvColumn(Name = "[Спец. выпуск]", FieldIndex = 34, CanBeNull = true)]
        public string SearchParameter30 { get; set; }

        [CsvColumn(Name = "[Special issue]", FieldIndex = 35, CanBeNull = true)]
        public string SearchParameter31 { get; set; }

        [CsvColumn(Name = "[Cпец. раздел]", FieldIndex = 36, CanBeNull = true)]
        public string SearchParameter32 { get; set; }

        [CsvColumn(Name = "[Special section]", FieldIndex = 37, CanBeNull = true)]
        public string SearchParameter33 { get; set; }

        [CsvColumn(Name = "тез.", FieldIndex = 38, CanBeNull = true)]
        public string SearchParameter34 { get; set; }

        [CsvColumn(Name = "материалы", FieldIndex = 39, CanBeNull = true)]
        public string SearchParameter35 { get; set; }

        [CsvColumn(Name = "конф.", FieldIndex = 40, CanBeNull = true)]
        public string SearchParameter36 { get; set; }

        [CsvColumn(Name = "Conference", FieldIndex = 41, CanBeNull = true)]
        public string SearchParameter37 { get; set; }

        [CsvColumn(Name = "[Электронный ресурс]", FieldIndex = 42, CanBeNull = true)]
        public string SearchParameter38 { get; set; }

        [CsvColumn(Name = "Режим доступа", FieldIndex = 43, CanBeNull = true)]
        public string SearchParameter39 { get; set; }

        [CsvColumn(Name = "www/ URL", FieldIndex = 44, CanBeNull = true)]
        public string SearchParameter40 { get; set; }

        [CsvColumn(Name = "Загл. с экрана", FieldIndex = 45, CanBeNull = true)]
        public string SearchParameter41 { get; set; }

        [CsvColumn(Name = "интеракт. учеб.", FieldIndex = 46, CanBeNull = true)]
        public string SearchParameter42 { get; set; }

        [CsvColumn(Name = "(CD-ROM)", FieldIndex = 47, CanBeNull = true)]
        public string SearchParameter43 { get; set; }

        [CsvColumn(Name = "Загл. с этикетки диска", FieldIndex = 48, CanBeNull = true)]
        public string SearchParameter44 { get; set; }

        [CsvColumn(Name = "сб. науч. тр.", FieldIndex = 49, CanBeNull = true)]
        public string SearchParameter45 { get; set; }

        [CsvColumn(Name = "Set", FieldIndex = 50, CanBeNull = true)]
        public string SearchParameter46 { get; set; }

        [CsvColumn(Name = "Сборник науч. трудов", FieldIndex = 51, CanBeNull = true)]
        public string SearchParameter47 { get; set; }

        [CsvColumn(Name = "ГОСТ", FieldIndex = 52, CanBeNull = true)]
        public string SearchParameter48 { get; set; }

        [CsvColumn(Name = "Инструкция", FieldIndex = 53, CanBeNull = true)]
        public string SearchParameter49 { get; set; }

        [CsvColumn(Name = "Устав", FieldIndex = 54, CanBeNull = true)]
        public string SearchParameter50 { get; set; }

        [CsvColumn(Name = "Конституция", FieldIndex = 55, CanBeNull = true)]
        public string SearchParameter51 { get; set; }

        [CsvColumn(Name = "Constitution", FieldIndex = 56, CanBeNull = true)]
        public string SearchParameter52 { get; set; }

        [CsvColumn(Name = "отчет", FieldIndex = 57, CanBeNull = true)]
        public string SearchParameter53 { get; set; }

        [CsvColumn(Name = "Report", FieldIndex = 58, CanBeNull = true)]
        public string SearchParameter54 { get; set; }

        [CsvColumn(Name = "дис.", FieldIndex = 59, CanBeNull = true)]
        public string SearchParameter55 { get; set; }

        [CsvColumn(Name = "dissertation", FieldIndex = 60, CanBeNull = true)]
        public string SearchParameter56 { get; set; }

        [CsvColumn(Name = "автореф.", FieldIndex = 61, CanBeNull = true)]
        public string SearchParameter57 { get; set; }

        [CsvColumn(Name = "диплом.", FieldIndex = 62, CanBeNull = true)]
        public string SearchParameter58 { get; set; }

        [CsvColumn(Name = "магистра", FieldIndex = 63, CanBeNull = true)]
        public string SearchParameter59 { get; set; }

        [CsvColumn(Name = "Master’s", FieldIndex = 64, CanBeNull = true)]
        public string SearchParameter60 { get; set; }

        [CsvColumn(Name = "Doctoral dissertation", FieldIndex = 65, CanBeNull = true)]
        public string SearchParameter61 { get; set; }

        [CsvColumn(Name = "Master’s thesis", FieldIndex = 66, CanBeNull = true)]
        public string SearchParameter62 { get; set; }

        [CsvColumn(Name = "Dissertation Abstracts", FieldIndex = 67, CanBeNull = true)]
        public string SearchParameter63 { get; set; }

        [CsvColumn(Name = "автореф.", FieldIndex = 68, CanBeNull = true)]
        public string SearchParameter64 { get; set; }

        [CsvColumn(Name = "патентообладатель", FieldIndex = 69, CanBeNull = true)]
        public string SearchParameter65 { get; set; }

        [CsvColumn(Name = "{d,7}", FieldIndex = 70, CanBeNull = true)]
        public string SearchParameter66 { get; set; }

        [CsvColumn(Name = "В кн.", FieldIndex = 71, CanBeNull = true)]
        public string SearchParameter67 { get; set; }

        [CsvColumn(Name = "In:", FieldIndex = 72, CanBeNull = true)]
        public string SearchParameter68 { get; set; }

        [CsvColumn(Name = "[Abstract]", FieldIndex = 73, CanBeNull = true)]
        public string SearchParameter69 { get; set; }
    }
}
