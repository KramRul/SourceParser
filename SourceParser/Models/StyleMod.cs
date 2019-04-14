using SourceParser.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.Models
{
    public class StyleMod : INotifyPropertyChanged
    {
        private string _id;
        private string _EtAl;
        private string _pageRangeDelimiter;
        private DAL.Entities.Style.Title _title { get; set; }
        private DAL.Entities.Style.AuthorFirst _authorFirst { get; set; }
        private DAL.Entities.Style.AuthorSecond _authorSecond { get; set; }
        private DAL.Entities.Style.Webdoc _webdoc { get; set; }
        private List<DAL.Entities.Style.Text> _webdocGroupTextList { get; set; }
        private DAL.Entities.Style.Publisher _publisher { get; set; }
        private DAL.Entities.Style.PublishUniver _publishuniver { get; set; }
        private DAL.Entities.Style.YearDate _yearDateStyle { get; set; }
        private DAL.Entities.Style.PublishVolume _publishVolume { get; set; }
        private DAL.Entities.Style.PagesNumber _pagesNumber { get; set; }
        private DAL.Entities.Style.PagesRange _pagesRange { get; set; }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string EtAl
        {
            get { return _EtAl; }
            set
            {
                _EtAl = value;
                OnPropertyChanged("EtAl");
            }
        }

        public string PageRangeDelimiter
        {
            get { return _pageRangeDelimiter; }
            set
            {
                _pageRangeDelimiter = value;
                OnPropertyChanged("PageRangeDelimiter");
            }
        }

        public DAL.Entities.Style.Title Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public DAL.Entities.Style.AuthorFirst AuthorFirst
        {
            get { return _authorFirst; }
            set
            {
                _authorFirst = value;
                OnPropertyChanged("AuthorFirst");
            }
        }

        public DAL.Entities.Style.AuthorSecond AuthorSecond
        {
            get { return _authorSecond; }
            set
            {
                _authorSecond = value;
                OnPropertyChanged("AuthorSecond");
            }
        }

        public DAL.Entities.Style.Webdoc Webdoc
        {
            get { return _webdoc; }
            set
            {
                _webdoc = value;
                OnPropertyChanged("Webdoc");
            }
        }

        public List<DAL.Entities.Style.Text> WebdocGroupTextList
        {
            get { return _webdocGroupTextList; }
            set
            {
                _webdocGroupTextList = value;
                OnPropertyChanged("WebdocGroupTextList");
            }
        }

        public DAL.Entities.Style.Publisher Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public DAL.Entities.Style.PublishUniver Publishuniver
        {
            get { return _publishuniver; }
            set
            {
                _publishuniver = value;
                OnPropertyChanged("Publishuniver");
            }
        }

        public DAL.Entities.Style.YearDate YearDateStyle
        {
            get { return _yearDateStyle; }
            set
            {
                _yearDateStyle = value;
                OnPropertyChanged("YearDateStyle");
            }
        }

        public DAL.Entities.Style.PublishVolume PublishVolume
        {
            get { return _publishVolume; }
            set
            {
                _publishVolume = value;
                OnPropertyChanged("PublishVolume");
            }
        }

        public DAL.Entities.Style.PagesNumber PagesNumber
        {
            get { return _pagesNumber; }
            set
            {
                _pagesNumber = value;
                OnPropertyChanged("PagesNumber");
            }
        }

        public DAL.Entities.Style.PagesRange PagesRange
        {
            get { return _pagesRange; }
            set
            {
                _pagesRange = value;
                OnPropertyChanged("PagesRange");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
