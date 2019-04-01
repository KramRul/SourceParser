using SourceParser.DAL.Entities;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    class ReferenceRepository : BaseRepository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
