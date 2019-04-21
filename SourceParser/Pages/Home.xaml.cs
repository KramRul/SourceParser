using SourceParser.BLL.Services;
using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks;
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

namespace SourceParser.Pages
{
    public sealed partial class Home : Page
    {
        private readonly IFileDialogService _fileDialogService = new FileDialogService(new UnitOfWork());

        public Home()
        {
            this.InitializeComponent();
        }

        private async void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            await _fileDialogService.OpenFileDialog();
        }

        private async void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            await _fileDialogService.SaveFileDialog();
        }
    }
}
