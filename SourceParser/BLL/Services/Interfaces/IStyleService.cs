using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services.Interfaces
{
    public interface IStyleService
    {
        Task<ObservableCollection<StyleMod>> GetAllStyles();
        Task CreateStyle(string title);
        Task UpdateStyle(StyleMod document);
        Task DeleteStyle(StyleMod document);
    }
}
