using SourceParser.BLL.Services;
using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks;
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
    public sealed partial class Home : Page
    {
        private readonly IFileDialogService _fileDialogService = new FileDialogService(new UnitOfWork());
        private readonly ILinkService _linkService = new LinkService(new UnitOfWork());

        public Home()
        {
            this.InitializeComponent();
        }

        private async void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _fileDialogService.OpenFileDialog();
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
