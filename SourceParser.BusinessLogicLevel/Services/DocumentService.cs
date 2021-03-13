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
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class DocumentService : BaseService, IDocumentService
    {
        private readonly IDecisionTreeService<string> _accordBasedDecisionTreeService;
        private readonly IImportLinkDataService _importLinkDataService;
        public DocumentService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _accordBasedDecisionTreeService = new DecisionTreeService<string>(unitOfWork, new AccordBasedDecisionTreeHelper<string>());
            _importLinkDataService = new ImportLinkDataService(unitOfWork);
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
            var columns = GetListOfDataColumns();

            var rows = await CreateLearningSampleFromDatabaseDataAsync();

            var attributes = GetListOfAttributes();

            int classCount = 18;

            _accordBasedDecisionTreeService.Init("Predict Documents Types", classCount, columns, rows, attributes);

            var outputAttributeColumn = new BaseAttribute<string>() { Name = "Bibl Link Class", Symbols = 18 };

            _accordBasedDecisionTreeService.Learn(attributes, outputAttributeColumn);

            foreach (var document in documents)
            {
                document.Type = await PredictDocumentTypesUsingDecisionTree(document.AdditionalInf);
            }

            return documents;
        }

        private List<DataColumn> GetListOfDataColumns()
        {
            var columns = new List<DataColumn>()
            {
                new DataColumn("учеб."),
                new DataColumn("Университет"),
                new DataColumn("учеб. пособие"),
                new DataColumn("довідник"),
                new DataColumn("tutorials"),
                new DataColumn("tutorial"),
                new DataColumn("guide"),
                new DataColumn("книга"),
                new DataColumn("Book"),
                new DataColumn("Volume"),
                new DataColumn("Т. {d}"),
                new DataColumn("Litres"),
                new DataColumn("Избранные произведения"),
                new DataColumn("dictionary"),
                new DataColumn("словарь"),
                new DataColumn("Т. {d}–{d}"),
                new DataColumn("Vols. {d}–{d}"),
                new DataColumn("Vol. {d}"),
                new DataColumn("Ред."),
                new DataColumn("Ed."),
                new DataColumn("Eds."),
                new DataColumn("doi"),
                new DataColumn("[CD]"),
                new DataColumn("http://www.{l}"),
                new DataColumn("http://{l}"),
                new DataColumn("№{d}"),
                new DataColumn("№ {d}"),
                new DataColumn("{d}(d)"),
                new DataColumn("{d}(Suppl. {d})"),
                new DataColumn("No. {d}"),
                new DataColumn("[Спец. выпуск]"),
                new DataColumn("[Special issue]"),
                new DataColumn("[Cпец. раздел]"),
                new DataColumn("[Special section]"),
                new DataColumn("тез."),
                new DataColumn("материалы"),
                new DataColumn("конф."),
                new DataColumn("Conference"),
                new DataColumn("[Электронный ресурс]"),
                new DataColumn("Режим доступа"),
                new DataColumn("www/ URL"),
                new DataColumn("Загл. с экрана"),
                new DataColumn("интеракт. учеб."),
                new DataColumn("(CD-ROM)"),
                new DataColumn("Загл. с этикетки диска"),
                new DataColumn("сб. науч. тр."),
                new DataColumn("Set"),
                new DataColumn("Сборник науч. трудов"),
                new DataColumn("ГОСТ"),
                new DataColumn("Инструкция"),
                new DataColumn("Устав"),
                new DataColumn("Конституция"),
                new DataColumn("Constitution"),
                new DataColumn("отчет"),
                new DataColumn("Report"),
                new DataColumn("дис."),
                new DataColumn("dissertation"),
                new DataColumn("автореф."),
                new DataColumn("диплом."),
                new DataColumn("магистра"),
                new DataColumn("Master’s"),
                new DataColumn("Doctoral dissertation"),
                new DataColumn("Master’s thesis"),
                new DataColumn("Dissertation Abstracts"),
                new DataColumn("патентообладатель"),
                new DataColumn("{d,7}"),
                new DataColumn("В кн."),
                new DataColumn("In:"),
                new DataColumn("[Abstract]")
            };
            return columns;
        }

        private List<BaseAttribute<string>> GetListOfAttributes()
        {
            var attributes = new List<BaseAttribute<string>>()
            {
                new BaseAttribute<string>() { Name = "учеб." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Университет" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "учеб. пособие" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "довідник" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "tutorials", Symbols = 2 },
                new BaseAttribute<string>() { Name = "tutorial" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "guide" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "книга" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Book" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Volume" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Т. {d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Litres" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Избранные произведения" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "dictionary" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "словарь" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Т. {d}–{d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Vols. {d}–{d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Vol. {d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Ред." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Ed.", Symbols = 2 },
                new BaseAttribute<string>() { Name = "Eds." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "doi" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[CD]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "http://www.{l}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "http://{l}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "№{d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "№ {d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "{d}(d)" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "{d}(Suppl. {d})" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "No. {d}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Спец. выпуск]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Special issue]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Cпец. раздел]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Special section]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "тез." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "материалы" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "конф." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Conference" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Электронный ресурс]" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Режим доступа" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "www/ URL" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Загл. с экрана" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "интеракт. учеб." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "(CD-ROM)" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Загл. с этикетки диска" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "сб. науч. тр." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Set" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Сборник науч. трудов" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "ГОСТ" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Инструкция" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Устав" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Конституция" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Constitution" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "отчет" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Report" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "дис." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "dissertation" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "диплом." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "магистра" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Master’s" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Doctoral dissertation" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Master’s thesis" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "Dissertation Abstracts" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "патентообладатель" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "{d,7}" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "В кн." , Symbols = 2 },
                new BaseAttribute<string>() { Name = "In:" , Symbols = 2 },
                new BaseAttribute<string>() { Name = "[Abstract]" , Symbols = 2 }
            };
            return attributes;
        }

        private async Task<List<string[]>> CreateLearningSampleFromDatabaseDataAsync()
        {
            var importedLinks = await _importLinkDataService.GetAllImportedLinks();
            var rows = importedLinks.Select(importLinkData =>
            {
                return new string[]
                {
                    importLinkData.SearchParameter0,
                    importLinkData.SearchParameter1,
                    importLinkData.SearchParameter2,
                    importLinkData.SearchParameter3,
                    importLinkData.SearchParameter4,
                    importLinkData.SearchParameter5,
                    importLinkData.SearchParameter6,
                    importLinkData.SearchParameter7,
                    importLinkData.SearchParameter8,
                    importLinkData.SearchParameter9,
                    importLinkData.SearchParameter10,
                    importLinkData.SearchParameter10,
                    importLinkData.SearchParameter11,
                    importLinkData.SearchParameter12,
                    importLinkData.SearchParameter13,
                    importLinkData.SearchParameter14,
                    importLinkData.SearchParameter15,
                    importLinkData.SearchParameter16,
                    importLinkData.SearchParameter17,
                    importLinkData.SearchParameter18,
                    importLinkData.SearchParameter19,
                    importLinkData.SearchParameter20,
                    importLinkData.SearchParameter21,
                    importLinkData.SearchParameter22,
                    importLinkData.SearchParameter23,
                    importLinkData.SearchParameter24,
                    importLinkData.SearchParameter25,
                    importLinkData.SearchParameter26,
                    importLinkData.SearchParameter27,
                    importLinkData.SearchParameter28,
                    importLinkData.SearchParameter29,
                    importLinkData.SearchParameter30,
                    importLinkData.SearchParameter31,
                    importLinkData.SearchParameter32,
                    importLinkData.SearchParameter33,
                    importLinkData.SearchParameter34,
                    importLinkData.SearchParameter35,
                    importLinkData.SearchParameter36,
                    importLinkData.SearchParameter37,
                    importLinkData.SearchParameter38,
                    importLinkData.SearchParameter39,
                    importLinkData.SearchParameter40,
                    importLinkData.SearchParameter41,
                    importLinkData.SearchParameter42,
                    importLinkData.SearchParameter43,
                    importLinkData.SearchParameter44,
                    importLinkData.SearchParameter45,
                    importLinkData.SearchParameter46,
                    importLinkData.SearchParameter47,
                    importLinkData.SearchParameter48,
                    importLinkData.SearchParameter49,
                    importLinkData.SearchParameter50,
                    importLinkData.SearchParameter51,
                    importLinkData.SearchParameter52,
                    importLinkData.SearchParameter53,
                    importLinkData.SearchParameter54,
                    importLinkData.SearchParameter55,
                    importLinkData.SearchParameter56,
                    importLinkData.SearchParameter57,
                    importLinkData.SearchParameter58,
                    importLinkData.SearchParameter59,
                    importLinkData.SearchParameter60,
                    importLinkData.SearchParameter61,
                    importLinkData.SearchParameter62,
                    importLinkData.SearchParameter63,
                    importLinkData.SearchParameter64,
                    importLinkData.SearchParameter65,
                    importLinkData.SearchParameter66,
                    importLinkData.SearchParameter67,
                    importLinkData.SearchParameter68,
                    importLinkData.SearchParameter69
                };
            });
            return rows.ToList();
        }

        private async Task<DocumentType> PredictDocumentTypesUsingDecisionTree(string documentLink)
        {
            var model = DocumentLinkToBaseCsvModel(documentLink);

            var outputAttributeColumn = new BaseAttribute<string>() { Name = "Bibl Link Class", Symbols = 16 };

            /*var attributeNames = new List<BaseAttribute<string>>
            {
                new BaseAttribute<string>() { Name = "Outlook" , Value = "Sunny", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Temperature" , Value = "Hot", Symbols = 3 },
                new BaseAttribute<string>() { Name = "Humidity" , Value = "High", Symbols = 2 },
                new BaseAttribute<string>() { Name = "Wind" , Value = "Strong", Symbols = 2 },
            };*/

            var attributeNames = BaseCsvModelToBaseAttributes(model);

            var answer = _accordBasedDecisionTreeService.Decide(attributeNames, outputAttributeColumn);

            return StringAnswerToDocumentType(answer);
        }

        private List<BaseAttribute<string>> BaseCsvModelToBaseAttributes(BaseCsvModel model)
        {
            var attributeNames = new List<BaseAttribute<string>>();

            Type modelType = model.GetType();
            IList<PropertyInfo> properties = new List<PropertyInfo>(modelType.GetProperties());

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(model, null);

                if (property.Name.Contains("SearchParameter"))
                {
                    attributeNames.Add(new BaseAttribute<string>() { Name = "Outlook", Value = "Sunny", Symbols = 3 });
                }
            }

            return attributeNames;
        }

        private BaseCsvModel DocumentLinkToBaseCsvModel(string documentLink)
        {
            var baseCsvModel = new BaseCsvModel();

            baseCsvModel.SourceLink = documentLink;
            baseCsvModel.SearchParameter0 = documentLink.ToLower().Contains("учеб.").ToString();
            baseCsvModel.SearchParameter1 = documentLink.ToLower().Contains("университет").ToString();
            baseCsvModel.SearchParameter2 = documentLink.ToLower().Contains("учеб. пособие").ToString();
            baseCsvModel.SearchParameter3 = documentLink.ToLower().Contains("довідник").ToString();
            baseCsvModel.SearchParameter4 = documentLink.ToLower().Contains("tutorials").ToString();
            baseCsvModel.SearchParameter5 = documentLink.ToLower().Contains("tutorial").ToString();
            baseCsvModel.SearchParameter6 = documentLink.ToLower().Contains("guide").ToString();
            baseCsvModel.SearchParameter7 = documentLink.ToLower().Contains("книга").ToString();
            baseCsvModel.SearchParameter8 = documentLink.ToLower().Contains("book").ToString();
            baseCsvModel.SearchParameter9 = documentLink.ToLower().Contains("volume").ToString();

            //baseCsvModel.SearchParameter10 = documentLink.Contains("t. {d}").ToString();
            baseCsvModel.SearchParameter10 = Regex.Match(documentLink, "т\\. \\d+", RegexOptions.IgnoreCase).Success.ToString();

            baseCsvModel.SearchParameter11 = documentLink.ToLower().Contains("litres").ToString();
            baseCsvModel.SearchParameter12 = documentLink.ToLower().Contains("избранные произведения").ToString();
            baseCsvModel.SearchParameter13 = documentLink.ToLower().Contains("dictionary").ToString();
            baseCsvModel.SearchParameter14 = documentLink.ToLower().Contains("словарь").ToString();

            //baseCsvModel.SearchParameter15 = documentLink.Contains("t. {d}–{d}").ToString();
            baseCsvModel.SearchParameter15 = Regex.Match(documentLink, "т\\. \\d+[\\–|\\-]\\d+", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter16 = documentLink.Contains("vols. {d}–{d}").ToString();
            baseCsvModel.SearchParameter16 = Regex.Match(documentLink, "vols\\. \\d+[\\–|\\-]\\d+", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter17 = documentLink.ToLower().Contains("vol. {d}").ToString();
            baseCsvModel.SearchParameter17 = Regex.Match(documentLink, "vol\\. \\d+", RegexOptions.IgnoreCase).Success.ToString();

            baseCsvModel.SearchParameter18 = documentLink.ToLower().Contains("ред.").ToString();
            baseCsvModel.SearchParameter19 = documentLink.ToLower().Contains("ed.").ToString();
            baseCsvModel.SearchParameter20 = documentLink.ToLower().Contains("eds.").ToString();
            baseCsvModel.SearchParameter21 = documentLink.ToLower().Contains("doi").ToString();
            baseCsvModel.SearchParameter22 = documentLink.ToLower().Contains("[cd]").ToString();
            baseCsvModel.SearchParameter23 = documentLink.ToLower().Contains("http://www").ToString();
            baseCsvModel.SearchParameter24 = documentLink.ToLower().Contains("http://").ToString();

            //baseCsvModel.SearchParameter25 = documentLink.ToLower().Contains("№{d}").ToString();
            baseCsvModel.SearchParameter25 = Regex.Match(documentLink, "№\\d+", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter26 = documentLink.ToLower().Contains("№ {d}").ToString();
            baseCsvModel.SearchParameter26 = Regex.Match(documentLink, "№ \\d+", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter27 = documentLink.ToLower().Contains("{d}(d)").ToString();
            baseCsvModel.SearchParameter27 = Regex.Match(documentLink, "\\d+\\(\\d+\\)", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter28 = documentLink.ToLower().Contains("{d}(suppl. {d})").ToString();
            baseCsvModel.SearchParameter28 = Regex.Match(documentLink, "\\d+\\(suppl. \\d+\\)", RegexOptions.IgnoreCase).Success.ToString();
            //baseCsvModel.SearchParameter29 = documentLink.ToLower().Contains("no. {d}").ToString();
            baseCsvModel.SearchParameter29 = Regex.Match(documentLink, "no. \\d+", RegexOptions.IgnoreCase).Success.ToString();

            baseCsvModel.SearchParameter30 = documentLink.ToLower().Contains("[спец. выпуск]").ToString();
            baseCsvModel.SearchParameter31 = documentLink.ToLower().Contains("[special issue]").ToString();
            baseCsvModel.SearchParameter32 = documentLink.ToLower().Contains("[спец. раздел]").ToString();
            baseCsvModel.SearchParameter33 = documentLink.ToLower().Contains("[special section]").ToString();
            baseCsvModel.SearchParameter34 = documentLink.ToLower().Contains("тез.").ToString();
            baseCsvModel.SearchParameter35 = documentLink.ToLower().Contains("материалы").ToString();
            baseCsvModel.SearchParameter36 = documentLink.ToLower().Contains("конф.").ToString();
            baseCsvModel.SearchParameter37 = documentLink.ToLower().Contains("conference").ToString();
            baseCsvModel.SearchParameter38 = documentLink.ToLower().Contains("[электронный ресурс]").ToString();
            baseCsvModel.SearchParameter39 = documentLink.ToLower().Contains("режим доступа").ToString();
            baseCsvModel.SearchParameter40 = documentLink.ToLower().Contains("www/ url").ToString();
            baseCsvModel.SearchParameter41 = documentLink.ToLower().Contains("загл. с экрана").ToString();
            baseCsvModel.SearchParameter42 = documentLink.ToLower().Contains("интеракт. учеб.").ToString();
            baseCsvModel.SearchParameter43 = documentLink.ToLower().Contains("(cd-rom)").ToString();
            baseCsvModel.SearchParameter44 = documentLink.ToLower().Contains("загл. с этикетки диска").ToString();
            baseCsvModel.SearchParameter45 = documentLink.ToLower().Contains("сб. науч. тр.").ToString();
            baseCsvModel.SearchParameter46 = documentLink.ToLower().Contains("set").ToString();
            baseCsvModel.SearchParameter47 = documentLink.ToLower().Contains("сборник науч. трудов").ToString();
            baseCsvModel.SearchParameter48 = documentLink.ToLower().Contains("гост").ToString();
            baseCsvModel.SearchParameter49 = documentLink.ToLower().Contains("инструкция").ToString();
            baseCsvModel.SearchParameter50 = documentLink.ToLower().Contains("устав").ToString();
            baseCsvModel.SearchParameter51 = documentLink.ToLower().Contains("конституция").ToString();
            baseCsvModel.SearchParameter52 = documentLink.ToLower().Contains("constitution").ToString();
            baseCsvModel.SearchParameter53 = documentLink.ToLower().Contains("отчет").ToString();
            baseCsvModel.SearchParameter54 = documentLink.ToLower().Contains("report").ToString();
            baseCsvModel.SearchParameter55 = documentLink.ToLower().Contains("дис.").ToString();
            baseCsvModel.SearchParameter56 = documentLink.ToLower().Contains("dissertation").ToString();
            baseCsvModel.SearchParameter57 = documentLink.ToLower().Contains("автореф.").ToString();
            baseCsvModel.SearchParameter58 = documentLink.ToLower().Contains("диплом.").ToString();
            baseCsvModel.SearchParameter59 = documentLink.ToLower().Contains("магистра").ToString();
            baseCsvModel.SearchParameter60 = documentLink.ToLower().Contains("master’s").ToString();
            baseCsvModel.SearchParameter61 = documentLink.ToLower().Contains("doctoral dissertation").ToString();
            baseCsvModel.SearchParameter62 = documentLink.ToLower().Contains("master’s thesis").ToString();
            baseCsvModel.SearchParameter63 = documentLink.ToLower().Contains("dissertation Abstracts").ToString();
            baseCsvModel.SearchParameter64 = documentLink.ToLower().Contains("патентообладатель").ToString();

            //baseCsvModel.SearchParameter65 = documentLink.Contains("{d,7}").ToString();
            baseCsvModel.SearchParameter65 = Regex.Match(documentLink, "[\\d]{7}", RegexOptions.IgnoreCase).Success.ToString();

            baseCsvModel.SearchParameter66 = documentLink.ToLower().Contains("в кн.").ToString();
            baseCsvModel.SearchParameter67 = documentLink.ToLower().Contains("in:").ToString();
            baseCsvModel.SearchParameter68 = documentLink.ToLower().Contains("[abstract]").ToString();

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
