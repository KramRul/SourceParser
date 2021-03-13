using SourceParser.DataAccessLevel.Entities;
using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceParser.DataAccessLevel.Repositories
{
    public class ImportLinkDataRepository : BaseRepository<ImportLinkData>, IImportLinkDataRepository
    {
        public ImportLinkDataRepository() : base()
        {
        }
    }
}
