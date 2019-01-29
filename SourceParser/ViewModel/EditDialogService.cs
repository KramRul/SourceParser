using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SourceParser.ViewModel
{
    public class EditDialogService : IDialogService
    {
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async void EditFileDialog()
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

            ContentDialog EditFileDialog = new ContentDialog()
            {
                Title = "Подтверждение действия",
                Content = stackPanel,
                PrimaryButtonText = "ОК",
                MaxWidth = 500,
                SecondaryButtonText = "Отмена"
            };

            ContentDialogResult result = await EditFileDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // (DataContext as ApplicationViewModel).Buttons.Add(new Models.ButtonMod() { Title = NameOfStyleTextBlock.Text });
            }
            else if (result == ContentDialogResult.Secondary)
            {
                //header.Text = "Отмена действия";

            }
        }

        public bool OpenFileDialog()
        {
            throw new NotImplementedException();
        }

        public bool SaveFileDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
