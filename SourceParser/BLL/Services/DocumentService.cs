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
    public class DocumentService : BaseService, IDocumentService
    {
        public DocumentService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<ObservableCollection<DocumentMod>> GetAllDocuments()
        {
            var documents = await _database.Documents.GetAll();

            var documentsList = documents.Select(document => new DocumentMod()
            {
                Id = document.Id,
                Title = document.Title,
                AdditionalInf = document.AdditionalInf,
                Date = document.Date,
                Edition = document.Edition,
                Language = document.Language,
                Pages = document.Pages,
                Type = document.Type,
                URLAdress = document.URLAdress,
                Volume = document.Volume,
                Author = document.Author,
                Co_Author = document.Co_Author,
                Editor = document.Editor,
                Publisher = document.Publisher,
                Translator = document.Translator
            }).ToList();

            var result = new ObservableCollection<DocumentMod>(documentsList);

            return result;
        }

        public async Task CreateDocument(string title = "")
        {
            await _database.Documents.Create(new DAL.Entities.Document()
            {
                Title = title,
                AdditionalInf = "",
                Edition = "",
                Language = "",
                TitleOfConference = "",
                URLAdress = "",
                Volume = "",
                Author = new DAL.Entities.Author()
                {
                    Name = ""
                },
                Co_Author = new DAL.Entities.Co_Author()
                {
                    Name = ""
                },
                Editor = new DAL.Entities.Editor()
                {
                    Name = ""
                },
                Pages = new DAL.Entities.Page()
                {
                    PageFirst = "",
                    PageLast = ""
                },
                Publisher = new DAL.Entities.Publisher()
                {
                    Name = "",
                    Address = ""
                },
                Translator = new DAL.Entities.Translator()
                {
                    Name = ""
                }
            });
        }

        public async Task UpdateDocument(DocumentMod document)
        {
            await _database.Documents.Update(new DAL.Entities.Document()
            {
                Id = document.Id,
                Title = document.Title,
                AdditionalInf = document.AdditionalInf,
                Date = document.Date,
                Edition = document.Edition,
                Language = document.Language,
                PageId = document.Pages.Id,
                Pages = document.Pages,
                Type = document.Type,
                URLAdress = document.URLAdress,
                Volume = document.Volume,
                AuthorId = document.Author.Id,
                Author = document.Author,
                Co_AuthorId = document.Co_Author.Id,
                Co_Author = document.Co_Author,
                EditorId = document.Editor.Id,
                Editor = document.Editor,
                PublisherId = document.Publisher.Id,
                Publisher = document.Publisher,
                TranslatorId = document.Translator.Id,
                Translator = document.Translator
            }, document.Id);
        }

        public async Task DeleteDocument(DocumentMod document)
        {
            await _database.Documents.Delete(new DAL.Entities.Document()
            {
                Id = document.Id,
                Title = document.Title,
                AdditionalInf = document.AdditionalInf,
                Date = document.Date,
                Edition = document.Edition,
                Language = document.Language,
                Pages = document.Pages,
                Type = document.Type,
                URLAdress = document.URLAdress,
                Volume = document.Volume,
                Author = document.Author,
                Co_Author = document.Co_Author,
                Editor = document.Editor,
                Publisher = document.Publisher,
                Translator = document.Translator
            });
        }
    }
}
