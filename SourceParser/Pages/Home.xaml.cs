using SourceParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.BusinessLogicLevel.Services;
using SourceParser.DataAccessLevel.UnitOfWorks;
using SourceParser.Models.Models;

namespace SourceParser.Pages
{
    public sealed partial class Home : Page
    {
        private readonly Services.FileDialogService _fileDialogService = new Services.FileDialogService();
        private readonly ILinkService _linkService = new LinkService(new UnitOfWork());
        private readonly IDocumentService _documentService = new DocumentService(new UnitOfWork());

        public Home()
        {
            this.InitializeComponent();

            var _enumval = Enum.GetValues(typeof(DataAccessLevel.Enums.DocumentType)).Cast<DataAccessLevel.Enums.DocumentType>();
            ComboBoxDocumentType.ItemsSource = _enumval.ToList();
        }

        private async void ButtonImportFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var infoMessageResult = await ShowInfoMessage();
                if (infoMessageResult == ContentDialogResult.Primary)
                {
                    var lines = await _fileDialogService.OpenFileDialog();
                    var documents = await _documentService.GetDocumentsInfFromLines(lines);
                    await _documentService.CreateDocumentsRange(new List<DocumentMod>(documents));
                    foreach (var doc in documents)
                    {
                        (DataContext as ApplicationViewModel).Documents.Add(doc);
                    }                   
                }
                else if (infoMessageResult == ContentDialogResult.Secondary)
                {
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private async Task<ContentDialogResult> ShowInfoMessage()
        {
            StackPanel stackPanel = new StackPanel()
            {
            };

            TextBlock Attention = new TextBlock
            {
                Text = "Внимание!!!",
                Margin = new Thickness(10),
                Style = (Style)Application.Current.Resources["SubheaderTextBlockStyle"]
            };

            var sbText = new StringBuilder();
            sbText.Append($"-Каждая строка файла должна содержать отдельную ссылку на источник\r\n");
            sbText.Append($"-Файл содержит только ссылки и ничего более\r\n");
            sbText.Append($"-Каждая ссылка должна содержать следующие маркеры для корректного распознавания ссылок:\r\n");
            sbText.Append($"--%TITLE%<Название документа>#TITLE#\r\n");
            sbText.Append($"--%DATE%<Дата публикации или издания>#DATE#\r\n");
            sbText.Append($"--%AUTHORSURNAME%<Фамилия первого автора>#AUTHORSURNAME#\r\n");
            sbText.Append($"--%AUTHORNAME%<Имя первого автора>#AUTHORNAME#\r\n");
            sbText.Append($"--%AUTHORPATRONIMIC%<Отчество первого автора>#AUTHORPATRONIMIC#\r\n");
            sbText.Append($"--%COAUTHOR%<ФИО остальных авторов>#COAUTHOR#\r\n");
            sbText.Append($"--%PUBLISHERNAME%<Название издательства>#PUBLISHERNAME#\r\n");
            sbText.Append($"--%PUBLISHERADDRESS%<Адресс издательства>#PUBLISHERADDRESS#\r\n");
            sbText.Append($"--%TRANSLATOR%<ФИО переводчика>#TRANSLATOR#\r\n");
            sbText.Append($"--%EDITOR%<ФИО редактора>#EDITOR#\r\n");
            sbText.Append($"--%EDITION%<Издание>#EDITION#\r\n");
            sbText.Append($"--%URLADRESS%<URL-адресс>#URLADRESS#\r\n");
            sbText.Append($"--%LANGUAGE%<Язык>#LANGUAGE#\r\n");
            sbText.Append($"--%COUNTOFPAGES%<Количество страниц>#COUNTOFPAGES#\r\n");
            sbText.Append($"--%FIRSTPAGE%<Первая страница>#FIRSTPAGE#\r\n");
            sbText.Append($"--%LASTPAGE%<Вторая страница>#LASTPAGE#\r\n");
            sbText.Append($"--%TITLECONF%<Название конференции>#TITLECONF#\r\n");
            sbText.Append($"--%VOLUME%<Том>#VOLUME#\r\n");
            sbText.Append($"--%ADDINF%<Дополнительная информация>#ADDINF#\r\n");
            var text = sbText.ToString();

            TextBlock Message = new TextBlock
            {
                Text = sbText.ToString(),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10)
            };
            stackPanel.Children.Add(Attention);
            stackPanel.Children.Add(Message);

            ContentDialog fileDialog = new ContentDialog()
            {
                Title = "Подтверждение действия",
                Content = stackPanel,
                PrimaryButtonText = "ОК",
                SecondaryButtonText = "Отмена"
            };

            ContentDialogResult result = await fileDialog.ShowAsync();

            return result;
        }

        private async void ButtonExportFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var links = await _linkService.GetAll();
                await _fileDialogService.ExportFileDialog(links.ToList());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private async void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var links = await _linkService.GetAll();
                await _fileDialogService.SaveFileDialog(links.ToList());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private async void ButtonReloadLinks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (DataContext as ApplicationViewModel).Links = await _linkService.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }
    }
}
