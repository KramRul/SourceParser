using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities.Style
{
    public class Style : BaseEntity
    {
        public string EtAl { get; set; }//вместо "и др." сделали пустое место

        public string PageRangeDelimiter { get; set; }//короткое тире (дефис) для диапазона страниц вместо обычного тире

        public Title Title { get; set; }

        public AuthorFirst AuthorFirst { get; set; }

        public AuthorSecond AuthorSecond { get; set; }

        public Webdoc Webdoc { get; set; }

        public Publisher Publisher { get; set; }

        public PublishUniver Publishuniver { get; set; }

        public YearDate YearDate { get; set; }

        public PublishVolume PublishVolume { get; set; }

        public PagesNumber PagesNumber { get; set; }

        public PagesRange PagesRange { get; set; }
    }

    public class PagesRange
    {
        public Text Text { get; set; }
    }

    public class PagesNumber
    {
        public Text Text { get; set; }
    }

    public class PublishVolume
    {
        public Text Text { get; set; }
    }

    public class YearDate
    {
        public Date Date { get; set; }
    }

    public class Date
    {
        List<DatePart> DateParts { get; set; }
    }

    public class DatePart
    {
        public string Name { get; set; } = "year";
    }

    public class PublishUniver
    {
        public Group Group { get; set; }

        public YearDate YearDate { get; set; }
    }

    public class Publisher
    {
        public Group Group { get; set; }

        public YearDate YearDate { get; set; }
    }

    public class Webdoc
    {
        public Group Group { get; set; }
    }

    public class Group
    {
        List<Text> Texts { get; set; }
    }

    public class Text
    {
        public string Value { get; set; } = "[Электронный ресурс]";
        public string Suffix { get; set; } = ". ";
        public string Prefix { get; set; } = "– Режим доступа: ";
        public string Variable { get; set; } = "URL";
    }

    public class AuthorSecond
    {
        public Label Label { get; set; }

        public Name Name { get; set; }
    }

    public class AuthorFirst
    {
        public Label Label { get; set; }

        public Name Name { get; set; }
    }

    public class Name
    {
        public string NameAsSortOrder { get; set; } = "all";
        public string SortSeparator { get; set; } = " ";
        public string InitializeWith { get; set; } = ".";
        public string Delimiter { get; set; } = ", ";
        public string DelimiterPrecedesLast { get; set; } = "always";
        public int EtAlMin { get; set; } = 2;
        public int EtAlUseFirst { get; set; } = 1;
    }

    public class Label
    {
        public string Form { get; set; } = "short";
        public string Prefix { get; set; } = ", ";
        public string Suffix { get; set; } = ".";
        public string TextCase { get; set; } = "lowercase";
        public bool StripPeriods { get; set; } = true;
    }

    public class Title
    {
        public string Value { get; set; }
    }
}
