using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork : IDisposable
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
    }
}
