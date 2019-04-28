using SourceParser.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Interfaces
{
    public interface IReferenceRepository : IBaseRepository<Reference>
    {
        Task<List<Reference>> GetAllByDocumentId(string docId);
        Task Update(Reference item, string id, string styleId);
        Task Create(Reference item, string docId, string styleId);
    }
}
