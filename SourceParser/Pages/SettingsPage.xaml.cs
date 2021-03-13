using SourceParser.BusinessLogicLevel.Services;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SourceParser.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private readonly Services.FileDialogService _fileDialogService = new Services.FileDialogService();
        private readonly IImportLinkDataService _importLinkDataService = new ImportLinkDataService(new UnitOfWork());

        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonImportTestSample_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var infoMessageResult = await ShowInfoMessage();
                if (infoMessageResult == ContentDialogResult.Primary)
                {
                    await _fileDialogService.OpenFileDialogСsv();
                    (DataContext as ApplicationViewModel).ImportedLinks = await _importLinkDataService.GetAllImportedLinks();
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

        private async void ShowImportedLearnLinks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame.Navigate(typeof(Pages.ImportedLearnLinksTable));
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

            TextBlock Title = new TextBlock
            {
                Text = "Вы уверены что хотите импортировать обучающий список источников?",
                Margin = new Thickness(10),
                Style = (Style)Application.Current.Resources["SubheaderTextBlockStyle"]
            };
            stackPanel.Children.Add(Title);

            var sbText = new StringBuilder();
            sbText.Append($"-Файл дожен быть в формате CSV\r\n");
            var text = sbText.ToString();
            TextBlock Message = new TextBlock
            {
                Text = sbText.ToString(),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10)
            };
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
    }
}
