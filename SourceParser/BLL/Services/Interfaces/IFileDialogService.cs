using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services.Interfaces
{
    public interface IFileDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        Task<List<string>> OpenFileDialog();
        Task SaveFileDialog(List<LinkMod> links); 
        Task EditFileDialog();
    }
}
