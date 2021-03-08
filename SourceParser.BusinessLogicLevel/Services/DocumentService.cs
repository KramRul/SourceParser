using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers;
using SourceParser.BusinessLogicLevel.Helpers.DecisionTreeHelpers.Models;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.Enums;
using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using SourceParser.Excel;
using SourceParser.Models;
using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class DocumentService : BaseService, IDocumentService
    {
        private readonly IDecisionTreeService<string> _accordBasedDecisionTreeService;
        public DocumentService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _accordBasedDecisionTreeService = new DecisionTreeService<string>(unitOfWork, new AccordBasedDecisionTreeHelper<string>());
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
            await _database.Documents.Create(new DataAccessLevel.Entities.Document()
            {
                Title = title,
                AdditionalInf = "",
                Edition = "",
                Language = "",
                TitleOfConference = "",
                URLAdress = "",
                Volume = "",
                Author = new DataAccessLevel.Entities.Author()
                {
                    Name = "",
                    Surname = "",
                    Patronymic = ""
                },
                Co_Author = new DataAccessLevel.Entities.Co_Author()
                {
                    Name = ""
                },
                Editor = new DataAccessLevel.Entities.Editor()
                {
                    Name = ""
                },
                Pages = new DataAccessLevel.Entities.Page()
                {
                    CountOfPages = "",
                    PageFirst = "",
                    PageLast = ""
                },
                Publisher = new DataAccessLevel.Entities.Publisher()
                {
                    Name = "",
                    Address = ""
                },
                Translator = new DataAccessLevel.Entities.Translator()
                {
                    Name = ""
                }
            });
        }

        public async Task CreateDocumentsRange(List<DocumentMod> documents)
        {
            foreach (var doc in documents)
            {
                await _database.Documents.Create(new DataAccessLevel.Entities.Document()
                {
                    Title = (!string.IsNullOrEmpty(doc.Title)) ? doc.Title : "",
                    AdditionalInf = (!string.IsNullOrEmpty(doc.AdditionalInf)) ? doc.AdditionalInf : "",
                    Edition = (!string.IsNullOrEmpty(doc.Edition)) ? doc.Edition : "",
                    Language = (!string.IsNullOrEmpty(doc.Language)) ? doc.Language : "",
                    TitleOfConference = (!string.IsNullOrEmpty(doc.TitleOfConference)) ? doc.TitleOfConference : "",
                    URLAdress = (!string.IsNullOrEmpty(doc.URLAdress)) ? doc.URLAdress : "",
                    Volume = (!string.IsNullOrEmpty(doc.Volume)) ? doc.Volume : "",
                    Author = new DataAccessLevel.Entities.Author()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Author?.Name)) ? doc.Author?.Name : "",
                        Surname = (!string.IsNullOrEmpty(doc.Author?.Surname)) ? doc.Author?.Surname : "",
                        Patronymic = (!string.IsNullOrEmpty(doc.Author?.Patronymic)) ? doc.Author?.Patronymic : "",
                    },
                    Co_Author = new DataAccessLevel.Entities.Co_Author()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Co_Author?.Name)) ? doc.Co_Author?.Name : ""
                    },
                    Editor = new DataAccessLevel.Entities.Editor()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Editor?.Name)) ? doc.Editor?.Name : ""
                    },
                    Pages = new DataAccessLevel.Entities.Page()
                    {
                        CountOfPages = (!string.IsNullOrEmpty(doc.Pages?.CountOfPages)) ? doc.Pages?.CountOfPages : "",
                        PageFirst = (!string.IsNullOrEmpty(doc.Pages?.PageFirst)) ? doc.Pages?.PageFirst : "",
                        PageLast = (!string.IsNullOrEmpty(doc.Pages?.PageLast)) ? doc.Pages?.PageLast : ""
                    },
                    Publisher = new DataAccessLevel.Entities.Publisher()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Publisher?.Name)) ? doc.Publisher?.Name : "",
                        Address = (!string.IsNullOrEmpty(doc.Publisher?.Address)) ? doc.Publisher?.Address : ""
                    },
                    Translator = new DataAccessLevel.Entities.Translator()
                    {
                        Name = (!string.IsNullOrEmpty(doc.Translator?.Name)) ? doc.Translator?.Name : ""
                    }
                });
            }
        }

        public async Task UpdateDocument(DocumentMod document)
        {
            await _database.Documents.Update(new DataAccessLevel.Entities.Document()
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
            await _database.Documents.Delete(new DataAccessLevel.Entities.Document()
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

                document = GetDocumentForEdit(line);

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
                    document.Author = new DataAccessLevel.Entities.Author()
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
                        document.Author = new DataAccessLevel.Entities.Author()
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
                        document.Author = new DataAccessLevel.Entities.Author()
                        {
                            Patronymic = subString
                        };
                    }
                }
                if (line.Contains("%COAUTHOR%"))
                {
                    var subString = GetSubString(line, "%COAUTHOR%", "#COAUTHOR#");
                    document.Co_Author = new DataAccessLevel.Entities.Co_Author()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%PUBLISHERNAME%"))
                {
                    var subString = GetSubString(line, "%PUBLISHERNAME%", "#PUBLISHERNAME#");
                    document.Publisher = new DataAccessLevel.Entities.Publisher()
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
                        document.Publisher = new DataAccessLevel.Entities.Publisher()
                        {
                            Address = subString
                        };
                    }
                }
                if (line.Contains("%TRANSLATOR%"))
                {
                    var subString = GetSubString(line, "%TRANSLATOR%", "#TRANSLATOR#");
                    document.Translator = new DataAccessLevel.Entities.Translator()
                    {
                        Name = subString
                    };
                }
                if (line.Contains("%EDITOR%"))
                {
                    var subString = GetSubString(line, "%EDITOR%", "#EDITOR#");
                    document.Editor = new DataAccessLevel.Entities.Editor()
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
                    document.Pages = new DataAccessLevel.Entities.Page()
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
                        document.Pages = new DataAccessLevel.Entities.Page()
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
                        document.Pages = new DataAccessLevel.Entities.Page()
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

        public async Task<ObservableCollection<DocumentMod>> GetDocumentsInfFromLinesUsingDecisionTree(List<string> lines)
        {
            var documents = await GetDocumentsInfFromLines(lines);

            documents = await PredictDocumentsTypesUsingDecisionTree(documents);

            return documents;
        }

        private string GetSubString(string line, string startKey, string endKey)
        {
            int pFrom = line.IndexOf(startKey) + startKey.Length;
            int pTo = line.LastIndexOf(endKey);

            var result = line.Substring(pFrom, pTo - pFrom);
            return result;
        }

        private DocumentMod GetDocumentForEdit(string line)
        {
            var document = new DocumentMod();
            if (!string.IsNullOrEmpty(line))
            {
                document.AdditionalInf = line;
            }
            else
            {
                return null;
            }

            var substr = GetAllSubStrings(line);
            foreach (var str in substr)
            {
                if (int.TryParse(str, out int i))
                {
                    if (i.ToString().Length == 4)
                    {
                        var date = new DateTime();
                        document.Date = date.AddYears(i);
                        continue;
                    }
                    if (document.Pages == null)
                    {
                        document.Pages = new DataAccessLevel.Entities.Page()
                        {
                            CountOfPages = str
                        };
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(document.Pages.CountOfPages))
                        {
                            document.Pages.CountOfPages = str;
                        }
                        else if (string.IsNullOrEmpty(document.Pages.PageFirst))
                        {
                            document.Pages.PageFirst = str;
                        }
                        else if (string.IsNullOrEmpty(document.Pages.PageLast))
                        {
                            document.Pages.PageLast = str;
                        }
                    }
                }

                if (string.IsNullOrEmpty(document.Author?.Surname))
                {
                    document.Author = new DataAccessLevel.Entities.Author
                    {
                        Surname = str
                    };
                    continue;
                }
                if (string.IsNullOrEmpty(document.Author?.Name))
                {
                    if (document.Author == null)
                    {
                        document.Author = new DataAccessLevel.Entities.Author
                        {
                            Name = str
                        };
                    }
                    else
                    {
                        document.Author.Name = str;
                    }
                    continue;
                }
                if (string.IsNullOrEmpty(document.Author?.Patronymic))
                {
                    if (document.Author == null)
                    {
                        document.Author = new DataAccessLevel.Entities.Author
                        {
                            Patronymic = str
                        };
                    }
                    else
                    {
                        document.Author.Patronymic = str;
                    }
                    continue;
                }
                if (string.IsNullOrEmpty(document.Co_Author?.Name))
                {
                    document.Co_Author = new DataAccessLevel.Entities.Co_Author
                    {
                        Name = str
                    };
                    continue;
                }
                if (string.IsNullOrEmpty(document.Title))
                {
                    document.Title = str;
                    continue;
                }
                if (string.IsNullOrEmpty(document.Editor?.Name))
                {
                    document.Editor = new DataAccessLevel.Entities.Editor
                    {
                        Name = str
                    };
                    continue;
                }
                if (string.IsNullOrEmpty(document.Publisher?.Name))
                {
                    document.Publisher = new DataAccessLevel.Entities.Publisher
                    {
                        Name = str
                    };
                    continue;
                }
                if (string.IsNullOrEmpty(document.TitleOfConference))
                {
                    document.TitleOfConference = str;
                    continue;
                }
                if (string.IsNullOrEmpty(document.Translator?.Name))
                {
                    document.Translator = new DataAccessLevel.Entities.Translator
                    {
                        Name = str
                    };
                    continue;
                }
                if (string.IsNullOrEmpty(document.URLAdress))
                {
                    document.URLAdress = str;
                    continue;
                }
                if (string.IsNullOrEmpty(document.Edition))
                {
                    document.Edition = str;
                    continue;
                }
                if (string.IsNullOrEmpty(document.Volume))
                {
                    document.Volume = str;
                    continue;
                }
            }

            return document;
        }

        private async Task<ObservableCollection<DocumentMod>> PredictDocumentsTypesUsingDecisionTree(ObservableCollection<DocumentMod> documents)
        {
            foreach (var document in documents)
            {
                document.Type = await PredictDocumentTypesUsingDecisionTree(document.AdditionalInf);
            }

            return documents;
        }
        private async Task<DocumentType> PredictDocumentTypesUsingDecisionTree(string documentLink)
        {
            var model = DocumentLinkToBaseCsvModel(documentLink);

            var outputAttributeColumn = new BaseAttribute<string>() { Name = "Bibl Link Class", Symbols = 2 };

            var attributeNames = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "Outlook" , Value = "Sunny", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Temperature" , Value = "Hot", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Humidity" , Value = "High", Symbols = 2 },
                new BaseAttribute<string>() { Name = "Wind" , Value = "Strong", Symbols = 2 },
            };

            var answer = _accordBasedDecisionTreeService.Decide(attributeNames, outputAttributeColumn);

            return StringAnswerToDocumentType(answer);
        }

        private BaseCsvModel DocumentLinkToBaseCsvModel(string documentLink)
        {
            var baseCsvModel = new BaseCsvModel();

            baseCsvModel.SourceLink = documentLink;
            baseCsvModel.SearchParameter0 = documentLink.Contains("учеб.").ToString();
            baseCsvModel.SearchParameter1 = documentLink.Contains("Университет").ToString();
            baseCsvModel.SearchParameter2 = documentLink.Contains("учеб. пособие").ToString();
            baseCsvModel.SearchParameter3 = documentLink.Contains("довідник").ToString();
            baseCsvModel.SearchParameter4 = documentLink.Contains("tutorials").ToString();
            baseCsvModel.SearchParameter5 = documentLink.Contains("tutorial").ToString();
            baseCsvModel.SearchParameter6 = documentLink.Contains("guide").ToString();
            baseCsvModel.SearchParameter7 = documentLink.Contains("книга").ToString();
            baseCsvModel.SearchParameter8 = documentLink.Contains("Book").ToString();
            baseCsvModel.SearchParameter9 = documentLink.Contains("Volume").ToString();
            //baseCsvModel.SearchParameter10 = documentLink.Contains("Т. {d}").ToString();
            baseCsvModel.SearchParameter11 = documentLink.Contains("Litres").ToString();
            baseCsvModel.SearchParameter12 = documentLink.Contains("Избранные произведения").ToString();
            baseCsvModel.SearchParameter13 = documentLink.Contains("dictionary").ToString();
            baseCsvModel.SearchParameter14 = documentLink.Contains("словарь").ToString();
            //baseCsvModel.SearchParameter15 = documentLink.Contains("Т. {d}–{d}").ToString();
            //baseCsvModel.SearchParameter16 = documentLink.Contains("Vols. {d}–{d}").ToString();
            baseCsvModel.SearchParameter17 = documentLink.Contains("Vol. {d}").ToString();
            baseCsvModel.SearchParameter18 = documentLink.Contains("Ред.").ToString();
            baseCsvModel.SearchParameter19 = documentLink.Contains("Ed.").ToString();
            baseCsvModel.SearchParameter20 = documentLink.Contains("Eds.").ToString();
            baseCsvModel.SearchParameter21 = documentLink.Contains("doi").ToString();
            baseCsvModel.SearchParameter22 = documentLink.Contains("[CD]").ToString();
            baseCsvModel.SearchParameter23 = documentLink.Contains("http://www.{l}").ToString();
            baseCsvModel.SearchParameter24 = documentLink.Contains("http://{l}").ToString();
            baseCsvModel.SearchParameter25 = documentLink.Contains("№{d}").ToString();
            baseCsvModel.SearchParameter26 = documentLink.Contains("№ {d}").ToString();
            baseCsvModel.SearchParameter27 = documentLink.Contains("{d}(d)").ToString();
            baseCsvModel.SearchParameter28 = documentLink.Contains("{d}(Suppl. {d})").ToString();
            baseCsvModel.SearchParameter29 = documentLink.Contains("No. {d}").ToString();
            baseCsvModel.SearchParameter30 = documentLink.Contains("[Спец. выпуск]").ToString();
            baseCsvModel.SearchParameter31 = documentLink.Contains("[Special issue]").ToString();
            baseCsvModel.SearchParameter32 = documentLink.Contains("[Cпец. раздел]").ToString();
            baseCsvModel.SearchParameter33 = documentLink.Contains("[Special section]").ToString();
            baseCsvModel.SearchParameter34 = documentLink.Contains("тез.").ToString();
            baseCsvModel.SearchParameter35 = documentLink.Contains("материалы").ToString();
            baseCsvModel.SearchParameter36 = documentLink.Contains("конф.").ToString();
            baseCsvModel.SearchParameter37 = documentLink.Contains("Conference").ToString();
            baseCsvModel.SearchParameter38 = documentLink.Contains("[Электронный ресурс]").ToString();
            baseCsvModel.SearchParameter39 = documentLink.Contains("Режим доступа").ToString();
            baseCsvModel.SearchParameter40 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter41 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter42 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter43 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter44 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter45 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter46 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter47 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter48 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter49 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter50 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter51 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter52 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter53 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter54 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter55 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter56 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter57 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter58 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter59 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter60 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter61 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter62 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter63 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter64 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter65 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter66 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter67 = documentLink.Contains("").ToString();
            baseCsvModel.SearchParameter68 = documentLink.Contains("").ToString();

            return baseCsvModel;
        }

        private DocumentType StringAnswerToDocumentType(string answer)
        {
            var type = DocumentType.Other;
            switch (answer)
            {
                case "Tutorial":
                    type = DocumentType.Tutorial;
                    break;
                case "Book":
                    type = DocumentType.Book;
                    break;
                case "ElectronicBook":
                    type = DocumentType.ElectronicBook;
                    break;
                case "MagazineArticle":
                    type = DocumentType.MagazineArticle;
                    break;
                case "Thesis":
                    type = DocumentType.Thesis;
                    break;
                case "Webpage":
                    type = DocumentType.Webpage;
                    break;
                case "СollectionOfScientificPapers":
                    type = DocumentType.СollectionOfScientificPapers;
                    break;
                case "Conference":
                    type = DocumentType.Conference;
                    break;
                case "Document":
                    type = DocumentType.Document;
                    break;
                case "Report":
                    type = DocumentType.Report;
                    break;
                case "Dissertation":
                    type = DocumentType.Dissertation;
                    break;
                case "DissertationAbstract":
                    type = DocumentType.DissertationAbstract;
                    break;
                case "Patent":
                    type = DocumentType.Patent;
                    break;
                case "SectionOfTheBookOrArticle":
                    type = DocumentType.SectionOfTheBookOrArticle;
                    break;
                case "Article":
                    type = DocumentType.Article;
                    break;
                case "ArticleAbstract":
                    type = DocumentType.ArticleAbstract;
                    break;
                default:
                    break;
            }
            return type;
        }

        private List<string> GetAllSubStrings(string line)
        {
            var delimetrs = new char[] { ':', ';', ',', '.', '—', '/', '\\' };
            var result = line.Split(delimetrs, StringSplitOptions.RemoveEmptyEntries).ToList();
            return result;
        }
    }
}
