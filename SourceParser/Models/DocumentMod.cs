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
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private string edition;
        public string Edition
        {
            get { return edition; }
            set
            {
                edition = value;
                OnPropertyChanged("Edition");
            }
        }

        private string urlAdress;
        public string URLAdress
        {
            get { return urlAdress; }
            set
            {
                urlAdress = value;
                OnPropertyChanged("URLAdress");
            }
        }

        private string language;
        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                OnPropertyChanged("Language");
            }
        }

        private string pages;
        public string Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                OnPropertyChanged("Pages");
            }
        }

        private string volume;
        public string Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
            }
        }

        private string additionalInf;
        public string AdditionalInf
        {
            get { return additionalInf; }
            set
            {
                additionalInf = value;
                OnPropertyChanged("AdditionalInf");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
