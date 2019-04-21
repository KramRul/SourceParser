using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace SourceParser.BLL.Services
{
    public class FileDialogService : BaseService, IFileDialogService
    {
        public FileDialogService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task EditFileDialog()
        {
            throw new NotImplementedException();
        }

        public async Task OpenFileDialog()
        {
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.Desktop,
                CommitButtonText = "Открыть"
            };
            openPicker.FileTypeFilter.Add(".txt");
            var file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                //myTextBox.Text = await FileIO.ReadTextAsync(file);
            }
        }

        public async Task SaveFileDialog()
        {
            var savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = "New Document",
                CommitButtonText = "Сохранить"
            };
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });

            var new_file = await savePicker.PickSaveFileAsync();
            if (new_file != null)
            {
                //await FileIO.WriteTextAsync(new_file, myTextBox.Text);
            }
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
