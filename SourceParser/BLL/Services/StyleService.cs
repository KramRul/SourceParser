using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks.Interfaces;
using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services
{
    public class StyleService : BaseService, IStyleService
    {
        public StyleService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task CreateStyle(string title)
        {
            var createdStyle = new DAL.Entities.Style.Style()
            {
                Title = new DAL.Entities.Style.Title()
                {
                    Value = title,
                    Text = new DAL.Entities.Style.Text()
                },
                AuthorFirst = new DAL.Entities.Style.AuthorFirst()
                {
                    Label = new DAL.Entities.Style.Label(),
                    Name = new DAL.Entities.Style.Name()
                },
                AuthorSecond = new DAL.Entities.Style.AuthorSecond()
                {
                    Label = new DAL.Entities.Style.Label(),
                    Name = new DAL.Entities.Style.Name()
                },
                EtAl = "",
                PageRangeDelimiter = "",
                PagesNumber = new DAL.Entities.Style.PagesNumber()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Group = new DAL.Entities.Style.Group()
                    }
                },
                PagesRange = new DAL.Entities.Style.PagesRange()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Group = new DAL.Entities.Style.Group()
                    }
                },
                Publisher = new DAL.Entities.Style.Publisher()
                {
                    GroupPublisher = new DAL.Entities.Style.GroupPublisher()
                    {
                        TextPublishers = new List<DAL.Entities.Style.TextPublisher>() { new DAL.Entities.Style.TextPublisher() }
                    },
                    YearDatePublisher = new DAL.Entities.Style.YearDatePublisher()
                    {
                        DatePublisher = new DAL.Entities.Style.DatePublisher()
                        {
                            DatePartPublishers = new List<DAL.Entities.Style.DatePartPublisher>() { new DAL.Entities.Style.DatePartPublisher() }
                        }
                    }
                },
                Publishuniver = new DAL.Entities.Style.PublishUniver()
                {
                    GroupUniver = new DAL.Entities.Style.GroupUniver()
                    {
                        TextUnivers = new List<DAL.Entities.Style.TextUniver>() { new DAL.Entities.Style.TextUniver() }
                    },
                    YearDateUniver = new DAL.Entities.Style.YearDateUniver()
                    {
                        DateUniver = new DAL.Entities.Style.DateUniver()
                        {
                            DatePartUnivers = new List<DAL.Entities.Style.DatePartUniver>() { new DAL.Entities.Style.DatePartUniver() }
                        }
                    }
                },
                PublishVolume = new DAL.Entities.Style.PublishVolume()
                {
                    Text = new DAL.Entities.Style.Text()
                },
                TitleOfConference = new DAL.Entities.Style.TitleOfConference()
                {
                    Text = new DAL.Entities.Style.Text()
                },
                Webdoc = new DAL.Entities.Style.Webdoc()
                {
                    Group = new DAL.Entities.Style.Group()
                    {
                        Texts = new List<DAL.Entities.Style.Text>() { new DAL.Entities.Style.Text() }
                    }
                },
                YearDateStyle = new DAL.Entities.Style.YearDate()
                {
                    Date = new DAL.Entities.Style.Date()
                    {
                        DateParts = new List<DAL.Entities.Style.DatePart>() { new DAL.Entities.Style.DatePart() }
                    }
                }
            };

            await _database.Styles.Create(createdStyle);
        }

        public async Task DeleteStyle(StyleMod style)
        {
            await _database.Styles.Delete(new DAL.Entities.Style.Style()
            {
                Id = style.Id
            });
        }

        public async Task<ObservableCollection<StyleMod>> GetAllStyles()
        {
            var styles = await _database.Styles.GetAll();

            var texts = await _database.Styles.GetAllTexts();

            var stylesList = styles.Select(style => new StyleMod()
            {
                Id = style.Id,
                AuthorFirst = style.AuthorFirst,
                AuthorSecond = style.AuthorSecond,
                EtAl = style.EtAl,
                PageRangeDelimiter = style.PageRangeDelimiter,
                PagesNumber = style.PagesNumber,
                PagesRange = style.PagesRange,
                Publisher = style.Publisher,
                Publishuniver = style.Publishuniver,
                PublishVolume = style.PublishVolume,
                TitleOfConference = style.TitleOfConference,
                Title = style.Title,
                Webdoc = style.Webdoc,
                YearDateStyle = style.YearDateStyle
            }).ToList();

            var result = new ObservableCollection<StyleMod>(stylesList);

            return result;
        }

        public async Task UpdateStyle(StyleMod style)
        {
            var styleDB = new DAL.Entities.Style.Style()
            {
                AuthorFirst = new DAL.Entities.Style.AuthorFirst()
                {
                    Label = new DAL.Entities.Style.Label()
                    {
                        Form = style.AuthorFirst.Label.Form,
                        Prefix = style.AuthorFirst.Label.Prefix,
                        StripPeriods = style.AuthorFirst.Label.StripPeriods,
                        Suffix = style.AuthorFirst.Label.Suffix,
                        TextCase = style.AuthorFirst.Label.TextCase
                    },
                    Name = new DAL.Entities.Style.Name()
                    {
                        Delimiter = style.AuthorFirst.Name.Delimiter,
                        DelimiterPrecedesLast = style.AuthorFirst.Name.DelimiterPrecedesLast,
                        EtAlMin = style.AuthorFirst.Name.EtAlMin,
                        EtAlUseFirst = style.AuthorFirst.Name.EtAlUseFirst,
                        InitializeWith = style.AuthorFirst.Name.InitializeWith,
                        NameAsSortOrder = style.AuthorFirst.Name.NameAsSortOrder,
                        SortSeparator = style.AuthorFirst.Name.SortSeparator
                    }
                },
                AuthorSecond = new DAL.Entities.Style.AuthorSecond()
                {
                    Label = new DAL.Entities.Style.Label()
                    {
                        Form = style.AuthorSecond.Label.Form,
                        Prefix = style.AuthorSecond.Label.Prefix,
                        StripPeriods = style.AuthorSecond.Label.StripPeriods,
                        Suffix = style.AuthorSecond.Label.Suffix,
                        TextCase = style.AuthorSecond.Label.TextCase
                    },
                    Name = new DAL.Entities.Style.Name()
                    {
                        Delimiter = style.AuthorSecond.Name.Delimiter,
                        DelimiterPrecedesLast = style.AuthorSecond.Name.DelimiterPrecedesLast,
                        EtAlMin = style.AuthorSecond.Name.EtAlMin,
                        EtAlUseFirst = style.AuthorSecond.Name.EtAlUseFirst,
                        InitializeWith = style.AuthorSecond.Name.InitializeWith,
                        NameAsSortOrder = style.AuthorSecond.Name.NameAsSortOrder,
                        SortSeparator = style.AuthorSecond.Name.SortSeparator
                    }
                },
                EtAl = style.EtAl,
                PageRangeDelimiter = style.PageRangeDelimiter,
                PagesNumber = new DAL.Entities.Style.PagesNumber()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Prefix = style.PagesNumber.Text.Prefix,
                        Suffix = style.PagesNumber.Text.Suffix,
                        Value = style.PagesNumber.Text.Value,
                        Variable = style.PagesNumber.Text.Variable
                    }
                },
                PagesRange = new DAL.Entities.Style.PagesRange()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Prefix = style.PagesRange.Text.Prefix,
                        Suffix = style.PagesRange.Text.Suffix,
                        Value = style.PagesRange.Text.Value,
                        Variable = style.PagesRange.Text.Variable
                    }
                },
                Publisher = new DAL.Entities.Style.Publisher()
                {
                    GroupPublisher = new DAL.Entities.Style.GroupPublisher()
                    {
                        TextPublishers = style.Publisher.GroupPublisher.TextPublishers.Select(text => new DAL.Entities.Style.TextPublisher()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value,
                            Variable = text.Variable
                        }).ToList()
                    },
                    YearDatePublisher = new DAL.Entities.Style.YearDatePublisher()
                    {
                        DatePublisher = new DAL.Entities.Style.DatePublisher()
                        {
                            DatePartPublishers = style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers
                            .Select(date => new DAL.Entities.Style.DatePartPublisher()
                            {
                                NamePublisher = date.NamePublisher
                            }).ToList()
                        }
                    }
                },
                Publishuniver = new DAL.Entities.Style.PublishUniver()
                {
                    GroupUniver = new DAL.Entities.Style.GroupUniver()
                    {
                        TextUnivers = style.Publishuniver.GroupUniver.TextUnivers
                        .Select(text => new DAL.Entities.Style.TextUniver()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value,
                            Variable = text.Variable
                        }).ToList()
                    },
                    YearDateUniver = new DAL.Entities.Style.YearDateUniver()
                    {
                        DateUniver = new DAL.Entities.Style.DateUniver()
                        {
                            DatePartUnivers = style.Publishuniver.YearDateUniver.DateUniver.DatePartUnivers
                            .Select(date => new DAL.Entities.Style.DatePartUniver()
                            {
                                NameUniver = date.NameUniver
                            }).ToList()
                        }
                    }
                },
                PublishVolume = new DAL.Entities.Style.PublishVolume()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Prefix = style.PublishVolume.Text.Prefix,
                        Suffix = style.PublishVolume.Text.Suffix,
                        Value = style.PublishVolume.Text.Value,
                        Variable = style.PublishVolume.Text.Variable
                    }
                },
                TitleOfConference = new DAL.Entities.Style.TitleOfConference()
                {
                    Text = new DAL.Entities.Style.Text()
                    {
                        Prefix = style.TitleOfConference.Text.Prefix,
                        Suffix = style.TitleOfConference.Text.Suffix,
                        Value = style.TitleOfConference.Text.Value,
                        Variable = style.TitleOfConference.Text.Variable
                    }
                },
                Title = new DAL.Entities.Style.Title()
                {
                    Value = style.Title.Value,
                    Text = new DAL.Entities.Style.Text()
                    {
                        Prefix = style.Title.Text.Prefix,
                        Suffix = style.Title.Text.Suffix,
                        Value = style.Title.Text.Value,
                        Variable = style.Title.Text.Variable
                    }
                },
                Webdoc = new DAL.Entities.Style.Webdoc()
                {
                    Group = new DAL.Entities.Style.Group()
                    {
                        Texts = style.Webdoc.Group.Texts.Select(text => new DAL.Entities.Style.Text()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value,
                            Variable = text.Variable
                        }).ToList()
                    }
                },
                YearDateStyle = new DAL.Entities.Style.YearDate()
                {
                    Date = new DAL.Entities.Style.Date()
                    {
                        DateParts = style.YearDateStyle.Date.DateParts.Select(date => new DAL.Entities.Style.DatePart()
                        {
                            Name = date.Name
                        }).ToList()
                    }
                }
            };
            await _database.Styles.Update(styleDB, style.Id);
        }
        //public async Task UpdateStyle(StyleMod style)
        //{
        //    var styleDB = new DAL.Entities.Style.Style()
        //    {
        //        Id = style.Id,
        //        AuthorFirstId = style.AuthorFirst.Id,
        //        AuthorFirst = style.AuthorFirst,
        //        AuthorSecondId = style.AuthorSecond.Id,
        //        AuthorSecond = style.AuthorSecond,
        //        EtAl = style.EtAl,
        //        PageRangeDelimiter = style.PageRangeDelimiter,
        //        PagesNumberId = style.PagesNumber.Id,
        //        PagesNumber = style.PagesNumber,
        //        PagesRangeId = style.PagesRange.Id,
        //        PagesRange = style.PagesRange,
        //        PublisherId = style.Publisher.Id,
        //        Publisher = style.Publisher,
        //        PublishuniverId = style.Publishuniver.Id,
        //        Publishuniver = style.Publishuniver,
        //        PublishVolumeId = style.PublishVolume.Id,
        //        PublishVolume = style.PublishVolume,
        //        TitleId = style.Title.Id,
        //        Title = style.Title,
        //        WebdocId = style.Webdoc.Id,
        //        Webdoc = style.Webdoc,
        //        YearDateStyleId = style.YearDateStyle.Id,
        //        YearDateStyle = style.YearDateStyle
        //    };
        //    await _database.Styles.Update(styleDB);
        //}
    }
}
