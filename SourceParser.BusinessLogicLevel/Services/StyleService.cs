using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class StyleService : BaseService, IStyleService
    {
        public StyleService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task CreateStyle(string title)
        {
            var createdStyle = new DataAccessLevel.Entities.Style.Style()
            {
                Title = new DataAccessLevel.Entities.Style.Title()
                {
                    Value = title,
                    Text = new DataAccessLevel.Entities.Style.Text()
                },
                AuthorFirst = new DataAccessLevel.Entities.Style.AuthorFirst()
                {
                    Label = new DataAccessLevel.Entities.Style.Label(),
                    Name = new DataAccessLevel.Entities.Style.Name()
                },
                AuthorSecond = new DataAccessLevel.Entities.Style.AuthorSecond()
                {
                    Label = new DataAccessLevel.Entities.Style.Label(),
                    Name = new DataAccessLevel.Entities.Style.Name()
                },
                EtAl = "",
                PageRangeDelimiter = "",
                PagesNumber = new DataAccessLevel.Entities.Style.PagesNumber()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Group = new DataAccessLevel.Entities.Style.Group()
                    }
                },
                PagesRange = new DataAccessLevel.Entities.Style.PagesRange()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Group = new DataAccessLevel.Entities.Style.Group()
                    }
                },
                Publisher = new DataAccessLevel.Entities.Style.Publisher()
                {
                    GroupPublisher = new DataAccessLevel.Entities.Style.GroupPublisher()
                    {
                        TextPublishers = new List<DataAccessLevel.Entities.Style.TextPublisher>() { new DataAccessLevel.Entities.Style.TextPublisher() }
                    },
                    YearDatePublisher = new DataAccessLevel.Entities.Style.YearDatePublisher()
                    {
                        DatePublisher = new DataAccessLevel.Entities.Style.DatePublisher()
                        {
                            DatePartPublishers = new List<DataAccessLevel.Entities.Style.DatePartPublisher>() { new DataAccessLevel.Entities.Style.DatePartPublisher() }
                        }
                    }
                },
                Publishuniver = new DataAccessLevel.Entities.Style.PublishUniver()
                {
                    GroupUniver = new DataAccessLevel.Entities.Style.GroupUniver()
                    {
                        TextUnivers = new List<DataAccessLevel.Entities.Style.TextUniver>() { new DataAccessLevel.Entities.Style.TextUniver() }
                    },
                    YearDateUniver = new DataAccessLevel.Entities.Style.YearDateUniver()
                    {
                        DateUniver = new DataAccessLevel.Entities.Style.DateUniver()
                        {
                            DatePartUnivers = new List<DataAccessLevel.Entities.Style.DatePartUniver>() { new DataAccessLevel.Entities.Style.DatePartUniver() }
                        }
                    }
                },
                PublishVolume = new DataAccessLevel.Entities.Style.PublishVolume()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                },
                TitleOfConference = new DataAccessLevel.Entities.Style.TitleOfConference()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                },
                Webdoc = new DataAccessLevel.Entities.Style.Webdoc()
                {
                    Group = new DataAccessLevel.Entities.Style.Group()
                    {
                        Texts = new List<DataAccessLevel.Entities.Style.Text>() { new DataAccessLevel.Entities.Style.Text() }
                    }
                },
                YearDateStyle = new DataAccessLevel.Entities.Style.YearDate()
                {
                    Date = new DataAccessLevel.Entities.Style.Date()
                    {
                        DateParts = new List<DataAccessLevel.Entities.Style.DatePart>() { new DataAccessLevel.Entities.Style.DatePart() }
                    }
                }
            };

            await _database.Styles.Create(createdStyle);
        }

        public async Task DeleteStyle(StyleMod style)
        {
            await _database.Styles.Delete(new DataAccessLevel.Entities.Style.Style()
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
            var styleDB = new DataAccessLevel.Entities.Style.Style()
            {
                AuthorFirst = new DataAccessLevel.Entities.Style.AuthorFirst()
                {
                    Label = new DataAccessLevel.Entities.Style.Label()
                    {
                        Form = style.AuthorFirst.Label.Form,
                        Prefix = style.AuthorFirst.Label.Prefix,
                        Suffix = style.AuthorFirst.Label.Suffix
                    },
                    Name = new DataAccessLevel.Entities.Style.Name()
                    {
                        Delimiter = style.AuthorFirst.Name.Delimiter,
                        InitializeWith = style.AuthorFirst.Name.InitializeWith
                    }
                },
                AuthorSecond = new DataAccessLevel.Entities.Style.AuthorSecond()
                {
                    Label = new DataAccessLevel.Entities.Style.Label()
                    {
                        Form = style.AuthorSecond.Label.Form,
                        Prefix = style.AuthorSecond.Label.Prefix,
                        Suffix = style.AuthorSecond.Label.Suffix
                    },
                    Name = new DataAccessLevel.Entities.Style.Name()
                    {
                        Delimiter = style.AuthorSecond.Name.Delimiter,
                        InitializeWith = style.AuthorSecond.Name.InitializeWith
                    }
                },
                EtAl = style.EtAl,
                EtAlMax = style.EtAlMax,
                PageRangeDelimiter = style.PageRangeDelimiter,
                PagesNumber = new DataAccessLevel.Entities.Style.PagesNumber()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Prefix = style.PagesNumber.Text.Prefix,
                        Suffix = style.PagesNumber.Text.Suffix,
                        Value = style.PagesNumber.Text.Value
                    }
                },
                PagesRange = new DataAccessLevel.Entities.Style.PagesRange()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Prefix = style.PagesRange.Text.Prefix,
                        Suffix = style.PagesRange.Text.Suffix,
                        Value = style.PagesRange.Text.Value
                    }
                },
                Publisher = new DataAccessLevel.Entities.Style.Publisher()
                {
                    GroupPublisher = new DataAccessLevel.Entities.Style.GroupPublisher()
                    {
                        TextPublishers = style.Publisher.GroupPublisher.TextPublishers.Select(text => new DataAccessLevel.Entities.Style.TextPublisher()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value,
                            Variable = text.Variable
                        }).ToList()
                    },
                    YearDatePublisher = new DataAccessLevel.Entities.Style.YearDatePublisher()
                    {
                        DatePublisher = new DataAccessLevel.Entities.Style.DatePublisher()
                        {
                            DatePartPublishers = style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers
                            .Select(date => new DataAccessLevel.Entities.Style.DatePartPublisher()
                            {
                                NamePublisher = date.NamePublisher
                            }).ToList()
                        }
                    }
                },
                Publishuniver = new DataAccessLevel.Entities.Style.PublishUniver()
                {
                    GroupUniver = new DataAccessLevel.Entities.Style.GroupUniver()
                    {
                        TextUnivers = style.Publishuniver.GroupUniver.TextUnivers
                        .Select(text => new DataAccessLevel.Entities.Style.TextUniver()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value,
                            Variable = text.Variable
                        }).ToList()
                    },
                    YearDateUniver = new DataAccessLevel.Entities.Style.YearDateUniver()
                    {
                        DateUniver = new DataAccessLevel.Entities.Style.DateUniver()
                        {
                            DatePartUnivers = style.Publishuniver.YearDateUniver.DateUniver.DatePartUnivers
                            .Select(date => new DataAccessLevel.Entities.Style.DatePartUniver()
                            {
                                NameUniver = date.NameUniver
                            }).ToList()
                        }
                    }
                },
                PublishVolume = new DataAccessLevel.Entities.Style.PublishVolume()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Prefix = style.PublishVolume.Text.Prefix,
                        Suffix = style.PublishVolume.Text.Suffix,
                        Value = style.PublishVolume.Text.Value
                    }
                },
                TitleOfConference = new DataAccessLevel.Entities.Style.TitleOfConference()
                {
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Prefix = style.TitleOfConference.Text.Prefix,
                        Suffix = style.TitleOfConference.Text.Suffix,
                        Value = style.TitleOfConference.Text.Value
                    }
                },
                Title = new DataAccessLevel.Entities.Style.Title()
                {
                    Value = style.Title.Value,
                    Text = new DataAccessLevel.Entities.Style.Text()
                    {
                        Prefix = style.Title.Text.Prefix,
                        Suffix = style.Title.Text.Suffix,
                        Value = style.Title.Text.Value
                    }
                },
                Webdoc = new DataAccessLevel.Entities.Style.Webdoc()
                {
                    Group = new DataAccessLevel.Entities.Style.Group()
                    {
                        Texts = style.Webdoc.Group.Texts.Select(text => new DataAccessLevel.Entities.Style.Text()
                        {
                            Prefix = text.Prefix,
                            Suffix = text.Suffix,
                            Value = text.Value
                        }).ToList()
                    }
                },
                YearDateStyle = new DataAccessLevel.Entities.Style.YearDate()
                {
                    Date = new DataAccessLevel.Entities.Style.Date()
                    {
                        DateParts = style.YearDateStyle.Date.DateParts.Select(date => new DataAccessLevel.Entities.Style.DatePart()
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
