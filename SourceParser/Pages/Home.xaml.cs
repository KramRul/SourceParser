using SourceParser.BLL.Services;
using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks;
using SourceParser.Models;
using SourceParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace SourceParser.Pages
{
    public sealed partial class Home : Page
    {
        private readonly IFileDialogService _fileDialogService = new FileDialogService(new UnitOfWork());
        private readonly ILinkService _linkService = new LinkService(new UnitOfWork());
        private readonly IDocumentService _documentService = new DocumentService(new UnitOfWork());

        public Home()
        {
            this.InitializeComponent();

            var _enumval = Enum.GetValues(typeof(DAL.Enums.DocumentType)).Cast<DAL.Enums.DocumentType>();
            ComboBoxDocumentType.ItemsSource = _enumval.ToList();
        }

        private async void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
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

            TextBlock Message = new TextBlock
            {
                Text = "-Каждая строка файла должна содержать отдельную ссылку на источник\r\n" +
                        "-Файл содержит только ссылки и ничего более\r\n" +
                        "-Каждая ссылка должна содержать следующие маркеры для корректного распознавания ссылок:\r\n" +
                        "--%TITLE%<Название документа>#TITLE#\r\n" +
                        "--%DATE%<Дата публикации или издания>#DATE#\r\n" +
                        "--%AUTHOR%<ФИО первого автора>#AUTHOR#\r\n" +
                        "--%COAUTHOR%<ФИО остальных авторов>#COAUTHOR#\r\n" +
                        "--%PUBLISHER%<Название издательства>#PUBLISHER#\r\n" +
                        "--%ADRESSPUBL%<Адресс издательства>#ADRESSPUBL#\r\n" +
                        "--%TRANSLATOR%<ФИО переводчика>#TRANSLATOR#\r\n" +
                        "--%EDITOR%<ФИО редактора>#EDITOR#\r\n" +
                        "--%EDITION%<Издание>#EDITION#\r\n" +
                        "--%URLADRESS%<URL-адресс>#URLADRESS#\r\n" +
                        "--%LANGUAGE%<Язык>#LANGUAGE#\r\n" +
                        "--%FIRSTPAGE%<Первая страница>#FIRSTPAGE#\r\n" +
                        "--%LASTPAGE%<Вторая страница>#LASTPAGE#\r\n" +
                        "--%TITLECONF%<Название конференции>#TITLECONF#\r\n" +
                        "--%VOLUME%<Том>#VOLUME#\r\n" +
                        "--%ADDINF%<Дополнительная информация>#ADDINF#\r\n",
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
