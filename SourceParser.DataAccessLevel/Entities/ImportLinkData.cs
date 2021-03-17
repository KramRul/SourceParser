using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.DataAccessLevel.Entities
{
    public class ImportLinkData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Guid SKU { get; set; }

        //Исходная ссылка
        public string SourceLink { get; set; }

        //Bibl Link Class
        public string BiblLinkClass { get; set; }

        //учеб.
        public string SearchParameter0 { get; set; }

        //Университет
        public string SearchParameter1 { get; set; }

        //учеб. пособие
        public string SearchParameter2 { get; set; }

        //довідник
        public string SearchParameter3 { get; set; }

        //tutorials
        public string SearchParameter4 { get; set; }

        //tutorial
        public string SearchParameter5 { get; set; }

        //guide
        public string SearchParameter6 { get; set; }

        //книга
        public string SearchParameter7 { get; set; }

        //Book
        public string SearchParameter8 { get; set; }

        //Volume
        public string SearchParameter9 { get; set; }

        //Т. {d}
        public string SearchParameter10 { get; set; }

        //Litres
        public string SearchParameter11 { get; set; }

        //Избранные произведения
        public string SearchParameter12 { get; set; }

        //dictionary
        public string SearchParameter13 { get; set; }

        //словарь
        public string SearchParameter14 { get; set; }

        //Т. {d}–{d}
        public string SearchParameter15 { get; set; }

        //Vols. {d}–{d}
        public string SearchParameter16 { get; set; }

        //Vol. {d}
        public string SearchParameter17 { get; set; }

        //Ред.
        public string SearchParameter18 { get; set; }

        //Ed.
        public string SearchParameter19 { get; set; }

        //Eds.
        public string SearchParameter20 { get; set; }

        //doi
        public string SearchParameter21 { get; set; }

        //[CD]
        public string SearchParameter22 { get; set; }

        //http://www.{l}
        public string SearchParameter23 { get; set; }

        //http://{l}
        public string SearchParameter24 { get; set; }

        //№{d}
        public string SearchParameter25 { get; set; }

        //№ {d}
        public string SearchParameter26 { get; set; }

        //{d}(d)
        public string SearchParameter27 { get; set; }

        //{d}(Suppl. {d})
        public string SearchParameter28 { get; set; }

        //No. {d}
        public string SearchParameter29 { get; set; }

        //[Спец. выпуск]
        public string SearchParameter30 { get; set; }

        //[Special issue]
        public string SearchParameter31 { get; set; }

        //[Cпец. раздел]
        public string SearchParameter32 { get; set; }

        //[Special section]
        public string SearchParameter33 { get; set; }

        //тез.
        public string SearchParameter34 { get; set; }

        //материалы
        public string SearchParameter35 { get; set; }

        //конф.
        public string SearchParameter36 { get; set; }

        //Conference
        public string SearchParameter37 { get; set; }

        //[Электронный ресурс]
        public string SearchParameter38 { get; set; }

        //Режим доступа
        public string SearchParameter39 { get; set; }

        //www/ URL
        public string SearchParameter40 { get; set; }

        //Загл. с экрана
        public string SearchParameter41 { get; set; }

        //интеракт. учеб.
        public string SearchParameter42 { get; set; }

        //(CD-ROM)
        public string SearchParameter43 { get; set; }

        //Загл. с этикетки диска
        public string SearchParameter44 { get; set; }

        //сб. науч. тр.
        public string SearchParameter45 { get; set; }

        //Set
        public string SearchParameter46 { get; set; }

        //Сборник науч. трудов
        public string SearchParameter47 { get; set; }

        //ГОСТ
        public string SearchParameter48 { get; set; }

        //Инструкция
        public string SearchParameter49 { get; set; }

        //Устав
        public string SearchParameter50 { get; set; }

        //Конституция
        public string SearchParameter51 { get; set; }

        //Constitution
        public string SearchParameter52 { get; set; }

        //отчет
        public string SearchParameter53 { get; set; }

        //Report
        public string SearchParameter54 { get; set; }

        //дис.
        public string SearchParameter55 { get; set; }

        //dissertation
        public string SearchParameter56 { get; set; }

        //автореф.
        public string SearchParameter57 { get; set; }

        //диплом.
        public string SearchParameter58 { get; set; }

        //магистра
        public string SearchParameter59 { get; set; }

        //Master’s
        public string SearchParameter60 { get; set; }

        //Doctoral dissertation
        public string SearchParameter61 { get; set; }

        //Master’s thesis
        public string SearchParameter62 { get; set; }

        //Dissertation Abstracts
        public string SearchParameter63 { get; set; }

        //патентообладатель
        public string SearchParameter64 { get; set; }

        //{d,7}
        public string SearchParameter65 { get; set; }

        //В кн.
        public string SearchParameter66 { get; set; }

        //In:
        public string SearchParameter67 { get; set; }

        //[Abstract]
        public string SearchParameter68 { get; set; }
    }
}
