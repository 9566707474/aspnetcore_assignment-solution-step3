using DAO_EFCORE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO_EFCORE.DAL.Persistence
{
    public class NoteRepository : INoteRepository
    {
        private readonly IKeepNoteContext keepNoteContext;

        public NoteRepository(IKeepNoteContext keepNoteContext)
        {
            this.keepNoteContext = keepNoteContext;
        }

        public Checklist AddChecklist(Checklist checklist)
        {
            keepNoteContext.Checklists.Add(checklist);
            keepNoteContext.SaveChanges();
            return checklist;
        }

        public Label AddLabel(Label label)
        {
            keepNoteContext.Labels.Add(label);
            keepNoteContext.SaveChanges();
            return label;
        }

        public Note AddNote(Note note)
        {
            keepNoteContext.Notes.Add(note);
            keepNoteContext.SaveChanges();
            return note;
        }

        public List<Checklist> GetAllCheckListItems(int noteId)
        {
            return keepNoteContext.Checklists.Where(p => p.NoteId == noteId).ToList();
        }

        public List<Label> GetAllLabels(int noteId)
        {
            return keepNoteContext.Labels.Where(p => p.NoteId == noteId).ToList();
        }

        public List<Note> GetAllNotes()
        {
            return keepNoteContext.Notes.Select(p => p).ToList();
        }

        public List<Note> GetAllNotesByLabel(string lblText)
        {
            return keepNoteContext.Notes
                .Include(p => p.Labels)
                .Where(n => n.Labels.Any(l => l.Content == lblText)).ToList();
        }

        public List<Note> GetAllNotesByTitle(string title)
        {
            return keepNoteContext.Notes
               .Where(n => n.Title == title).ToList();
        }

        public Label GetLabel(int labelId)
        {
            return keepNoteContext.Labels
              .FirstOrDefault(n => n.LabelId == labelId);
        }

        public Note GetNote(int noteId)
        {
            return keepNoteContext.Notes
              .FirstOrDefault(n => n.NoteId == noteId);
        }

        public bool RemoveChecklist(int id)
        {
            Checklist checkList = keepNoteContext.Checklists.FirstOrDefault(p => p.ChecklistId == id);
            if (checkList == null)
            {
                return false;
            }
            keepNoteContext.Checklists.Remove(checkList);
            keepNoteContext.SaveChanges();
            return true;
        }

        public bool RemoveLabel(int id)
        {
            Label label = keepNoteContext.Labels.FirstOrDefault(p => p.LabelId == id);
            if (label == null)
            {
                return false;
            }
            keepNoteContext.Labels.Remove(label);
            keepNoteContext.SaveChanges();
            return true;
        }

        public bool RemoveNote(int id)
        {
            Note note = keepNoteContext.Notes.FirstOrDefault(p => p.NoteId == id);
            if (note == null)
            {
                return false;
            }
            keepNoteContext.Notes.Remove(note);
            keepNoteContext.SaveChanges();
            return true;
        }

        public bool UpdateChecklist(Checklist checklist)
        {
            var checkList = keepNoteContext.Checklists.FirstOrDefault(c => c.ChecklistId == checklist.ChecklistId);
            if (checkList == null)
            {
                return false;
            }
            checkList.Content = checklist.Content;
            checkList.NoteId = checklist.NoteId;
            keepNoteContext.SaveChanges();
            return true;
        }

        public bool UpdateLabel(Label label)
        {
            var labels = keepNoteContext.Labels.FirstOrDefault(c => c.LabelId == label.LabelId);
            if (labels == null)
            {
                return false;
            }
            label.Content = labels.Content;
            label.NoteId = labels.NoteId;
            keepNoteContext.SaveChanges();
            return true;
        }
    }
}
