using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<ObservableCollection<DocumentMod>> GetAllDocuments();
        Task<ObservableCollection<DocumentMod>> GetDocumentsInfFromLines(List<string> lines);
        Task CreateDocument(string title);
        Task CreateDocumentsRange(List<DocumentMod> documents);
        Task UpdateDocument(DocumentMod document);
        Task DeleteDocument(DocumentMod document);
    }
}
