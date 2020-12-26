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
    public sealed partial class NewDocument : Page
    {
        private readonly IDocumentService _documentService = new DocumentService(new UnitOfWork());

        public NewDocument()
        {
            this.InitializeComponent();

            var _enumval = Enum.GetValues(typeof(DataAccessLevel.Enums.DocumentType)).Cast<DataAccessLevel.Enums.DocumentType>();
            ComboBoxDocumentType.ItemsSource = _enumval.ToList();
        }

        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StackPanel stackPanel = new StackPanel();

                TextBlock NameOfStyle = new TextBlock
                {
                    Text = "Название документа",
                    Margin = new Thickness(10)
                };

                TextBox NameOfDocTextBlock = new TextBox
                {
                    MaxLength = 255
                };

                RelativePanel relativePanel = new RelativePanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                relativePanel.Children.Add(NameOfStyle);
                relativePanel.Children.Add(NameOfDocTextBlock);
                RelativePanel.SetAlignLeftWithPanel(NameOfStyle, true);
                RelativePanel.SetAlignRightWithPanel(NameOfDocTextBlock, true);
                RelativePanel.SetRightOf(NameOfDocTextBlock, NameOfStyle);
                stackPanel.Children.Add(relativePanel);

                ContentDialog deleteFileDialog = new ContentDialog()
                {
                    Title = "Подтверждение действия",
                    Content = stackPanel,
                    PrimaryButtonText = "ОК",
                    MaxWidth = 500,
                    SecondaryButtonText = "Отмена"
                };

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    await _documentService.CreateDocument(NameOfDocTextBlock.Text);
                    (DataContext as ApplicationViewModel).Documents = await _documentService.GetAllDocuments();
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    //header.Text = "Отмена действия";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }           
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _documentService.UpdateDocument((DataContext as ApplicationViewModel).SelectedDocument);
                (DataContext as ApplicationViewModel).Documents = await _documentService.GetAllDocuments();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }           
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _documentService.DeleteDocument((DataContext as ApplicationViewModel).SelectedDocument);
                (DataContext as ApplicationViewModel).Documents = await _documentService.GetAllDocuments();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }           
        }
    }
}
