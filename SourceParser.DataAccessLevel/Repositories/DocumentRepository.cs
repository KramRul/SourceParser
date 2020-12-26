using Microsoft.EntityFrameworkCore;
using SourceParser.DataAccessLevel.Entities;
using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository() : base()
        {
        }

        public async Task Update(Document item, string id)
        {
            using (var context = new ApplicationContext())
            {
                context.Set<Document>().Update(item);
                context.Set<Author>().Update(item.Author);
                context.Set<Co_Author>().Update(item.Co_Author);
                context.Set<Editor>().Update(item.Editor);
                context.Set<Page>().Update(item.Pages);
                context.Set<Publisher>().Update(item.Publisher);
                context.Set<Translator>().Update(item.Translator);
                await context.SaveChangesAsync();
            }
        }

        public new async Task<List<Document>> GetAll()
        {
            var result = new List<Document>();
            using (var context = new ApplicationContext())
            {
                result = await context.Documents
                    .Include(s => s.Author)
                    .Include(s => s.Co_Author)
                    .Include(s => s.Editor)
                    .Include(s => s.Pages)
                    .Include(s => s.Publisher)
                    .Include(s => s.Translator)
                    .ToListAsync();
            }
            return result;
        }
    }
}
