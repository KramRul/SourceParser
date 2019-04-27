using SourceParser.BLL.Services.Interfaces;
using SourceParser.DAL.UnitOfWorks.Interfaces;
using SourceParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BLL.Services
{
    public class NoteService : BaseService, INoteService
    {
        public NoteService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task DeleteNote(NoteMod note)
        {
            await _database.Notes.Delete(new DAL.Entities.Note()
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
            var noteDB = new DAL.Entities.Note()
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
            var noteDB = new DAL.Entities.Note()
            {
                Value = value
            };
            await _database.Notes.Create(noteDB, document.Id);
        }
    }
}
