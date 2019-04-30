using SourceParser.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.Models
{
    public class LinkMod
    {
        private string _id;
        private string _value;
        private string _documentId;
        private Document _document;
        private string _styleId;
        private DAL.Entities.Style.Style _style;

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

        public string StyleId
        {
            get => _styleId;
            set
            {
                _styleId = value;
                OnPropertyChanged("StyleId");
            }
        }

        public DAL.Entities.Style.Style Style
        {
            get => _style;
            set
            {
                _style = value;
                OnPropertyChanged("Style");
            }
        }

        public override string ToString()
        {
            return $"Value: {Value}\r\n Document Title: {Document?.Title}\r\n Style Title: {Style?.Title}\r\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
