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
    public class NoteService : BaseService, INoteService
    {
        public NoteService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task DeleteNote(NoteMod note)
        {
            await _database.Notes.Delete(new DataAccessLevel.Entities.Note()
            {
                Id = note.Id,
                Value = note.Value,
                Document = note.Document,
                DocumentId = note.DocumentId
            });
        }

        public async Task<ObservableCollection<NoteMod>> GetAllByDocumentId(string docId)
        {
            var notes = await _database.Notes.GetAllByDocumentId(docId);

            var notesList = notes.Select(note => new NoteMod()
            {
                Value = note.Value,
                Id = note.Id,
                DocumentId = note.DocumentId,
                Document = note.Document
            }).ToList();

            var result = new ObservableCollection<NoteMod>(notesList);

            return result;
        }

        public async Task UpdateNote(NoteMod note)
        {
            var noteDB = new DataAccessLevel.Entities.Note()
            {
                Id = note.Id,
                Value = note.Value,
                DocumentId = note.DocumentId,
                Document = note.Document              
            };
            await _database.Notes.Update(noteDB, note.DocumentId);
        }

        public async Task CreateNote(DocumentMod document, string value)
        {
            var noteDB = new DataAccessLevel.Entities.Note()
            {
                Value = value
            };
            await _database.Notes.Create(noteDB, document.Id);
        }
    }
}
