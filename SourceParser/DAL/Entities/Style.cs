using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities.Style
{
    public class Style : BaseEntity
    {
        public string EtAl { get; set; } = " ";//вместо "и др." сделали пустое место
        public int EtAlMax { get; set; } = 2;//макс колво авторов которое может быть указано, если больше ставится "и др"

        public string PageRangeDelimiter { get; set; } = "-";//короткое тире (дефис) для диапазона страниц вместо обычного тире

        public string TitleId { get; set; }
        [ForeignKey("TitleId")]
        public Title Title { get; set; }

        public string AuthorFirstId { get; set; }
        [ForeignKey("AuthorFirstId")]
        public AuthorFirst AuthorFirst { get; set; }

        public string AuthorSecondId { get; set; }
        [ForeignKey("AuthorSecondId")]
        public AuthorSecond AuthorSecond { get; set; }

        public string WebdocId { get; set; }
        [ForeignKey("WebdocId")]
        public Webdoc Webdoc { get; set; }

        public string PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public string PublishuniverId { get; set; }
        [ForeignKey("PublishuniverId")]
        public PublishUniver Publishuniver { get; set; }

        public string YearDateStyleId { get; set; }
        [ForeignKey("YearDateStyleId")]
        public YearDate YearDateStyle { get; set; }

        public string PublishVolumeId { get; set; }
        [ForeignKey("PublishVolumeId")]
        public PublishVolume PublishVolume { get; set; }

        public string PagesNumberId { get; set; }
        [ForeignKey("PagesNumberId")]
        public PagesNumber PagesNumber { get; set; }

        public string PagesRangeId { get; set; }
        [ForeignKey("PagesRangeId")]
        public PagesRange PagesRange { get; set; }

        public string TitleOfConferenceId { get; set; }
        [ForeignKey("TitleOfConferenceId")]
        public TitleOfConference TitleOfConference { get; set; }
    }

    public class PagesRange : BaseEntity
    {
        public string TextId { get; set; }
        [ForeignKey("TextId")]
        public Text Text { get; set; }
    }

    public class PagesNumber : BaseEntity
    {
        public string TextId { get; set; }
        [ForeignKey("TextId")]
        public Text Text { get; set; }
    }

    public class PublishVolume : BaseEntity
    {
        public string TextId { get; set; }
        [ForeignKey("TextId")]
        public Text Text { get; set; }
    }

    public class TitleOfConference : BaseEntity
    {
        public string TextId { get; set; }
        [ForeignKey("TextId")]
        public Text Text { get; set; }
    }

    public class YearDate : BaseEntity
    {
        public string DateId { get; set; }
        [ForeignKey("DateId")]
        public Date Date { get; set; }
    }

    public class Date : BaseEntity
    {
        public List<YearDate> YearDates { get; set; }

        public List<DatePart> DateParts { get; set; }
    }

    public class DatePart : BaseEntity
    {
        public string DateId { get; set; }
        [ForeignKey("DateId")]
        public Date Date { get; set; }

        public string Name { get; set; } = "year";
    }

    public class PublishUniver : BaseEntity
    {
        public string GroupUniverId { get; set; }
        [ForeignKey("GroupUniverId")]
        public GroupUniver GroupUniver { get; set; }

        public string YearDateUniverId { get; set; }
        [ForeignKey("YearDateUniverId")]
        public YearDateUniver YearDateUniver { get; set; }
    }

    public class GroupUniver : BaseEntity
    {
        public List<PublishUniver> PublishUnivers { get; set; }

        public List<TextUniver> TextUnivers { get; set; }      
    }

    public class TextUniver : BaseEntity
    {
        public string GroupUniverId { get; set; }
        [ForeignKey("GroupUniverId")]
        public GroupUniver GroupUniver { get; set; }

        public string Value { get; set; } = "[Электронный ресурс]";
        public string Suffix { get; set; } = ". ";
        public string Prefix { get; set; } = "– Режим доступа: ";
        public string Variable { get; set; } = "URL";
    }

    public class YearDateUniver : BaseEntity
    {
        public string DateUniverId { get; set; }
        [ForeignKey("DateUniverId")]
        public DateUniver DateUniver { get; set; }
    }

    public class DateUniver : BaseEntity
    {
        public List<YearDateUniver> YearDateUnivers { get; set; }

        public List<DatePartUniver> DatePartUnivers { get; set; }
    }

    public class DatePartUniver : BaseEntity
    {
        public string DateUniverId { get; set; }
        [ForeignKey("DateUniverId")]
        public DateUniver DateUniver { get; set; }
        public string NameUniver { get; set; } = "year";
    }

    public class Publisher : BaseEntity
    {
        public string GroupPublisherId { get; set; }
        [ForeignKey("GroupPublisherId")]
        public GroupPublisher GroupPublisher { get; set; }
        public string YearDatePublisherId { get; set; }
        [ForeignKey("YearDatePublisherId")]
        public YearDatePublisher YearDatePublisher { get; set; }
    }

    public class GroupPublisher : BaseEntity
    {
        public List<Publisher> Publishers { get; set; }

        public List<TextPublisher> TextPublishers { get; set; }
    }

    public class TextPublisher : BaseEntity
    {
        public string GroupPublisherId { get; set; }
        [ForeignKey("GroupPublisherId")]
        public GroupPublisher GroupPublisher { get; set; }
        public string Value { get; set; } = "[Электронный ресурс]";
        public string Suffix { get; set; } = ". ";
        public string Prefix { get; set; } = "– Режим доступа: ";
        public string Variable { get; set; } = "URL";
    }

    public class YearDatePublisher : BaseEntity
    {
        public string DatePublisherId { get; set; }
        [ForeignKey("DatePublisherId")]
        public DatePublisher DatePublisher { get; set; }
    }

    public class DatePublisher : BaseEntity
    {
        public List<YearDatePublisher> YearDatePublishers { get; set; }

        public List<DatePartPublisher> DatePartPublishers { get; set; }
    }

    public class DatePartPublisher : BaseEntity
    {
        public string DatePublisherId { get; set; }
        [ForeignKey("DatePublisherId")]
        public DatePublisher DatePublisher { get; set; }
        public string NamePublisher { get; set; } = "year";
    }

    public class Webdoc : BaseEntity
    {
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }

    public class Group : BaseEntity
    {
        public List<Webdoc> Webdocs { get; set; }

        public List<Text> Texts { get; set; }
    }

    public class Text : BaseEntity
    {
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public string Value { get; set; } = "[Электронный ресурс]";
        public string Suffix { get; set; } = ". ";
        public string Prefix { get; set; } = "– Режим доступа: ";
    }

    public class AuthorSecond : BaseEntity
    {
        public string LabelId { get; set; }
        [ForeignKey("LabelId")]
        public Label Label { get; set; }
        public string NameId { get; set; }
        [ForeignKey("NameId")]
        public Name Name { get; set; }
    }

    public class AuthorFirst : BaseEntity
    {
        public string LabelId { get; set; }
        [ForeignKey("LabelId")]
        public Label Label { get; set; }
        public string NameId { get; set; }
        [ForeignKey("NameId")]
        public Name Name { get; set; }
    }

    public class Name : BaseEntity
    {
        public string InitializeWith { get; set; } = ".";
        public string Delimiter { get; set; } = ", ";
    }

    public class Label : BaseEntity
    {
        public string Form { get; set; } = "short";
        public string Prefix { get; set; } = ", ";
        public string Suffix { get; set; } = ".";
    }

    public class Title : BaseEntity
    {
        public string Value { get; set; } = "";
        public string TextId { get; set; }
        [ForeignKey("TextId")]
        public Text Text { get; set; }
    }
}
