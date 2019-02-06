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
        private StyleMod selectedStyle;

        private DocumentMod selectedDocument;

        IDialogService dialogService;
        public ObservableCollection<StyleMod> Styles { get; set; }

        public ObservableCollection<DocumentMod> Documents { get; set; }

        //private RelayCommand editCommand;
        //public RelayCommand EditCommand
        //{
        //    get
        //    {
        //        return editCommand ??
        //          (editCommand = new RelayCommand(obj =>
        //          {
        //              try
        //              {
        //                  dialogService.EditFileDialog();
        //                  /*if (dialogService.SaveFileDialog())
        //                  {
        //                      dialogService.ShowMessage("Файл сохранен");
        //                  }*/
        //              }
        //              catch (Exception ex)
        //              {
        //                  dialogService.ShowMessage(ex.Message);
        //              }
        //          }));
        //    }
        //}
        public DocumentMod SelectedDocument
        {
            get { return selectedDocument; }
            set
            {
                selectedDocument = value;
                OnPropertyChanged("SelectedDocument");
            }
        }

        public StyleMod SelectedStyle
        {
            get { return selectedStyle; }
            set
            {
                selectedStyle = value;
                OnPropertyChanged("SelectedStyle");
            }
        }

        public ApplicationViewModel(/*IDialogService dialogService*/)
        {
            //this.dialogService = dialogService;

            Styles = new ObservableCollection<StyleMod>
            {
                new StyleMod {Title="Style 1"},
                new StyleMod {Title="Style 2"},
                new StyleMod {Title="Style 3"},
                new StyleMod {Title="Style 4"}
            };

            Documents = new ObservableCollection<DocumentMod>
            {
                new DocumentMod { Title="Document 1", Edition="1", Language="1"},
                new DocumentMod { Title="Document 2", Edition="2", Language="2"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
