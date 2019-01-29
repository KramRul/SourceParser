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
        private ButtonMod selectedButton;

        IDialogService dialogService;
        public ObservableCollection<ButtonMod> Buttons { get; set; }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          dialogService.EditFileDialog();
                          /*if (dialogService.SaveFileDialog())
                          {
                              dialogService.ShowMessage("Файл сохранен");
                          }*/
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public ButtonMod SelectedButton
        {
            get { return selectedButton; }
            set
            {
                selectedButton = value;
                OnPropertyChanged("SelectedButton");
            }
        }

        public ApplicationViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            Buttons = new ObservableCollection<ButtonMod>
            {
                new ButtonMod { Title="iPhone 7"},
                new ButtonMod {Title="Galaxy S7 Edge"},
                new ButtonMod {Title="Elite x3"},
                new ButtonMod {Title="Mi5S"}
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
