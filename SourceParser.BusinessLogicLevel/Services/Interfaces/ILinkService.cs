using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services.Interfaces
{
    public interface ILinkService
    {
        Task<ObservableCollection<LinkMod>> GetAll();
        Task<ObservableCollection<LinkMod>> GetAllByDocumentId(string docId);
        Task<ObservableCollection<LinkMod>> GetAllFromLines(List<string> lines);
        Task DeleteLink(LinkMod note);
        Task UpdateLink(LinkMod note, DocumentMod document, StyleMod style, string value);
        Task CreateLink(DocumentMod document, StyleMod style, string value);
    }
}
