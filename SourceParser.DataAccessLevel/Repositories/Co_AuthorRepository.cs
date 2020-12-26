using SourceParser.DataAccessLevel.Entities;
using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Repositories
{
    public class Co_AuthorRepository : BaseRepository<Co_Author>, ICo_AuthorRepository
    {
        public Co_AuthorRepository() : base()
        {
        }
    }
}
