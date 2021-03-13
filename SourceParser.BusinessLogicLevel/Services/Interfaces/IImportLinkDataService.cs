using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services.Interfaces
{
    public interface IImportLinkDataService
    {
        Task<ObservableCollection<ImportLinkDataModel>> GetAllImportedLinks();
    }
}
