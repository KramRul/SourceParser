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
            var strBuilder = new StringBuilder();
            switch (document.Type)
            {
                case DAL.Enums.DocumentType.Article:
                    if (style.AuthorFirst.Label.Form == "short")
                    {
                        var surnameInitial = document.Author.Surname.Substring(0, 1);
                        var patronymicInitial = "";
                        if (!string.IsNullOrEmpty(document.Author.Patronymic))
                        {
                            patronymicInitial = $"{document.Author.Patronymic.Substring(0, 1)}{style.AuthorFirst.Name.InitializeWith}";
                        }
                        var initials = $"{surnameInitial}{style.AuthorFirst.Name.InitializeWith}{patronymicInitial}";
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {initials}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }
                    else
                    {
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {document.Author.Name} {document.Author.Patronymic} {style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }

                    strBuilder.Append($"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}");
                    strBuilder.Append($"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}");
                    strBuilder.Append($"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}");

                    if (style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers.FirstOrDefault().NamePublisher == "year")
                    {
                        strBuilder.Append($"{document.Date.ToString("yyyy")} ");
                    }
                    else
                    {
                        strBuilder.Append($"{document.Date.ToString("dd-MM-yyyy")} ");
                    }

                    strBuilder.Append($"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}");
                    strBuilder.Append($"{document.Edition} ");
                    strBuilder.Append($"{style.PagesRange.Text.Prefix}{document.Pages.PageFirst}{style.PageRangeDelimiter}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}");

                    valueResult = strBuilder.ToString();
                    strBuilder.Clear();
                    break;
                case DAL.Enums.DocumentType.Conference:
                    if (style.AuthorFirst.Label.Form == "short")
                    {
                        var surnameInitial = document.Author.Surname.Substring(0, 1);
                        var patronymicInitial = "";
                        if (!string.IsNullOrEmpty(document.Author.Patronymic))
                        {
                            patronymicInitial = $"{document.Author.Patronymic.Substring(0, 1)}{style.AuthorFirst.Name.InitializeWith}";
                        }
                        var initials = $"{surnameInitial}{style.AuthorFirst.Name.InitializeWith}{patronymicInitial}";
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {initials}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }
                    else
                    {
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {document.Author.Name} {document.Author.Patronymic} {style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }

                    strBuilder.Append($"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}");
                    strBuilder.Append($"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}");
                    strBuilder.Append($"{style.TitleOfConference.Text.Prefix}{document.TitleOfConference}{style.TitleOfConference.Text.Suffix}");
                    strBuilder.Append($"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}");
                    strBuilder.Append($"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Address}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}");

                    if (style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers.FirstOrDefault().NamePublisher == "year")
                    {
                        strBuilder.Append($"{document.Date.ToString("yyyy")} ");
                    }
                    else
                    {
                        strBuilder.Append($"{document.Date.ToString("dd-MM-yyyy")} ");
                    }

                    strBuilder.Append($"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}");
                    strBuilder.Append($"{style.PagesRange.Text.Prefix}{document.Pages.PageFirst}{style.PageRangeDelimiter}{document.Pages.PageLast}{style.PagesRange.Text.Suffix}");

                    valueResult = strBuilder.ToString();
                    strBuilder.Clear();
                    break;
                case DAL.Enums.DocumentType.Book:
                    if (style.AuthorFirst.Label.Form == "short")
                    {
                        var surnameInitial = document.Author.Surname.Substring(0, 1);
                        var patronymicInitial = "";
                        if (!string.IsNullOrEmpty(document.Author.Patronymic))
                        {
                            patronymicInitial = $"{document.Author.Patronymic.Substring(0, 1)}{style.AuthorFirst.Name.InitializeWith}";
                        }
                        var initials = $"{surnameInitial}{style.AuthorFirst.Name.InitializeWith}{patronymicInitial}";
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {initials}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }
                    else
                    {
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {document.Author.Name} {document.Author.Patronymic} {style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }

                    strBuilder.Append($"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}");
                    strBuilder.Append($"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}");
                    strBuilder.Append($"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}");

                    if (style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers.FirstOrDefault().NamePublisher == "year")
                    {
                        strBuilder.Append($"{document.Date.ToString("yyyy")} ");
                    }
                    else
                    {
                        strBuilder.Append($"{document.Date.ToString("dd-MM-yyyy")} ");
                    }

                    strBuilder.Append($"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}");

                    strBuilder.Append($"{style.PagesNumber.Text.Prefix}{document.Pages.CountOfPages}{style.PagesNumber.Text.Suffix}");

                    valueResult = strBuilder.ToString();
                    strBuilder.Clear();
                    break;
                case DAL.Enums.DocumentType.Thesis:
                    if (style.AuthorFirst.Label.Form == "short")
                    {
                        var surnameInitial = document.Author.Surname.Substring(0, 1);
                        var patronymicInitial = "";
                        if (!string.IsNullOrEmpty(document.Author.Patronymic))
                        {
                            patronymicInitial = $"{document.Author.Patronymic.Substring(0, 1)}{style.AuthorFirst.Name.InitializeWith}";
                        }
                        var initials = $"{surnameInitial}{style.AuthorFirst.Name.InitializeWith}{patronymicInitial}";
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {initials}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }
                    else
                    {
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {document.Author.Name} {document.Author.Patronymic} {style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }

                    strBuilder.Append($"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}");
                    strBuilder.Append($"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}");
                    strBuilder.Append(": Thesis (Doctorate) / ");
                    strBuilder.Append($"{style.Publishuniver.GroupUniver.TextUnivers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publishuniver.GroupUniver.TextUnivers.FirstOrDefault().Suffix}");

                    if (style.Publishuniver.YearDateUniver.DateUniver.DatePartUnivers.FirstOrDefault().NameUniver == "year")
                    {
                        strBuilder.Append($"{document.Date.ToString("yyyy")} ");
                    }
                    else
                    {
                        strBuilder.Append($"{document.Date.ToString("dd-MM-yyyy")} ");
                    }

                    strBuilder.Append($"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}");

                    strBuilder.Append($"{style.PagesNumber.Text.Prefix}{document.Pages.CountOfPages}{style.PagesNumber.Text.Suffix}");

                    valueResult = strBuilder.ToString();
                    strBuilder.Clear();
                    break;
                case DAL.Enums.DocumentType.Webpage:
                    valueResult = $"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}" +
                        $"{style.Webdoc.Group.Texts.FirstOrDefault().Value} {style.Webdoc.Group.Texts.FirstOrDefault().Prefix}{style.Webdoc.Group.Texts.FirstOrDefault().Suffix}";
                    break;
                default:
                    if (style.AuthorFirst.Label.Form == "short")
                    {
                        var surnameInitial = document.Author.Surname.Substring(0, 1);
                        var patronymicInitial = "";
                        if (!string.IsNullOrEmpty(document.Author.Patronymic))
                        {
                            patronymicInitial = $"{document.Author.Patronymic.Substring(0, 1)}{style.AuthorFirst.Name.InitializeWith}";
                        }
                        var initials = $"{surnameInitial}{style.AuthorFirst.Name.InitializeWith}{patronymicInitial}";
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {initials}{style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }
                    else
                    {
                        strBuilder.Append($"{style.AuthorFirst.Label.Prefix}{document.Author.Surname} {document.Author.Name} {document.Author.Patronymic} {style.AuthorFirst.Label.Suffix}{style.AuthorFirst.Name.Delimiter}");
                    }

                    strBuilder.Append($"{style.AuthorSecond.Label.Prefix}{document.Co_Author.Name}{style.AuthorSecond.Label.Suffix}{style.AuthorSecond.Name.Delimiter}");
                    strBuilder.Append($"{style.Title.Text.Prefix}{document.Title}{style.Title.Text.Suffix}");
                    strBuilder.Append($"{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Prefix}{document.Publisher.Name}{style.Publisher.GroupPublisher.TextPublishers.FirstOrDefault().Suffix}");

                    if (style.Publisher.YearDatePublisher.DatePublisher.DatePartPublishers.FirstOrDefault().NamePublisher == "year")
                    {
                        strBuilder.Append($"{document.Date.ToString("yyyy")} ");
                    }
                    else
                    {
                        strBuilder.Append($"{document.Date.ToString("dd-MM-yyyy")} ");
                    }

                    strBuilder.Append($"{style.PublishVolume.Text.Prefix}{document.Volume}{style.PublishVolume.Text.Suffix}");

                    strBuilder.Append($"{style.PagesNumber.Text.Prefix}{document.Pages.CountOfPages}{style.PagesNumber.Text.Suffix}");

                    valueResult = strBuilder.ToString();
                    strBuilder.Clear();
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

        public async Task<ObservableCollection<LinkMod>> GetAll()
        {
            var links = await _database.References.GetAll();

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

        public async Task<ObservableCollection<LinkMod>> GetAllFromLines(List<string> lines)
        {
            var links = await _database.References.GetAll();

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
