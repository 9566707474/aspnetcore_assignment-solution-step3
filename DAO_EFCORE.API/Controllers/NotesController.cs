using DAO_EFCORE.Business;
using DAO_EFCORE.Business.Exceptions;
using DAO_EFCORE.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DAO_EFCORE.API.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        //implementation of all required routes

        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        // GET api/notes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var notes = noteService.GetAllNotes();
                return Ok(notes);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var note = noteService.GetNote(id);
                return Ok(note);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = noteService.RemoveNote(id);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET Post/notes/5
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Note note)
        {
            try
            {
                var result = noteService.AddNote(note);
                return Created(new Uri("api/notes/" + result.NoteId, UriKind.Relative), result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("{id}/labels")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLabel(int id, Label label)
        {
            try
            {
                var result = noteService.AddLabel(id, label);
                return Created(new Uri("api/notes/" + id, UriKind.Relative), result);
            }
            catch (LabelNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}/labels/{labelid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoveLabel(int id, int labelid)
        {
            try
            {
                var result = noteService.RemoveLabel(id, labelid);
                return Ok(result);
            }
            catch (LabelNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}/labels/{labelId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateLabel(int id, int labelId, Label label)
        {
            try
            {
                var result = noteService.UpdateLabel(id, label);
                return Ok(result);
            }
            catch (LabelNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("{id}/checklist")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddChecklist(int id, Checklist lstItem)
        {
            try
            {
                var result = noteService.AddChecklist(id, lstItem);
                return Created(new Uri("api/notes/" + id, UriKind.Relative), result);
            }
            catch (ChecklistNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}/checklist/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoveChecklist(int id, int itemId)
        {
            try
            {
                var result = noteService.RemoveChecklist(id, itemId);
                return Ok(result);
            }
            catch (ChecklistNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}/checklist/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public object UpdateChecklist(int id, int itemId, Checklist lstItem)
        {
            try
            {
                var result = noteService.UpdateChecklist(id, lstItem);
                return Ok(result);
            }
            catch (ChecklistNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
