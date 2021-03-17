using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SourceParser.Models.Models
{
    public class ImportLinkDataModel : INotifyPropertyChanged
    {
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        private Guid _sku;
        public Guid SKU
        {
            get => _sku;
            set
            {
                _sku = value;
                OnPropertyChanged("SKU");
            }
        }
        private string _sourceLink;
        public string SourceLink
        {
            get => _sourceLink;
            set
            {
                _sourceLink = value;
                OnPropertyChanged("SourceLink");
            }
        }
        private string _BiblLinkClass;
        public string BiblLinkClass
        {
            get => _BiblLinkClass;
            set
            {
                _BiblLinkClass = value;
                OnPropertyChanged("BiblLinkClass");
            }
        }
        private string _SearchParameter0;
        public string SearchParameter0
        {
            get => _SearchParameter0;
            set
            {
                _SearchParameter0 = value;
                OnPropertyChanged("SearchParameter0");
            }
        }
        private string _SearchParameter1;
        public string SearchParameter1
        {
            get => _SearchParameter1;
            set
            {
                _SearchParameter1 = value;
                OnPropertyChanged("SearchParameter1");
            }
        }
        private string _SearchParameter2;
        public string SearchParameter2
        {
            get => _SearchParameter2;
            set
            {
                _SearchParameter2 = value;
                OnPropertyChanged("SearchParameter2");
            }
        }
        private string _SearchParameter3;
        public string SearchParameter3
        {
            get => _SearchParameter3;
            set
            {
                _SearchParameter3 = value;
                OnPropertyChanged("SearchParameter3");
            }
        }
        private string _SearchParameter4;
        public string SearchParameter4
        {
            get => _SearchParameter4;
            set
            {
                _SearchParameter4 = value;
                OnPropertyChanged("SearchParameter4");
            }
        }
        private string _SearchParameter5;
        public string SearchParameter5
        {
            get => _SearchParameter5;
            set
            {
                _SearchParameter5 = value;
                OnPropertyChanged("SearchParameter5");
            }
        }
        private string _SearchParameter6;
        public string SearchParameter6
        {
            get => _SearchParameter6;
            set
            {
                _SearchParameter6 = value;
                OnPropertyChanged("SearchParameter6");
            }
        }
        private string _SearchParameter7;
        public string SearchParameter7
        {
            get => _SearchParameter7;
            set
            {
                _SearchParameter7 = value;
                OnPropertyChanged("SearchParameter7");
            }
        }
        private string _SearchParameter8;
        public string SearchParameter8
        {
            get => _SearchParameter8;
            set
            {
                _SearchParameter8 = value;
                OnPropertyChanged("SearchParameter8");
            }
        }
        private string _SearchParameter9;
        public string SearchParameter9
        {
            get => _SearchParameter9;
            set
            {
                _SearchParameter9 = value;
                OnPropertyChanged("SearchParameter9");
            }
        }
        private string _SearchParameter10;
        public string SearchParameter10
        {
            get => _SearchParameter10;
            set
            {
                _SearchParameter10 = value;
                OnPropertyChanged("SearchParameter10");
            }
        }
        private string _SearchParameter11;
        public string SearchParameter11
        {
            get => _SearchParameter11;
            set
            {
                _SearchParameter11 = value;
                OnPropertyChanged("SearchParameter11");
            }
        }
        private string _SearchParameter12;
        public string SearchParameter12
        {
            get => _SearchParameter12;
            set
            {
                _SearchParameter12 = value;
                OnPropertyChanged("SearchParameter12");
            }
        }
        private string _SearchParameter13;
        public string SearchParameter13
        {
            get => _SearchParameter13;
            set
            {
                _SearchParameter13 = value;
                OnPropertyChanged("SearchParameter13");
            }
        }
        private string _SearchParameter14;
        public string SearchParameter14
        {
            get => _SearchParameter14;
            set
            {
                _SearchParameter14 = value;
                OnPropertyChanged("SearchParameter14");
            }
        }
        private string _SearchParameter15;
        public string SearchParameter15
        {
            get => _SearchParameter15;
            set
            {
                _SearchParameter15 = value;
                OnPropertyChanged("SearchParameter15");
            }
        }
        private string _SearchParameter16;
        public string SearchParameter16
        {
            get => _SearchParameter16;
            set
            {
                _SearchParameter16 = value;
                OnPropertyChanged("SearchParameter16");
            }
        }
        private string _SearchParameter17;
        public string SearchParameter17
        {
            get => _SearchParameter17;
            set
            {
                _SearchParameter17 = value;
                OnPropertyChanged("SearchParameter17");
            }
        }
        private string _SearchParameter18;
        public string SearchParameter18
        {
            get => _SearchParameter18;
            set
            {
                _SearchParameter18 = value;
                OnPropertyChanged("SearchParameter18");
            }
        }
        private string _SearchParameter19;
        public string SearchParameter19
        {
            get => _SearchParameter19;
            set
            {
                _SearchParameter19 = value;
                OnPropertyChanged("SearchParameter19");
            }
        }
        private string _SearchParameter20;
        public string SearchParameter20
        {
            get => _SearchParameter20;
            set
            {
                _SearchParameter20 = value;
                OnPropertyChanged("SearchParameter20");
            }
        }
        private string _SearchParameter21;
        public string SearchParameter21
        {
            get => _SearchParameter21;
            set
            {
                _SearchParameter21 = value;
                OnPropertyChanged("SearchParameter21");
            }
        }
        private string _SearchParameter22;
        public string SearchParameter22
        {
            get => _SearchParameter22;
            set
            {
                _SearchParameter22 = value;
                OnPropertyChanged("SearchParameter22");
            }
        }
        private string _SearchParameter23;
        public string SearchParameter23
        {
            get => _SearchParameter23;
            set
            {
                _SearchParameter23 = value;
                OnPropertyChanged("SearchParameter23");
            }
        }
        private string _SearchParameter24;
        public string SearchParameter24
        {
            get => _SearchParameter24;
            set
            {
                _SearchParameter24 = value;
                OnPropertyChanged("SearchParameter24");
            }
        }
        private string _SearchParameter25;
        public string SearchParameter25
        {
            get => _SearchParameter25;
            set
            {
                _SearchParameter25 = value;
                OnPropertyChanged("SearchParameter25");
            }
        }
        private string _SearchParameter26;
        public string SearchParameter26
        {
            get => _SearchParameter26;
            set
            {
                _SearchParameter26 = value;
                OnPropertyChanged("SearchParameter26");
            }
        }
        private string _SearchParameter27;
        public string SearchParameter27
        {
            get => _SearchParameter27;
            set
            {
                _SearchParameter27 = value;
                OnPropertyChanged("SearchParameter27");
            }
        }
        private string _SearchParameter28;
        public string SearchParameter28
        {
            get => _SearchParameter28;
            set
            {
                _SearchParameter28 = value;
                OnPropertyChanged("SearchParameter28");
            }
        }
        private string _SearchParameter29;
        public string SearchParameter29
        {
            get => _SearchParameter29;
            set
            {
                _SearchParameter29 = value;
                OnPropertyChanged("SearchParameter29");
            }
        }
        private string _SearchParameter30;
        public string SearchParameter30
        {
            get => _SearchParameter30;
            set
            {
                _SearchParameter30 = value;
                OnPropertyChanged("SearchParameter30");
            }
        }
        private string _SearchParameter31;
        public string SearchParameter31
        {
            get => _SearchParameter31;
            set
            {
                _SearchParameter31 = value;
                OnPropertyChanged("SearchParameter31");
            }
        }
        private string _SearchParameter32;
        public string SearchParameter32
        {
            get => _SearchParameter32;
            set
            {
                _SearchParameter32 = value;
                OnPropertyChanged("SearchParameter32");
            }
        }
        private string _SearchParameter33;
        public string SearchParameter33
        {
            get => _SearchParameter33;
            set
            {
                _SearchParameter33 = value;
                OnPropertyChanged("SearchParameter33");
            }
        }
        private string _SearchParameter34;
        public string SearchParameter34
        {
            get => _SearchParameter34;
            set
            {
                _SearchParameter34 = value;
                OnPropertyChanged("SearchParameter34");
            }
        }
        private string _SearchParameter35;
        public string SearchParameter35
        {
            get => _SearchParameter35;
            set
            {
                _SearchParameter35 = value;
                OnPropertyChanged("SearchParameter35");
            }
        }
        private string _SearchParameter36;
        public string SearchParameter36
        {
            get => _SearchParameter36;
            set
            {
                _SearchParameter36 = value;
                OnPropertyChanged("SearchParameter36");
            }
        }
        private string _SearchParameter37;
        public string SearchParameter37
        {
            get => _SearchParameter37;
            set
            {
                _SearchParameter37 = value;
                OnPropertyChanged("SearchParameter37");
            }
        }
        private string _SearchParameter38;
        public string SearchParameter38
        {
            get => _SearchParameter38;
            set
            {
                _SearchParameter38 = value;
                OnPropertyChanged("SearchParameter38");
            }
        }
        private string _SearchParameter39;
        public string SearchParameter39
        {
            get => _SearchParameter39;
            set
            {
                _SearchParameter39 = value;
                OnPropertyChanged("SearchParameter39");
            }
        }
        private string _SearchParameter40;
        public string SearchParameter40
        {
            get => _SearchParameter40;
            set
            {
                _SearchParameter40 = value;
                OnPropertyChanged("SearchParameter40");
            }
        }
        private string _SearchParameter41;
        public string SearchParameter41
        {
            get => _SearchParameter41;
            set
            {
                _SearchParameter41 = value;
                OnPropertyChanged("SearchParameter41");
            }
        }
        private string _SearchParameter42;
        public string SearchParameter42
        {
            get => _SearchParameter42;
            set
            {
                _SearchParameter42 = value;
                OnPropertyChanged("SearchParameter42");
            }
        }
        private string _SearchParameter43;
        public string SearchParameter43
        {
            get => _SearchParameter43;
            set
            {
                _SearchParameter43 = value;
                OnPropertyChanged("SearchParameter43");
            }
        }
        private string _SearchParameter44;
        public string SearchParameter44
        {
            get => _SearchParameter44;
            set
            {
                _SearchParameter44 = value;
                OnPropertyChanged("SearchParameter44");
            }
        }
        private string _SearchParameter45;
        public string SearchParameter45
        {
            get => _SearchParameter45;
            set
            {
                _SearchParameter45 = value;
                OnPropertyChanged("SearchParameter45");
            }
        }
        private string _SearchParameter46;
        public string SearchParameter46
        {
            get => _SearchParameter46;
            set
            {
                _SearchParameter46 = value;
                OnPropertyChanged("SearchParameter46");
            }
        }
        private string _SearchParameter47;
        public string SearchParameter47
        {
            get => _SearchParameter47;
            set
            {
                _SearchParameter47 = value;
                OnPropertyChanged("SearchParameter47");
            }
        }
        private string _SearchParameter48;
        public string SearchParameter48
        {
            get => _SearchParameter48;
            set
            {
                _SearchParameter48 = value;
                OnPropertyChanged("SearchParameter48");
            }
        }
        private string _SearchParameter49;
        public string SearchParameter49
        {
            get => _SearchParameter49;
            set
            {
                _SearchParameter49 = value;
                OnPropertyChanged("SearchParameter49");
            }
        }
        private string _SearchParameter50;
        public string SearchParameter50
        {
            get => _SearchParameter50;
            set
            {
                _SearchParameter50 = value;
                OnPropertyChanged("SearchParameter50");
            }
        }
        private string _SearchParameter51;
        public string SearchParameter51
        {
            get => _SearchParameter51;
            set
            {
                _SearchParameter51 = value;
                OnPropertyChanged("SearchParameter51");
            }
        }
        private string _SearchParameter52;
        public string SearchParameter52
        {
            get => _SearchParameter52;
            set
            {
                _SearchParameter52 = value;
                OnPropertyChanged("SearchParameter52");
            }
        }
        private string _SearchParameter53;
        public string SearchParameter53
        {
            get => _SearchParameter53;
            set
            {
                _SearchParameter53 = value;
                OnPropertyChanged("SearchParameter53");
            }
        }
        private string _SearchParameter54;
        public string SearchParameter54
        {
            get => _SearchParameter54;
            set
            {
                _SearchParameter54 = value;
                OnPropertyChanged("SearchParameter54");
            }
        }
        private string _SearchParameter55;
        public string SearchParameter55
        {
            get => _SearchParameter55;
            set
            {
                _SearchParameter55 = value;
                OnPropertyChanged("SearchParameter55");
            }
        }
        private string _SearchParameter56;
        public string SearchParameter56
        {
            get => _SearchParameter56;
            set
            {
                _SearchParameter56 = value;
                OnPropertyChanged("SearchParameter56");
            }
        }
        private string _SearchParameter57;
        public string SearchParameter57
        {
            get => _SearchParameter57;
            set
            {
                _SearchParameter57 = value;
                OnPropertyChanged("SearchParameter57");
            }
        }
        private string _SearchParameter58;
        public string SearchParameter58
        {
            get => _SearchParameter58;
            set
            {
                _SearchParameter58 = value;
                OnPropertyChanged("SearchParameter58");
            }
        }
        private string _SearchParameter59;
        public string SearchParameter59
        {
            get => _SearchParameter59;
            set
            {
                _SearchParameter59 = value;
                OnPropertyChanged("SearchParameter59");
            }
        }
        private string _SearchParameter60;
        public string SearchParameter60
        {
            get => _SearchParameter60;
            set
            {
                _SearchParameter60 = value;
                OnPropertyChanged("SearchParameter60");
            }
        }
        private string _SearchParameter61;
        public string SearchParameter61
        {
            get => _SearchParameter61;
            set
            {
                _SearchParameter61 = value;
                OnPropertyChanged("SearchParameter61");
            }
        }
        private string _SearchParameter62;
        public string SearchParameter62
        {
            get => _SearchParameter62;
            set
            {
                _SearchParameter62 = value;
                OnPropertyChanged("SearchParameter62");
            }
        }
        private string _SearchParameter63;
        public string SearchParameter63
        {
            get => _SearchParameter63;
            set
            {
                _SearchParameter63 = value;
                OnPropertyChanged("SearchParameter63");
            }
        }
        private string _SearchParameter64;
        public string SearchParameter64
        {
            get => _SearchParameter64;
            set
            {
                _SearchParameter64 = value;
                OnPropertyChanged("SearchParameter64");
            }
        }
        private string _SearchParameter65;
        public string SearchParameter65
        {
            get => _SearchParameter65;
            set
            {
                _SearchParameter65 = value;
                OnPropertyChanged("SearchParameter65");
            }
        }
        private string _SearchParameter66;
        public string SearchParameter66
        {
            get => _SearchParameter66;
            set
            {
                _SearchParameter66 = value;
                OnPropertyChanged("SearchParameter66");
            }
        }
        private string _SearchParameter67;
        public string SearchParameter67
        {
            get => _SearchParameter67;
            set
            {
                _SearchParameter67 = value;
                OnPropertyChanged("SearchParameter67");
            }
        }
        private string _SearchParameter68;
        public string SearchParameter68
        {
            get => _SearchParameter68;
            set
            {
                _SearchParameter68 = value;
                OnPropertyChanged("SearchParameter68");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
