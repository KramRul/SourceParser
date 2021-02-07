using LINQtoCSV;
using Newtonsoft.Json;
using SourceParser.DataAccessLevel;
using SourceParser.DataAccessLevel.Entities;
using SourceParser.Excel;
using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceParser.BusinessLogicLevel.Helpers.Excel
{
    public class CsvHelper
    {
        protected List<BaseCsvModel> csvModel;

        public void Parse(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                CsvContext csvContext = new CsvContext();
                csvModel = csvContext.Read<BaseCsvModel>(sr).ToList();
            }
        }

        public void SyncDataWithDatabase()
        {
            using (var dbManager = new ApplicationContext())
            {
                try
                {
                    var importLinksDataToAdd = new List<ImportLinkData>();
                    foreach (var importLinkData in csvModel)
                    {
                        if (String.IsNullOrEmpty(importLinkData.SourceLink) || String.IsNullOrWhiteSpace(importLinkData.SourceLink))
                        {
                            continue;
                        }
                        var parsedGuid = Guid.Parse(importLinkData.SKU);
                        var existedImportLinkData = dbManager.ImportLinksData.Where(item => item.SKU.Equals(parsedGuid)).FirstOrDefault();
                        var imageURL = String.Empty;
                        if (existedImportLinkData != null)
                        {
                            existedImportLinkData.SKU = Guid.Parse(importLinkData.SKU);
                            existedImportLinkData.SourceLink = importLinkData.SourceLink;
                            existedImportLinkData.BiblLinkClass = importLinkData.BiblLinkClass;
                            existedImportLinkData.SearchParameter0 = importLinkData.SearchParameter0;
                            existedImportLinkData.SearchParameter1 = importLinkData.SearchParameter1;
                            existedImportLinkData.SearchParameter2 = importLinkData.SearchParameter2;
                            existedImportLinkData.SearchParameter3 = importLinkData.SearchParameter3;
                            existedImportLinkData.SearchParameter4 = importLinkData.SearchParameter4;
                            existedImportLinkData.SearchParameter5 = importLinkData.SearchParameter5;
                            existedImportLinkData.SearchParameter6 = importLinkData.SearchParameter6;
                            existedImportLinkData.SearchParameter7 = importLinkData.SearchParameter7;
                            existedImportLinkData.SearchParameter8 = importLinkData.SearchParameter8;
                            existedImportLinkData.SearchParameter9 = importLinkData.SearchParameter9;
                            existedImportLinkData.SearchParameter10 = importLinkData.SearchParameter10;
                            existedImportLinkData.SearchParameter11 = importLinkData.SearchParameter11;
                            existedImportLinkData.SearchParameter12 = importLinkData.SearchParameter12;
                            existedImportLinkData.SearchParameter13 = importLinkData.SearchParameter13;
                            existedImportLinkData.SearchParameter14 = importLinkData.SearchParameter14;
                            existedImportLinkData.SearchParameter15 = importLinkData.SearchParameter15;
                            existedImportLinkData.SearchParameter16 = importLinkData.SearchParameter16;
                            existedImportLinkData.SearchParameter17 = importLinkData.SearchParameter17;
                            existedImportLinkData.SearchParameter18 = importLinkData.SearchParameter18;
                            existedImportLinkData.SearchParameter19 = importLinkData.SearchParameter19;
                            existedImportLinkData.SearchParameter20 = importLinkData.SearchParameter20;
                            existedImportLinkData.SearchParameter21 = importLinkData.SearchParameter21;
                            existedImportLinkData.SearchParameter22 = importLinkData.SearchParameter22;
                            existedImportLinkData.SearchParameter23 = importLinkData.SearchParameter23;
                            existedImportLinkData.SearchParameter24 = importLinkData.SearchParameter24;
                            existedImportLinkData.SearchParameter25 = importLinkData.SearchParameter25;
                            existedImportLinkData.SearchParameter26 = importLinkData.SearchParameter26;
                            existedImportLinkData.SearchParameter27 = importLinkData.SearchParameter27;
                            existedImportLinkData.SearchParameter28 = importLinkData.SearchParameter28;
                            existedImportLinkData.SearchParameter29 = importLinkData.SearchParameter29;
                            existedImportLinkData.SearchParameter30 = importLinkData.SearchParameter30;
                            existedImportLinkData.SearchParameter31 = importLinkData.SearchParameter31;
                            existedImportLinkData.SearchParameter32 = importLinkData.SearchParameter32;
                            existedImportLinkData.SearchParameter33 = importLinkData.SearchParameter33;
                            existedImportLinkData.SearchParameter34 = importLinkData.SearchParameter34;
                            existedImportLinkData.SearchParameter35 = importLinkData.SearchParameter35;
                            existedImportLinkData.SearchParameter36 = importLinkData.SearchParameter36;
                            existedImportLinkData.SearchParameter37 = importLinkData.SearchParameter37;
                            existedImportLinkData.SearchParameter38 = importLinkData.SearchParameter38;
                            existedImportLinkData.SearchParameter39 = importLinkData.SearchParameter39;
                            existedImportLinkData.SearchParameter40 = importLinkData.SearchParameter40;
                            existedImportLinkData.SearchParameter41 = importLinkData.SearchParameter41;
                            existedImportLinkData.SearchParameter42 = importLinkData.SearchParameter42;
                            existedImportLinkData.SearchParameter43 = importLinkData.SearchParameter43;
                            existedImportLinkData.SearchParameter44 = importLinkData.SearchParameter44;
                            existedImportLinkData.SearchParameter45 = importLinkData.SearchParameter45;
                            existedImportLinkData.SearchParameter46 = importLinkData.SearchParameter46;
                            existedImportLinkData.SearchParameter47 = importLinkData.SearchParameter47;
                            existedImportLinkData.SearchParameter48 = importLinkData.SearchParameter48;
                            existedImportLinkData.SearchParameter49 = importLinkData.SearchParameter49;
                            existedImportLinkData.SearchParameter50 = importLinkData.SearchParameter50;
                            existedImportLinkData.SearchParameter51 = importLinkData.SearchParameter51;
                            existedImportLinkData.SearchParameter52 = importLinkData.SearchParameter52;
                            existedImportLinkData.SearchParameter53 = importLinkData.SearchParameter53;
                            existedImportLinkData.SearchParameter54 = importLinkData.SearchParameter54;
                            existedImportLinkData.SearchParameter55 = importLinkData.SearchParameter55;
                            existedImportLinkData.SearchParameter56 = importLinkData.SearchParameter56;
                            existedImportLinkData.SearchParameter57 = importLinkData.SearchParameter57;
                            existedImportLinkData.SearchParameter58 = importLinkData.SearchParameter58;
                            existedImportLinkData.SearchParameter59 = importLinkData.SearchParameter59;
                            existedImportLinkData.SearchParameter60 = importLinkData.SearchParameter60;
                            existedImportLinkData.SearchParameter61 = importLinkData.SearchParameter61;
                            existedImportLinkData.SearchParameter62 = importLinkData.SearchParameter62;
                            existedImportLinkData.SearchParameter63 = importLinkData.SearchParameter63;
                            existedImportLinkData.SearchParameter64 = importLinkData.SearchParameter64;
                            existedImportLinkData.SearchParameter65 = importLinkData.SearchParameter65;
                            existedImportLinkData.SearchParameter66 = importLinkData.SearchParameter66;
                            existedImportLinkData.SearchParameter67 = importLinkData.SearchParameter67;
                            existedImportLinkData.SearchParameter68 = importLinkData.SearchParameter68;
                            existedImportLinkData.SearchParameter69 = importLinkData.SearchParameter69;
                            dbManager.SaveChanges();
                        }
                        if (existedImportLinkData == null)
                        {
                            importLinksDataToAdd.Add(new ImportLinkData()
                            {
                                SKU = Guid.Parse(importLinkData.SKU),
                                SourceLink = importLinkData.SourceLink,
                                BiblLinkClass = importLinkData.BiblLinkClass,
                                SearchParameter0 = importLinkData.SearchParameter0,
                                SearchParameter1 = importLinkData.SearchParameter1,
                                SearchParameter2 = importLinkData.SearchParameter2,
                                SearchParameter3 = importLinkData.SearchParameter3,
                                SearchParameter4 = importLinkData.SearchParameter4,
                                SearchParameter5 = importLinkData.SearchParameter5,
                                SearchParameter6 = importLinkData.SearchParameter6,
                                SearchParameter7 = importLinkData.SearchParameter7,
                                SearchParameter8 = importLinkData.SearchParameter8,
                                SearchParameter9 = importLinkData.SearchParameter9,
                                SearchParameter10 = importLinkData.SearchParameter10,
                                SearchParameter11 = importLinkData.SearchParameter11,
                                SearchParameter12 = importLinkData.SearchParameter12,
                                SearchParameter13 = importLinkData.SearchParameter13,
                                SearchParameter14 = importLinkData.SearchParameter14,
                                SearchParameter15 = importLinkData.SearchParameter15,
                                SearchParameter16 = importLinkData.SearchParameter16,
                                SearchParameter17 = importLinkData.SearchParameter17,
                                SearchParameter18 = importLinkData.SearchParameter18,
                                SearchParameter19 = importLinkData.SearchParameter19,
                                SearchParameter20 = importLinkData.SearchParameter20,
                                SearchParameter21 = importLinkData.SearchParameter21,
                                SearchParameter22 = importLinkData.SearchParameter22,
                                SearchParameter23 = importLinkData.SearchParameter23,
                                SearchParameter24 = importLinkData.SearchParameter24,
                                SearchParameter25 = importLinkData.SearchParameter25,
                                SearchParameter26 = importLinkData.SearchParameter26,
                                SearchParameter27 = importLinkData.SearchParameter27,
                                SearchParameter28 = importLinkData.SearchParameter28,
                                SearchParameter29 = importLinkData.SearchParameter29,
                                SearchParameter30 = importLinkData.SearchParameter30,
                                SearchParameter31 = importLinkData.SearchParameter31,
                                SearchParameter32 = importLinkData.SearchParameter32,
                                SearchParameter33 = importLinkData.SearchParameter33,
                                SearchParameter34 = importLinkData.SearchParameter34,
                                SearchParameter35 = importLinkData.SearchParameter35,
                                SearchParameter36 = importLinkData.SearchParameter36,
                                SearchParameter37 = importLinkData.SearchParameter37,
                                SearchParameter38 = importLinkData.SearchParameter38,
                                SearchParameter39 = importLinkData.SearchParameter39,
                                SearchParameter40 = importLinkData.SearchParameter40,
                                SearchParameter41 = importLinkData.SearchParameter41,
                                SearchParameter42 = importLinkData.SearchParameter42,
                                SearchParameter43 = importLinkData.SearchParameter43,
                                SearchParameter44 = importLinkData.SearchParameter44,
                                SearchParameter45 = importLinkData.SearchParameter45,
                                SearchParameter46 = importLinkData.SearchParameter46,
                                SearchParameter47 = importLinkData.SearchParameter47,
                                SearchParameter48 = importLinkData.SearchParameter48,
                                SearchParameter49 = importLinkData.SearchParameter49,
                                SearchParameter50 = importLinkData.SearchParameter50,
                                SearchParameter51 = importLinkData.SearchParameter51,
                                SearchParameter52 = importLinkData.SearchParameter52,
                                SearchParameter53 = importLinkData.SearchParameter53,
                                SearchParameter54 = importLinkData.SearchParameter54,
                                SearchParameter55 = importLinkData.SearchParameter55,
                                SearchParameter56 = importLinkData.SearchParameter56,
                                SearchParameter57 = importLinkData.SearchParameter57,
                                SearchParameter58 = importLinkData.SearchParameter58,
                                SearchParameter59 = importLinkData.SearchParameter59,
                                SearchParameter60 = importLinkData.SearchParameter60,
                                SearchParameter61 = importLinkData.SearchParameter61,
                                SearchParameter62 = importLinkData.SearchParameter62,
                                SearchParameter63 = importLinkData.SearchParameter63,
                                SearchParameter64 = importLinkData.SearchParameter64,
                                SearchParameter65 = importLinkData.SearchParameter65,
                                SearchParameter66 = importLinkData.SearchParameter66,
                                SearchParameter67 = importLinkData.SearchParameter67,
                                SearchParameter68 = importLinkData.SearchParameter68,
                                SearchParameter69 = importLinkData.SearchParameter69
                            });
                        }
                    }

                    dbManager.ImportLinksData.AddRange(importLinksDataToAdd);

                    dbManager.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
