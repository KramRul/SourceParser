using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks.Interfaces;
using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace SourceParser.BLL.Services
{
    public class FileDialogService : BaseService, IFileDialogService
    {
        private const string _fileName = "Links.txt";
        private readonly string _writePath = $"{Directory.GetCurrentDirectory()}\\{_fileName}";
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

        public async Task SaveFileDialog(List<LinkMod> links)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var link in links)
            {
                sb.Append(link.ToString());
            }
            var linksText = sb.ToString();
            var savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = "Saved Links",
                CommitButtonText = "Сохранить",
                DefaultFileExtension = ".txt"
            };
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });

            var new_file = await savePicker.PickSaveFileAsync();
            if (new_file != null)
            {
                await FileIO.WriteTextAsync(new_file, linksText);
            }
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        /*public async Task Create(ObservableCollection<Article> articles)
        {
            var _articles = articles.Select(article => new Models.Article()
            {
                Author = article.Author,
                Description = article.Description,
                PublishedAt = article.PublishedAt,
                Source = new Models.Source()
                {
                    Id = article.Source.Id,
                    Name = article.Source.Name
                },
                Title = article.Title,
                Url = article.Url,
                UrlToImage = article.UrlToImage
            }).ToList();

            using (StreamWriter streamWriter = new StreamWriter(_writePath, true, Encoding.Default))
            {
                foreach (var article in _articles)
                    await streamWriter.WriteLineAsync(article.ToString());
            }
        }*/
    }
}
