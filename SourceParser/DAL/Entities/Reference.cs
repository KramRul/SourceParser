using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities
{
    public class Reference : BaseEntity
    {
        public string Value { get; set; }

        public string DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        public string StyleId { get; set; }
        [ForeignKey("StyleId")]
        public Style Style { get; set; }
    }
}
