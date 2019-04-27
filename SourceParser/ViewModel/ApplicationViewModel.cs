using SourceParser.BLL.Services;
using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks;
using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IDocumentService _documentService = new DocumentService(new UnitOfWork());
        private readonly IStyleService _styleService = new StyleService(new UnitOfWork());
        private readonly INoteService _noteService = new NoteService(new UnitOfWork());

        private StyleMod _selectedStyle;
        private DocumentMod _selectedDocument;
        private NoteMod _selectedNote = new NoteMod();
        private ObservableCollection<StyleMod> _styles = new ObservableCollection<StyleMod>();
        private ObservableCollection<DocumentMod> _documents = new ObservableCollection<DocumentMod>();
        private ObservableCollection<NoteMod> _notes = new ObservableCollection<NoteMod>();

        public ObservableCollection<StyleMod> Styles
        {
            get => _styles;          
            set
            {
                _styles = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DocumentMod> Documents
        {
            get => _documents;
            set
            {
                _documents = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NoteMod> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public DocumentMod SelectedDocument
        {
            get { return _selectedDocument; }
            set
            {
                _selectedDocument = value;
                OnPropertyChanged("SelectedDocument");
            }
        }

        public StyleMod SelectedStyle
        {
            get { return _selectedStyle; }
            set
            {
                _selectedStyle = value;
                OnPropertyChanged("SelectedStyle");
            }
        }

        public NoteMod SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public ApplicationViewModel()
        {
            Initialize();
        }

        public async Task Initialize()
        {
            try
            {
                Documents = await _documentService.GetAllDocuments();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
            try
            {
                Notes = await _noteService.GetAllByDocumentId(SelectedDocument.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
            try
            {
                Styles = await _styleService.GetAllStyles();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}\r\nSource: { ex.Source}\r\nTarget Site Name: { ex.TargetSite.Name}\r\n{ ex.StackTrace}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
