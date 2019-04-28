using SourceParser.DAL.Entities;
using SourceParser.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.Models
{
    public class DocumentMod : INotifyPropertyChanged
    {
        private string _id;
        private DocumentType _type;
        private Author _author;
        private Co_Author _co_Author;
        private Editor _editor;
        private Publisher _publisher;
        private Translator _translator;
        private string _title;
        private DateTime _date;
        private string _edition;
        private string _URLAdress;
        private string _language;
        private Page _pages;
        private string _volume;
        private string _titleOfConference;
        private string _additionalInf;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public DocumentType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public Author Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }

        public Co_Author Co_Author
        {
            get => _co_Author;
            set
            {
                _co_Author = value;
                OnPropertyChanged("Co_Author");
            }
        }

        public Editor Editor
        {
            get => _editor;
            set
            {
                _editor = value;
                OnPropertyChanged("Editor");
            }
        }

        public Publisher Publisher
        {
            get => _publisher;
            set
            {
                _publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public Translator Translator
        {
            get => _translator;
            set
            {
                _translator = value;
                OnPropertyChanged("Translator");
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string TitleOfConference
        {
            get => _titleOfConference;
            set
            {
                _titleOfConference = value;
                OnPropertyChanged("TitleOfConference");
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Edition
        {
            get => _edition;
            set
            {
                _edition = value;
                OnPropertyChanged("Edition");
            }
        }

        public string URLAdress
        {
            get => _URLAdress;
            set
            {
                _URLAdress = value;
                OnPropertyChanged("URLAdress");
            }
        }

        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }

        public Page Pages
        {
            get => _pages;
            set
            {
                _pages = value;
                OnPropertyChanged("Pages");
            }
        }

        public string Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public string AdditionalInf
        {
            get => _additionalInf;
            set
            {
                _additionalInf = value;
                OnPropertyChanged("AdditionalInf");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
