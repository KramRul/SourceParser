using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities
{
    public class Style : BaseEntity
    {
        public string EtAl { get; set; }//вместо "и др." сделали пустое место

        public string PageRangeDelimiter { get; set; }//короткое тире (дефис) для диапазона страниц вместо обычного тире

        public Title Title { get; set; }

        public AuthorFirst AuthorFirst { get; set; }

        public AuthorSecond AuthorSecond { get; set; }

        public Webdoc Webdoc { get; set; }

        public publisher Publisher { get; set; }

        public PublishUniver Publishuniver { get; set; }

        public YearDate YearDate { get; set; }

        public PublishVolume PublishVolume { get; set; }

        public PagesNumber PagesNumber { get; set; }

        public PagesRange PagesRange { get; set; }
    }
}
