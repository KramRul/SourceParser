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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SourceParser.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewNote : Page
    {
        private readonly INoteService _noteService = new NoteService(new UnitOfWork());
        public NewNote()
        {
            this.InitializeComponent();
        }

        private async void ButtonEditOrSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DataContext as ApplicationViewModel).SelectedNote?.Document == null)
                {
                    await _noteService.CreateNote((DataContext as ApplicationViewModel).SelectedDocument, (DataContext as ApplicationViewModel).SelectedNote.Value);
                    (DataContext as ApplicationViewModel).Notes = await _noteService.GetAllByDocumentId((DataContext as ApplicationViewModel).SelectedDocument.Id);
                }
                else
                {
                    var docId = (DataContext as ApplicationViewModel).SelectedDocument.Id;
                    await _noteService.UpdateNote((DataContext as ApplicationViewModel).SelectedNote);
                    (DataContext as ApplicationViewModel).Notes = await _noteService.GetAllByDocumentId(docId);
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
                await _noteService.DeleteNote((DataContext as ApplicationViewModel).SelectedNote);
                (DataContext as ApplicationViewModel).Notes = await _noteService.GetAllByDocumentId(docId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        private async void GridOfButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var docId = (DataContext as ApplicationViewModel).SelectedDocument.Id;
                (DataContext as ApplicationViewModel).Notes = await _noteService.GetAllByDocumentId(docId);
                if ((DataContext as ApplicationViewModel).SelectedNote?.Document?.Id != docId)
                {
                    (DataContext as ApplicationViewModel).SelectedNote = new Models.NoteMod();
                }                            
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }
    }
}
