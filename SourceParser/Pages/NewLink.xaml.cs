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
    public sealed partial class NewLink : Page
    {
        private readonly ILinkService _linkService = new LinkService(new UnitOfWork());
        public NewLink()
        {
            this.InitializeComponent();
        }

        private async void GridOfButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var docId = (DataContext as ApplicationViewModel).SelectedDocument.Id;
                (DataContext as ApplicationViewModel).Links = await _linkService.GetAllByDocumentId(docId);
                if ((DataContext as ApplicationViewModel).SelectedLink?.Document?.Id != docId)
                {
                    (DataContext as ApplicationViewModel).SelectedLink = new Models.LinkMod();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private async void ButtonEditOrSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DataContext as ApplicationViewModel).SelectedLink?.Document == null)
                {
                    await _linkService.CreateLink(
                        (DataContext as ApplicationViewModel).SelectedDocument, 
                        (DataContext as ApplicationViewModel).SelectedStyle, 
                        (DataContext as ApplicationViewModel).SelectedLink.Value);
                    (DataContext as ApplicationViewModel).Links = await _linkService.GetAllByDocumentId(
                        (DataContext as ApplicationViewModel).SelectedDocument.Id);
                }
                else
                {
                    var docId = (DataContext as ApplicationViewModel).SelectedDocument.Id;
                    await _linkService.UpdateLink(
                        (DataContext as ApplicationViewModel).SelectedLink, 
                        (DataContext as ApplicationViewModel).SelectedDocument, 
                        (DataContext as ApplicationViewModel).SelectedStyle, 
                        (DataContext as ApplicationViewModel).SelectedLink.Value);
                    (DataContext as ApplicationViewModel).Links = await _linkService.GetAllByDocumentId(docId);
                }
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
                var docId = (DataContext as ApplicationViewModel).SelectedNote.DocumentId;
                await _linkService.DeleteLink((DataContext as ApplicationViewModel).SelectedLink);
                (DataContext as ApplicationViewModel).Links = await _linkService.GetAllByDocumentId(docId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private void GridOfStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                (DataContext as ApplicationViewModel).SelectedLink.Value = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }
    }
}
