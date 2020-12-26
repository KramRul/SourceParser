using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.Models.Models
{
    public class StyleMod : INotifyPropertyChanged
    {
        private string _id;
        private string _EtAl;
        private int _EtAlMax;
        private string _pageRangeDelimiter;
        private DataAccessLevel.Entities.Style.Title _title { get; set; }
        private DataAccessLevel.Entities.Style.AuthorFirst _authorFirst { get; set; }
        private DataAccessLevel.Entities.Style.AuthorSecond _authorSecond { get; set; }
        private DataAccessLevel.Entities.Style.Webdoc _webdoc { get; set; }
        private DataAccessLevel.Entities.Style.Publisher _publisher { get; set; }
        private DataAccessLevel.Entities.Style.PublishUniver _publishuniver { get; set; }
        private DataAccessLevel.Entities.Style.YearDate _yearDateStyle { get; set; }
        private DataAccessLevel.Entities.Style.PublishVolume _publishVolume { get; set; }
        private DataAccessLevel.Entities.Style.PagesNumber _pagesNumber { get; set; }
        private DataAccessLevel.Entities.Style.PagesRange _pagesRange { get; set; }
        private DataAccessLevel.Entities.Style.TitleOfConference _titleOfConference { get; set; }

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

        public int EtAlMax
        {
            get { return _EtAlMax; }
            set
            {
                _EtAlMax = value;
                OnPropertyChanged("EtAlMax");
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

        public DataAccessLevel.Entities.Style.Title Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public DataAccessLevel.Entities.Style.TitleOfConference TitleOfConference
        {
            get => _titleOfConference;
            set
            {
                _titleOfConference = value;
                OnPropertyChanged("TitleOfConference");
            }
        }

        public DataAccessLevel.Entities.Style.AuthorFirst AuthorFirst
        {
            get { return _authorFirst; }
            set
            {
                _authorFirst = value;
                OnPropertyChanged("AuthorFirst");
            }
        }

        public DataAccessLevel.Entities.Style.AuthorSecond AuthorSecond
        {
            get { return _authorSecond; }
            set
            {
                _authorSecond = value;
                OnPropertyChanged("AuthorSecond");
            }
        }

        public DataAccessLevel.Entities.Style.Webdoc Webdoc
        {
            get { return _webdoc; }
            set
            {
                _webdoc = value;
                OnPropertyChanged("Webdoc");
            }
        }

        public DataAccessLevel.Entities.Style.Publisher Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public DataAccessLevel.Entities.Style.PublishUniver Publishuniver
        {
            get { return _publishuniver; }
            set
            {
                _publishuniver = value;
                OnPropertyChanged("Publishuniver");
            }
        }

        public DataAccessLevel.Entities.Style.YearDate YearDateStyle
        {
            get { return _yearDateStyle; }
            set
            {
                _yearDateStyle = value;
                OnPropertyChanged("YearDateStyle");
            }
        }

        public DataAccessLevel.Entities.Style.PublishVolume PublishVolume
        {
            get { return _publishVolume; }
            set
            {
                _publishVolume = value;
                OnPropertyChanged("PublishVolume");
            }
        }

        public DataAccessLevel.Entities.Style.PagesNumber PagesNumber
        {
            get { return _pagesNumber; }
            set
            {
                _pagesNumber = value;
                OnPropertyChanged("PagesNumber");
            }
        }

        public DataAccessLevel.Entities.Style.PagesRange PagesRange
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
