using Microsoft.EntityFrameworkCore;
using SourceParser.DataAccessLevel.Entities;
using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository() : base()
        {
        }

        public async Task<List<Note>> GetAllByDocumentId(string docId)
        {
            var result = new List<Note>();
            using (var context = new ApplicationContext())
            {
                result = await context.Set<Note>()
                    .Where(n => n.DocumentId == docId)
                    .Include(n => n.Document)
                    .ToListAsync();
            }
            return result;
        }

        public async Task Create(Note item, string docId)
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
                item.Document = docum;
                item.DocumentId = docum.Id;
                await context.Set<Note>().AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Note item, string docId)
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
                item.Document = docum;
                item.DocumentId = docum.Id;
                context.Set<Note>().Update(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
