using SourceParser.DAL.Interfaces;
using SourceParser.DAL.Repositories;
using SourceParser.DAL.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.UnitOfWorks
{
    public class UnitOfWork : IBaseUnitOfWork
    {
        private ApplicationContext _dataBase;
        private AuthorRepository _authorRepository;
        private Co_AuthorRepository _co_AuthorRepository;
        private DocumentRepository _documentRepository;
        private EditorRepository _editorRepository;
        private NoteRepository _noteRepository;
        private PublisherRepository _publisherRepository;
        private ReferenceRepository _referenceRepository;
        private StyleRepository _styleRepository;
        private TranslatorRepository _translatorRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _dataBase = context;
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_dataBase);
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
                    _co_AuthorRepository = new Co_AuthorRepository(_dataBase);
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
                    _documentRepository = new DocumentRepository(_dataBase);
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
                    _editorRepository = new EditorRepository(_dataBase);
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
                    _noteRepository = new NoteRepository(_dataBase);
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
                    _publisherRepository = new PublisherRepository(_dataBase);
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
                    _referenceRepository = new ReferenceRepository(_dataBase);
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
                    _styleRepository = new StyleRepository(_dataBase);
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
                    _translatorRepository = new TranslatorRepository(_dataBase);
                }
                return _translatorRepository;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
