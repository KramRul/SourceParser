using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Entities
{
    public class Note : BaseEntity
    {
        public string Value { get; set; }

        public string DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
    }
}
