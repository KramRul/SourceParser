using SourceParser.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Interfaces
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<List<Note>> GetAllByDocumentId(string docId);
        Task Update(Note item, string id);
        Task Create(Note item, string docId);
    }
}
