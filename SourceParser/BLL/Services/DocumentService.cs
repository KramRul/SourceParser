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
                    Name = "",
                    Surname = "",
                    Patronymic = ""
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
                    CountOfPages = "",
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

        public async Task CreateDocumentsRange(List<DocumentMod> documents)
        {
            foreach (var doc in documents)
            {
                await _database.Documents.Create(new DAL.Entities.Document()
                {
                    Title = (!string.IsNullOrEmpty(doc.Title)) ? doc.Title : "",
                    AdditionalInf = (!string.IsNullOrEmpty(doc.AdditionalInf)) ? doc.AdditionalInf : "",
                    Edition = (!string.IsNullOrEmpty(doc.Edition)) ? doc.Edition : "",
                    Language = (!string.IsNullOrEmpty(doc.Language)) ? doc.Language : "",
                    TitleOfConference = (!string.IsNullOrEmpty(doc.TitleOfConference)) ? doc.TitleOfConference : "",
                    URLAdress = (!string.IsNullOrEmpty(doc.URLAdress)) ? doc.URLAdress : "",
                    Volume = (!string.IsNullOrEmpty(doc.Volume)) ? doc.Volume : "",
                    Author = new DAL.Entities.Author()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Author?.Name)) ? doc.Author?.Name : "",
                        Surname = (!string.IsNullOrEmpty(doc.Author?.Surname)) ? doc.Author?.Surname : "",
                        Patronymic = (!string.IsNullOrEmpty(doc.Author?.Patronymic)) ? doc.Author?.Patronymic : "",
                    },
                    Co_Author = new DAL.Entities.Co_Author()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Co_Author?.Name)) ? doc.Co_Author?.Name : ""
                    },
                    Editor = new DAL.Entities.Editor()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Editor?.Name)) ? doc.Editor?.Name : ""
                    },
                    Pages = new DAL.Entities.Page()
                    {
                        CountOfPages = (!string.IsNullOrEmpty(doc.Pages?.CountOfPages)) ? doc.Pages?.CountOfPages : "",
                        PageFirst = (!string.IsNullOrEmpty(doc.Pages?.PageFirst)) ? doc.Pages?.PageFirst : "",
                        PageLast = (!string.IsNullOrEmpty(doc.Pages?.PageLast)) ? doc.Pages?.PageLast : ""
                    },
                    Publisher = new DAL.Entities.Publisher()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Publisher?.Name)) ? doc.Publisher?.Name : "",
                        Address = (!string.IsNullOrEmpty(doc.Publisher?.Address)) ? doc.Publisher?.Address : ""
                    },
                    Translator = new DAL.Entities.Translator()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Translator?.Name)) ? doc.Translator?.Name : ""
                    }
                });
            }
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

        public async Task<ObservableCollection<DocumentMod>> GetDocumentsInfFromLines(List<string> lines)
        {
            var documents = new ObservableCollection<DocumentMod>();
            foreach (var line in lines)
            {
                var document = new DocumentMod();

                if (line.Contains("%TITLE%"))
                {
                    var subString = GetSubString(line, "%TITLE%", "#TITLE#");
                    document.Title = subString;
                }
                if (line.Contains("%DATE%"))
                {
                    var subString = GetSubString(line, "%DATE%", "#DATE#");
                    if (DateTime.TryParse(subString, out DateTime res))
                    {
                        document.Date = res;
                    }
                }
                if (line.Contains("%AUTHORSURNAME%"))
                {
                    var subString = GetSubString(line, "%AUTHORSURNAME%", "#AUTHORSURNAME#");
                    document.Author = new DAL.Entities.Author()
                    {
                        Surname = subString
                    };
                }
                if (line.Contains("%AUTHORNAME%"))
                {
                    var subString = GetSubString(line, "%AUTHORNAME%", "#AUTHORNAME#");
                    if (document.Author != null)
                    {
                        document.Author.Name = subString;
                    }
                    else
                    {
                        document.Author = new DAL.Entities.Author()
                        {
                            Name = subString
                        };
                    }
                }
                if (line.Contains("%AUTHORPATRONIMIC%"))
                {
                    var subString = GetSubString(line, "%AUTHORPATRONIMIC%", "#AUTHORPATRONIMIC#");
                    if (document.Author != null)
                    {
                        document.Author.Patronymic = subString;
                    }
                    else
                    {
                        document.Author = new DAL.Entities.Author()
                        {
                            Patronymic = subString
                        };
                    }
                }
                if (line.Contains("%COAUTHOR%"))
                {
                    var subString = GetSubString(line, "%COAUTHOR%", "#COAUTHOR#");
                    document.Co_Author = new DAL.Entities.Co_Author()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%PUBLISHERNAME%"))
                {
                    var subString = GetSubString(line, "%PUBLISHERNAME%", "#PUBLISHERNAME#");
                    document.Publisher = new DAL.Entities.Publisher()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%PUBLISHERADDRESS%"))
                {
                    var subString = GetSubString(line, "%PUBLISHERADDRESS%", "#PUBLISHERADDRESS#");
                    if (document.Publisher != null)
                    {
                        document.Publisher.Address = subString;
                    }
                    else
                    {
                        document.Publisher = new DAL.Entities.Publisher()
                        {
                            Address = subString
                        };
                    }
                }
                if (line.Contains("%TRANSLATOR%"))
                {
                    var subString = GetSubString(line, "%TRANSLATOR%", "#TRANSLATOR#");
                    document.Translator = new DAL.Entities.Translator()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%EDITOR%"))
                {
                    var subString = GetSubString(line, "%EDITOR%", "#EDITOR#");
                    document.Editor = new DAL.Entities.Editor()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%EDITION%"))
                {
                    var subString = GetSubString(line, "%EDITION%", "#EDITION#");
                    document.Edition = subString;
                }
                if (line.Contains("%URLADRESS%"))
                {
                    var subString = GetSubString(line, "%URLADRESS%", "#URLADRESS#");
                    document.URLAdress = subString;
                }
                if (line.Contains("%LANGUAGE%"))
                {
                    var subString = GetSubString(line, "%LANGUAGE%", "#LANGUAGE#");
                    document.Language = subString;
                }
                if (line.Contains("%COUNTOFPAGES%"))
                {
                    var subString = GetSubString(line, "%COUNTOFPAGES%", "#COUNTOFPAGES#");
                    document.Pages = new DAL.Entities.Page()
                    {
                        CountOfPages = subString
                    };
                }
                if (line.Contains("%FIRSTPAGE%"))
                {
                    var subString = GetSubString(line, "%FIRSTPAGE%", "#FIRSTPAGE#");
                    if (document.Pages != null)
                    {
                        document.Pages.PageFirst = subString;
                    }
                    else
                    {
                        document.Pages = new DAL.Entities.Page()
                        {
                            PageFirst = subString
                        };
                    }
                }
                if (line.Contains("%LASTPAGE%"))
                {
                    var subString = GetSubString(line, "%LASTPAGE%", "#LASTPAGE#");
                    if (document.Pages != null)
                    {
                        document.Pages.PageLast = subString;
                    }
                    else
                    {
                        document.Pages = new DAL.Entities.Page()
                        {
                            PageLast = subString
                        };
                    }
                }
                if (line.Contains("%TITLECONF%"))
                {
                    var subString = GetSubString(line, "%TITLECONF%", "#TITLECONF#");
                    document.TitleOfConference = subString;
                }
                if (line.Contains("%VOLUME%"))
                {
                    var subString = GetSubString(line, "%VOLUME%", "#VOLUME#");
                    document.Volume = subString;
                }
                if (line.Contains("%ADDINF%"))
                {
                    var subString = GetSubString(line, "%ADDINF%", "#ADDINF#");
                    document.AdditionalInf = subString;
                }

                documents.Add(document);
            }

            return documents;
        }

        private string GetSubString(string line, string startKey, string endKey)
        {
            int pFrom = line.IndexOf(startKey) + startKey.Length;
            int pTo = line.LastIndexOf(endKey);

            var result = line.Substring(pFrom, pTo - pFrom);
            return result;
        }
    }
}
