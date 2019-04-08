using SourceParser.BLL.Services;
using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks;
using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IDocumentService _documentService = new DocumentService(new UnitOfWork());

        private StyleMod _selectedStyle;
        private DocumentMod _selectedDocument;
        private ObservableCollection<StyleMod> _styles = new ObservableCollection<StyleMod>();
        private ObservableCollection<DocumentMod> _documents = new ObservableCollection<DocumentMod>();

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

        public ApplicationViewModel()
        {
            Initialize();
        }

        public async Task Initialize()
        {
            Styles = new ObservableCollection<StyleMod>
            {
                new StyleMod {Title="Style 1"},
                new StyleMod {Title="Style 2"},
                new StyleMod {Title="Style 3"},
                new StyleMod {Title="Style 4"}
            };

            Documents = await _documentService.GetAllDocuments();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
