using DAO_EFCORE.Business.Exceptions;
using DAO_EFCORE.DAL.Models;
using DAO_EFCORE.DAL.Persistence;
using System;
using System.Collections.Generic;

namespace DAO_EFCORE.Business
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public Checklist AddChecklist(int noteId, Checklist checklist)
        {
            try
            {
                var result = noteRepository.AddChecklist(checklist);
                if (result == null)
                {
                    throw new ChecklistNotFoundException(string.Format("Checklist item with id {0} not found", checklist?.ChecklistId));
                }

                return result;
            }
            catch (ChecklistNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                // unhandled exception
                throw;
            }
        }

        public Label AddLabel(int noteId, Label label)
        {
            try
            {
                var result = noteRepository.AddLabel(label);

                if (result == null)
                {
                    throw new LabelNotFoundException(string.Format("A label with id {0} does not exist", label?.LabelId));
                }

                return result;
            }
            catch (LabelNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Note AddNote(Note note)
        {
            try
            {
                var result = noteRepository.AddNote(note);

                if (result == null)
                {
                    throw new NoteNotFoundException(string.Format("Note with this id {0} does not exist", note?.NoteId));
                }

                return result;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Checklist> GetAllCheckListItems(int noteId)
        {
            try
            {
                List<Checklist> value = noteRepository.GetAllCheckListItems(noteId);
                if (value == null || value.Count <= 0)
                {
                    throw new NoteNotFoundException(string.Format("Note with this id {0} does not exist", noteId));
                }

                return value;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Label> GetAllLabels(int noteId)
        {
            try
            {
                List<Label> result = noteRepository.GetAllLabels(noteId);
                if (result == null || result.Count <= 0)
                {
                    throw new NoteNotFoundException(string.Format("Note with this id {0} does not exist", noteId));
                }
                return result;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetAllNotes()
        {
            try
            {
                var result= noteRepository.GetAllNotes();
                if (result == null || result.Count <= 0)
                {
                    throw new NoteNotFoundException("Notes not found");
                }

                return result;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Note GetNote(int noteId)
        {
            try
            {
                Note result = noteRepository.GetNote(noteId);
                if (result == null)
                {
                    throw new NoteNotFoundException(string.Format("Note with this id {0} does not exist", noteId));
                }
                return result;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetNotesByLabel(string lblText)
        {
            try
            {
                return noteRepository.GetAllNotesByLabel(lblText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetNotesByTitle(string title)
        {
            try
            {
                return noteRepository.GetAllNotesByTitle(title);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveChecklist(int noteId, int id)
        {
            try
            {
                bool result = noteRepository.RemoveChecklist(id);
                if (!result)
                {
                    throw new ChecklistNotFoundException(string.Format("Checklist item with id {0} not found", id));
                }
                return result;
            }
            catch (ChecklistNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveLabel(int noteId, int id)
        {
            try
            {
                bool result = noteRepository.RemoveLabel(id);
                if (!result)
                {
                    throw new LabelNotFoundException(string.Format("A label with id {0} does not exist", id));
                }

                return result;
            }
            catch (LabelNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveNote(int noteId)
        {
            try
            {
                bool result = noteRepository.RemoveNote(noteId);
                if (!result)
                {
                    throw new NoteNotFoundException(string.Format("Note with this id {0} does not exist", noteId));
                }

                return result;
            }
            catch (NoteNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateChecklist(int noteId, Checklist checklist)
        {
            try
            {
                bool value = noteRepository.UpdateChecklist(checklist);

                if (!value)
                {
                    throw new ChecklistNotFoundException(string.Format("Checklist item with id {0} not found", checklist.ChecklistId));
                }
                return value;
            }
            catch (ChecklistNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateLabel(int noteId, Label label)
        {
            try
            {
                bool value = noteRepository.UpdateLabel(label);
                if (!value)
                {
                    throw new LabelNotFoundException(string.Format("A label with id {0} does not exist", label.LabelId));
                }
                return value;
            }
            catch (LabelNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
