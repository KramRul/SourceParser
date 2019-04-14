﻿using Microsoft.EntityFrameworkCore;
using SourceParser.DAL.Entities.Style;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    public class StyleRepository : BaseRepository<Style>, IStyleRepository
    {
        public StyleRepository() : base()
        {

        }

        public new async Task<List<Style>> GetAll()
        {
            var result = new List<Style>();
            using (var context = new ApplicationContext())
            {
                result = await context.Styles
                    .Include(s => s.AuthorFirst)
                    .Include(s => s.AuthorFirst.Label)
                    .Include(s => s.AuthorFirst.Name)
                    .Include(s => s.AuthorSecond)
                    .Include(s => s.AuthorSecond.Label)
                    .Include(s => s.AuthorSecond.Name)
                    .Include(s => s.PagesNumber)
                    .Include(s => s.PagesNumber.Text)
                    .Include(s => s.PagesNumber.Text.Group)
                    .Include(s => s.PagesRange)
                    .Include(s => s.PagesRange.Text)
                    .Include(s => s.PagesRange.Text.Group)
                    .Include(s => s.Publisher)
                    .Include(s => s.Publisher.GroupPublisher)
                    .Include(s => s.Publisher.YearDatePublisher)
                    .Include(s => s.Publisher.YearDatePublisher.DatePublisher)
                    .Include(s => s.Publishuniver)
                    .Include(s => s.Publishuniver.GroupUniver)
                    .Include(s => s.Publishuniver.YearDateUniver)
                    .Include(s => s.Publishuniver.YearDateUniver.DateUniver)
                    .Include(s => s.PublishVolume)
                    .Include(s => s.PublishVolume.Text)
                    .Include(s => s.PublishVolume.Text.Group)
                    .Include(s => s.Title)
                    .Include(s => s.Webdoc)
                    .Include(s => s.Webdoc.Group)
                    .Include(s => s.YearDateStyle)
                    .Include(s => s.YearDateStyle.Date)
                    .ToListAsync();
            }
            return result;
        }

        public async Task<List<Text>> GetAllTexts()
        {
            var result = new List<Text>();
            using (var context = new ApplicationContext())
            {
                result = await context.Texts.ToListAsync();
            }
            return result;
        }
    }
}
