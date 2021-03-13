using SourceParser.DataAccessLevel.Interfaces;
using SourceParser.DataAccessLevel.Repositories;
using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.UnitOfWorks
{
    public class UnitOfWork : IBaseUnitOfWork
    {
        private AuthorRepository _authorRepository;
        private Co_AuthorRepository _co_AuthorRepository;
        private DocumentRepository _documentRepository;
        private EditorRepository _editorRepository;
        private NoteRepository _noteRepository;
        private PublisherRepository _publisherRepository;
        private ReferenceRepository _referenceRepository;
        private StyleRepository _styleRepository;
        private TranslatorRepository _translatorRepository;
        private ImportLinkDataRepository _importLinkDataRepository;

        public UnitOfWork()
        {
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository();
                }
                return _authorRepository;
            }
        }

        public ICo_AuthorRepository Co_Authors
        {
            get
            {
                if (_co_AuthorRepository == null)
                {
                    _co_AuthorRepository = new Co_AuthorRepository();
                }
                return _co_AuthorRepository;
            }
        }

        public IDocumentRepository Documents
        {
            get
            {
                if (_documentRepository == null)
                {
                    _documentRepository = new DocumentRepository();
                }
                return _documentRepository;
            }
        }

        public IEditorRepository Editors
        {
            get
            {
                if (_editorRepository == null)
                {
                    _editorRepository = new EditorRepository();
                }
                return _editorRepository;
            }
        }

        public INoteRepository Notes
        {
            get
            {
                if (_noteRepository == null)
                {
                    _noteRepository = new NoteRepository();
                }
                return _noteRepository;
            }
        }

        public IPublisherRepository Publishers
        {
            get
            {
                if (_publisherRepository == null)
                {
                    _publisherRepository = new PublisherRepository();
                }
                return _publisherRepository;
            }
        }

        public IReferenceRepository References
        {
            get
            {
                if (_referenceRepository == null)
                {
                    _referenceRepository = new ReferenceRepository();
                }
                return _referenceRepository;
            }
        }

        public IStyleRepository Styles
        {
            get
            {
                if (_styleRepository == null)
                {
                    _styleRepository = new StyleRepository();
                }
                return _styleRepository;
            }
        }

        public ITranslatorRepository Translators
        {
            get
            {
                if (_translatorRepository == null)
                {
                    _translatorRepository = new TranslatorRepository();
                }
                return _translatorRepository;
            }
        }

        public IImportLinkDataRepository ImportLinks
        {
            get
            {
                if (_importLinkDataRepository == null)
                {
                    _importLinkDataRepository = new ImportLinkDataRepository();
                }
                return _importLinkDataRepository;
            }
        }
    }
}
