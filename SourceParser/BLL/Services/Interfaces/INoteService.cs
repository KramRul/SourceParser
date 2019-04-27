using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services.Interfaces
{
    public interface INoteService
    {
        Task<ObservableCollection<NoteMod>> GetAllByDocumentId(string docId);
        Task DeleteNote(NoteMod note);
        Task UpdateNote(NoteMod note);
        Task CreateNote(DocumentMod document, string value);
    }
}
