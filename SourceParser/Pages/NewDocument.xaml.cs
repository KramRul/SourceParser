using SourceParser.ViewModel;
using System;
using System.Collections.Generic;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace SourceParser.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewDocument : Page
    {
        public NewDocument()
        {
            this.InitializeComponent();
        }

        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();

            TextBlock NameOfStyle = new TextBlock();
            NameOfStyle.Text = "Название документа";
            NameOfStyle.Margin = new Thickness(10);

            TextBox NameOfDocTextBlock = new TextBox();
            NameOfDocTextBlock.MaxLength = 255;

            RelativePanel relativePanel = new RelativePanel();
            relativePanel.FlowDirection = FlowDirection.LeftToRight;
            relativePanel.HorizontalAlignment = HorizontalAlignment.Stretch;
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
                (DataContext as ApplicationViewModel).Documents.Add(new Models.DocumentMod() { Title = NameOfDocTextBlock.Text });
            }
            else if (result == ContentDialogResult.Secondary)
            {
                //header.Text = "Отмена действия";
            }
        }
    }
}
