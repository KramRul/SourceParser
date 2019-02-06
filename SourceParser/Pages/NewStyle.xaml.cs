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
    public sealed partial class NewStyle : Page
    {
        public NewStyle()
        {
            this.InitializeComponent();
        }
        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();

            TextBlock NameOfStyle = new TextBlock();
            NameOfStyle.Text = "Название стиля";
            NameOfStyle.Margin = new Thickness(10);

            TextBox NameOfStyleTextBlock = new TextBox();
            NameOfStyleTextBlock.MaxLength = 255;

            RelativePanel relativePanel = new RelativePanel();
            relativePanel.FlowDirection = FlowDirection.LeftToRight;
            relativePanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            relativePanel.Children.Add(NameOfStyle);
            relativePanel.Children.Add(NameOfStyleTextBlock);
            RelativePanel.SetAlignLeftWithPanel(NameOfStyle, true);
            RelativePanel.SetAlignRightWithPanel(NameOfStyleTextBlock, true);
            RelativePanel.SetRightOf(NameOfStyleTextBlock, NameOfStyle);
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
                /*Button button = new Button()
                {
                    Content = NameOfStyleTextBlock.Text,
                    Width = 160,
                    Height = 160,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10)
                };
                Navigator.Childrens.Add(button);
                Styles.Children.Add(button);*/
                (DataContext as ApplicationViewModel).Styles.Add(new Models.StyleMod() { Title = NameOfStyleTextBlock.Text });
            }
            else if (result == ContentDialogResult.Secondary)
            {
                //header.Text = "Отмена действия";
            }
        }

        /*private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Navigator.Childrens)
            {
                if(!Styles.Children.Contains(item))
                Styles.Children.Add(item);
                var newStyle = Window.Current.Content as NewStyle;
                newStyle.Styles.Children.Add(item);
            }
        }*/
    }
}
