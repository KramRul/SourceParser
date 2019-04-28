using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services.Interfaces
{
    public interface ILinkService
    {
        Task<ObservableCollection<LinkMod>> GetAllByDocumentId(string docId);
        Task DeleteLink(LinkMod note);
        Task UpdateLink(LinkMod note);
        Task CreateLink(DocumentMod document, StyleMod style, string value);
    }
}
