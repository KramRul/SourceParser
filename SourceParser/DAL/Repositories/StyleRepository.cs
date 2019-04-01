using SourceParser.DAL.Entities.Style;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    public class StyleRepository : BaseRepository<Style>, IStyleRepository
    {
        public StyleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
