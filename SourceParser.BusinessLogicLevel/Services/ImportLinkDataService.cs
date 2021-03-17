using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using SourceParser.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class ImportLinkDataService : BaseService, IImportLinkDataService
    {
        public ImportLinkDataService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<ObservableCollection<ImportLinkDataModel>> GetAllImportedLinks()
        {
            var importLinks = await _database.ImportLinks.GetAll();

            var documentsList = importLinks.Select(importLinkData => new ImportLinkDataModel()
            {
                Id = importLinkData.Id,
                SKU = importLinkData.SKU,
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
                SearchParameter68 = importLinkData.SearchParameter68
            }).ToList();

            var result = new ObservableCollection<ImportLinkDataModel>(documentsList);

            return result;
        }
    }
}
