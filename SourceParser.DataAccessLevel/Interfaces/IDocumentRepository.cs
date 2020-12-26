using SourceParser.DataAccessLevel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<List<Document>> GetAll();
        Task Update(Document item, string id);
    }
}
