using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<ObservableCollection<DocumentMod>> GetAllDocuments();
        Task CreateDocument(string title);
        Task UpdateDocument(DocumentMod document);
        Task DeleteDocument(DocumentMod document);
    }
}
