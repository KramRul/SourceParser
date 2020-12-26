using Microsoft.EntityFrameworkCore;
using SourceParser.DataAccessLevel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel
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
        public DbSet<Entities.Style.Text> Texts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=_SOURCE_PARSER");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.AuthorFirst, p =>
            {
                p.OwnsOne(c => c.Label);
                p.OwnsOne(c => c.Name);
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.AuthorSecond, p =>
            {
                p.OwnsOne(c => c.Label);
                p.OwnsOne(c => c.Name);
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.PagesNumber, p =>
            {
                p.OwnsOne(c => c.Text);
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.PagesRange, p =>
            {
                p.OwnsOne(c => c.Text);
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.Publisher, p =>
            {
                p.OwnsOne(c => c.GroupPublisher, b => b.OwnsMany(d => d.TextsPublisher, a =>
                {
                    a.HasForeignKey("GroupPublisherId");
                    a.Property<string>("Id");
                    a.HasKey("GroupPublisherId", "Id");
                }));
                p.OwnsOne(c => c.YearDatePublisher, b => b.OwnsOne(d => d.DatePublisher, k => k.OwnsMany(t => t.DatePartsPublisher, a=> 
                {
                    a.HasForeignKey("DateId");
                    a.Property<string>("Id");
                    a.HasKey("DateId", "Id");
                })));
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.Publishuniver, p =>
            {
                p.OwnsOne(c => c.GroupUniver, b => b.OwnsMany(d => d.TextsUniver, a =>
                {
                    a.HasForeignKey("GroupUniverId");
                    a.Property<string>("Id");
                    a.HasKey("GroupUniverId", "Id");
                }));
                p.OwnsOne(c => c.YearDateUniver, b => b.OwnsOne(d => d.DateUniver, k => k.OwnsMany(t => t.DatePartsUniver, a =>
                {
                    a.HasForeignKey("DateId");
                    a.Property<string>("Id");
                    a.HasKey("DateId", "Id");
                })));
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.PublishVolume, p =>
            {
                p.OwnsOne(c => c.Text);
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.Title, p =>
            {

            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.Webdoc, p =>
            {
                p.OwnsOne(c => c.Group, b => b.OwnsMany(d => d.Texts, a =>
                {
                    a.HasForeignKey("GroupId");
                    a.Property<string>("Id");
                    a.HasKey("GroupId", "Id");
                }));
            });
            modelBuilder.Entity<Entities.Style.Style>().OwnsOne(u => u.YearDateStyle, p =>
            {
                p.OwnsOne(c => c.Date, b => b.OwnsMany(d => d.DateParts, a =>
                {
                    a.HasForeignKey("DateId");
                    a.Property<string>("Id");
                    a.HasKey("DateId", "Id");
                }));
            });
        }*/
    }
}
