using SourceParser.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities
{
    public class Document : BaseEntity
    {
        public DocumentType Type { get; set; }
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public string Co_AuthorId { get; set; }
        [ForeignKey("Co_AuthorId")]
        public Co_Author Co_Author { get; set; }
        public string EditorId { get; set; }
        [ForeignKey("EditorId")]
        public Editor Editor { get; set; }
        public string PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public string TranslatorId { get; set; }
        [ForeignKey("TranslatorId")]
        public Translator Translator { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Edition { get; set; }

        public string URLAdress { get; set; }

        public string Language { get; set; }

        public string Pages { get; set; }

        public string Volume { get; set; }

        public string AdditionalInf { get; set; }
    }
}
