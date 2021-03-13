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
using SourceParser.Models.Models;
/*using LinqToExcel;
using LinqToExcel.Query;*/
using SourceParser.DataAccessLevel;
using SourceParser.DataAccessLevel.Entities;
using System.Diagnostics;
using SourceParser.BusinessLogicLevel.Helpers.Excel;

namespace SourceParser.Services
{
    public class FileDialogService
    {
        private const string _fileName = "Links.txt";
        private readonly string _writePath = $"{Directory.GetCurrentDirectory()}\\{_fileName}";
        protected List<object> excelModel;
        protected string excelWorksheetName;
        //protected ExcelQueryable<BaseExcelModel> worksheet;

        public FileDialogService()
        {
            this.excelWorksheetName = "Import";
            excelModel = new List<object>();
        }
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task EditFileDialog()
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> OpenFileDialog()
        {
            var lines = new List<string>();
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
                var readlines = await FileIO.ReadLinesAsync(file);
                lines = new List<string>(readlines);
            }

            return lines;
        }

        public async Task OpenFileDialogСsv()
        {
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.Desktop,
                CommitButtonText = "Открыть"
            };
            openPicker.FileTypeFilter.Add(".csv");
            var file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenStreamForReadAsync();

                var excelHelper = new CsvHelper();

                excelHelper.Parse(stream);

                excelHelper.SyncDataWithDatabase();
            }
        }

        public async Task ExportFileDialog(List<LinkMod> links)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var link in links)
            {
                var sbLink = new StringBuilder();
                sbLink.Append($"%TITLE%{link.Document.Title}#TITLE#");
                sbLink.Append($"%DATE%{link.Document.Date}#DATE#");
                sbLink.Append($"%AUTHORSURNAME%{link.Document.Author.Surname}#AUTHORSURNAME#");
                sbLink.Append($"%AUTHORNAME%{link.Document.Author.Name}#AUTHORNAME#");
                sbLink.Append($"%AUTHORPATRONIMIC%{link.Document.Author.Patronymic}#AUTHORPATRONIMIC#");
                sbLink.Append($"%COAUTHOR%{link.Document.Co_Author.Name}#COAUTHOR#");
                sbLink.Append($"%PUBLISHERNAME%{link.Document.Publisher.Name}#PUBLISHERNAME#");
                sbLink.Append($"%PUBLISHERADDRESS%{link.Document.Publisher.Address}#PUBLISHERADDRESS#");
                sbLink.Append($"%TRANSLATOR%{link.Document.Translator.Name}#TRANSLATOR#");
                sbLink.Append($"%EDITOR%{link.Document.Editor.Name}#EDITOR#");
                sbLink.Append($"%EDITION%{link.Document.Edition}#EDITION#");
                sbLink.Append($"%URLADRESS%{link.Document.URLAdress}#URLADRESS#");
                sbLink.Append($"%LANGUAGE%{link.Document.Language}#LANGUAGE#");
                sbLink.Append($"%COUNTOFPAGES%{link.Document.Pages.CountOfPages}#COUNTOFPAGES#");
                sbLink.Append($"%FIRSTPAGE%{link.Document.Pages.PageFirst}#FIRSTPAGE#");
                sbLink.Append($"%LASTPAGE%{link.Document.Pages.PageLast}#LASTPAGE#");
                sbLink.Append($"%TITLECONF%{link.Document.TitleOfConference}#TITLECONF#");
                sbLink.Append($"%VOLUME%{link.Document.Volume}#VOLUME#");
                sbLink.Append($"%ADDINF%{link.Document.AdditionalInf}#ADDINF#\r\n");
                var linkAsString = sbLink.ToString();
                sb.Append(linkAsString);
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
