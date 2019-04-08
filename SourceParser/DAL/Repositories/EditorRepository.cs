using SourceParser.DAL.Entities;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    public class EditorRepository : BaseRepository<Editor>, IEditorRepository
    {
        public EditorRepository() : base()
        {
        }
    }
}
