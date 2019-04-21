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
        Task OpenFileDialog();
        Task SaveFileDialog(); 
        Task EditFileDialog();
    }
}
