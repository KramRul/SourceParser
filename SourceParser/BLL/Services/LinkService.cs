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
    public class LinkService : BaseService, ILinkService
    {
        public LinkService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task CreateLink(DocumentMod document, StyleMod style, string value)
        {
            var generatedValue = "";

            if (string.IsNullOrEmpty(value))
            {
                generatedValue = GenerateLinkValue(document, style, value);
            }
            else
            {
                generatedValue = value;
            }

            var linkDB = new DAL.Entities.Reference()
            {
                Value = generatedValue
            };
            await _database.References.Create(linkDB, document.Id, style.Id);
        }

        public string GenerateLinkValue(DocumentMod document, StyleMod style, string value)
        {
            var valueResult = "";
            switch (document.Type)
            {
                case DAL.Enums.DocumentType.Article:
                    valueResult = $"{style.AuthorFirst.Label.Prefix}{document.Author.Name}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}" +
                        $"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}" +
                        $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix} " +
                        $"{document.Date.ToShortDateString()} " +
                        $"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}" +
                        $"{document.Edition} " +
                        $"{style.PagesRange.Text.Prefix}{document.Pages.PageFirst}{style.PageRangeDelimiter}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}";
                    break;
                case DAL.Enums.DocumentType.Conference:
                    valueResult = $"{style.AuthorFirst.Label.Prefix}{document.Author.Name}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}" +
                        $"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}" +
                        $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.TitleOfConference.Text.Prefix}{document.TitleOfConference}{style.TitleOfConference.Text.Suffix}" +
                        $"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix} " +
                        $"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Address}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}" +
                        $"{document.Date.ToShortDateString()} " +
                        $"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}" +
                        $"{style.PagesRange.Text.Prefix}{document.Pages.PageFirst}{style.PageRangeDelimiter}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}";
                    break;
                case DAL.Enums.DocumentType.Book:
                    valueResult = $"{style.AuthorFirst.Label.Prefix}{document.Author.Name}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}" +
                        $"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}" +
                        $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix} " +
                        $"{document.Date.ToShortDateString()} " +
                        $"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}" +
                        $"{style.PagesRange.Text.Prefix}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}";
                    break;
                case DAL.Enums.DocumentType.Thesis:
                    valueResult = $"{style.AuthorFirst.Label.Prefix}{document.Author.Name}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}" +
                        $"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}" +
                        $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix} " +
                        $"{document.Date.ToShortDateString()} " +
                        $"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}" +
                        $"{style.PagesRange.Text.Prefix}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}";
                    break;
                case DAL.Enums.DocumentType.Webpage:
                    valueResult = $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.Webdoc.Group.Texts.FirstOrDefault().Value} {style.Webdoc.Group.Texts.FirstOrDefault().Prefix}{style.Webdoc.Group.Texts.FirstOrDefault().Suffix}";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return valueResult;
        }

        public async Task DeleteLink(LinkMod link)
        {
            await _database.References.Delete(new DAL.Entities.Reference()
            {
                Id = link.Id,
                Value = link.Value,
                Document = link.Document,
                DocumentId = link.DocumentId,
                StyleId = link.StyleId,
                Style = link.Style
            });
        }

        public async Task<ObservableCollection<LinkMod>> GetAllByDocumentId(string docId)
        {
            var links = await _database.References.GetAllByDocumentId(docId);

            var linksList = links.Select(link => new LinkMod()
            {
                Value = link.Value,
                Id = link.Id,
                DocumentId = link.DocumentId,
                Document = link.Document,
                StyleId = link.StyleId,
                Style = link.Style
            }).ToList();

            var result = new ObservableCollection<LinkMod>(linksList);

            return result;
        }

        public async Task UpdateLink(LinkMod link, DocumentMod document, StyleMod style, string value)
        {
            var generatedValue = "";

            if (string.IsNullOrEmpty(value))
            {
                generatedValue = GenerateLinkValue(document, style, value);
            }
            else
            {
                generatedValue = value;
            }

            var styles = await _database.Styles.GetAll();
            var changedStyle = styles.Where(s => s.Id == style.Id).Select(s => s).SingleOrDefault();

            var linkDB = new DAL.Entities.Reference()
            {
                Id = link.Id,
                Value = generatedValue,
                DocumentId = link.DocumentId,
                Document = link.Document,
                StyleId = changedStyle.Id,
                Style = changedStyle
            };
            await _database.References.Update(linkDB, link.DocumentId, link.StyleId);
        }
    }
}
