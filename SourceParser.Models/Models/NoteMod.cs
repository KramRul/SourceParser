using SourceParser.DataAccessLevel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.Models.Models
{
    public class NoteMod : INotifyPropertyChanged
    {
        private string _id;
        private string _value;
        private string _documentId;
        private Document _document;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public string DocumentId
        {
            get => _documentId;
            set
            {
                _documentId = value;
                OnPropertyChanged("DocumentId");
            }
        }

        public Document Document
        {
            get => _document;
            set
            {
                _document = value;
                OnPropertyChanged("Document");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
