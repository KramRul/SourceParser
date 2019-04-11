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
            await _database.Styles.Create(new DAL.Entities.Style.Style()
            {
                Title = new DAL.Entities.Style.Title()
                {
                    Value = title
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
                },
                PagesRange = new DAL.Entities.Style.PagesRange()
                {
                    Text = new DAL.Entities.Style.Text()
                },
                Publisher = new DAL.Entities.Style.Publisher()
                {
                    GroupPublisher = new DAL.Entities.Style.GroupPublisher()
                    {
                        
                    },
                    YearDatePublisher = new DAL.Entities.Style.YearDatePublisher()
                    {
                        DatePublisher = new DAL.Entities.Style.DatePublisher()
                        {
                            
                        }
                    }
                },
                Publishuniver = new DAL.Entities.Style.PublishUniver()
                {
                    GroupUniver = new DAL.Entities.Style.GroupUniver()
                    {
                        
                    },
                    YearDateUniver = new DAL.Entities.Style.YearDateUniver()
                    {
                        DateUniver = new DAL.Entities.Style.DateUniver()
                        {
                            
                        }
                    }
                },
                PublishVolume = new DAL.Entities.Style.PublishVolume()
                {
                    Text = new DAL.Entities.Style.Text()
                },
                Webdoc = new DAL.Entities.Style.Webdoc()
                {
                    Group = new DAL.Entities.Style.Group()
                    {
                        
                    }
                },
                YearDateStyle = new DAL.Entities.Style.YearDate()
                {
                    Date = new DAL.Entities.Style.Date()
                    {
                        
                    }
                }
            });
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
                Title = style.Title,
                Webdoc = style.Webdoc,
                YearDateStyle = style.YearDateStyle
            }).ToList();

            var result = new ObservableCollection<StyleMod>(stylesList);

            return result;
        }

        public async Task UpdateStyle(StyleMod style)
        {
            await _database.Styles.Update(new DAL.Entities.Style.Style()
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
                Title = style.Title,
                Webdoc = style.Webdoc,
                YearDateStyle = style.YearDateStyle
            });
        }
    }
}
