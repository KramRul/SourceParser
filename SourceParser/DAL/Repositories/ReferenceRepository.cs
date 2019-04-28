using Microsoft.EntityFrameworkCore;
using SourceParser.DAL.Entities;
using SourceParser.DAL.Entities.Style;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    class ReferenceRepository : BaseRepository<Reference>, IReferenceRepository
    {
        public ReferenceRepository() : base()
        {
        }

        public async Task<List<Reference>> GetAllByDocumentId(string docId)
        {
            var result = new List<Reference>();
            using (var context = new ApplicationContext())
            {
                result = await context.Set<Reference>()
                    .Where(n => n.DocumentId == docId)
                    .Include(n => n.Document)
                    .Include(n => n.Style)
                    .ToListAsync();
            }
            return result;
        }

        public async Task Create(Reference item, string docId, string styleId)
        {
            using (var context = new ApplicationContext())
            {
                var docum = context.Set<Document>().Where(d => d.Id == docId)
                    .Include(d => d.Author)
                    .Include(d => d.Co_Author)
                    .Include(d => d.Editor)
                    .Include(d => d.Publisher)
                    .Include(d => d.Translator)
                    .SingleOrDefault();

                var style = context.Set<Style>().Where(d => d.Id == styleId)
                    .Include(d => d.AuthorFirst)
                    .Include(d => d.AuthorSecond)
                    .Include(d => d.PagesNumber)
                    .Include(d => d.PagesRange)
                    .Include(d => d.Publisher)
                    .Include(d => d.Publishuniver)
                    .Include(d => d.PublishVolume)
                    .Include(d => d.Title)
                    .Include(d => d.Webdoc)
                    .Include(d => d.YearDateStyle)
                    .SingleOrDefault();

                item.Document = docum;
                item.DocumentId = docum.Id;
                item.Style = style;
                item.StyleId = style.Id;

                await context.Set<Reference>().AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Reference item, string docId, string styleId)
        {
            using (var context = new ApplicationContext())
            {
                var docum = context.Set<Document>().Where(d => d.Id == docId)
                    .Include(d => d.Author)
                    .Include(d => d.Co_Author)
                    .Include(d => d.Editor)
                    .Include(d => d.Publisher)
                    .Include(d => d.Translator)
                    .SingleOrDefault();

                var style = context.Set<Style>().Where(d => d.Id == styleId)
                    .Include(d => d.AuthorFirst)
                    .Include(d => d.AuthorSecond)
                    .Include(d => d.PagesNumber)
                    .Include(d => d.PagesRange)
                    .Include(d => d.Publisher)
                    .Include(d => d.Publishuniver)
                    .Include(d => d.PublishVolume)
                    .Include(d => d.Title)
                    .Include(d => d.Webdoc)
                    .Include(d => d.YearDateStyle)
                    .SingleOrDefault();

                item.Document = docum;
                item.DocumentId = docum.Id;
                item.Style = style;
                item.StyleId = style.Id;

                context.Set<Reference>().Update(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
