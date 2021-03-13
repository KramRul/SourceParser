using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork
    {
        IAuthorRepository Authors { get; }
        ICo_AuthorRepository Co_Authors { get; }
        IDocumentRepository Documents { get; }
        IEditorRepository Editors { get; }
        INoteRepository Notes { get; }
        IPublisherRepository Publishers { get; }
        IReferenceRepository References { get; }
        IStyleRepository Styles { get; }
        ITranslatorRepository Translators { get; }
        IImportLinkDataRepository ImportLinks { get; }
    }
}
