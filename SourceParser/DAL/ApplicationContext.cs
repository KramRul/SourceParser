using Microsoft.EntityFrameworkCore;
using SourceParser.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Co_Author> Co_Authors { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Entities.Style.Style> Styles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=_SOURCE_PARSER");
        }
    }
}
