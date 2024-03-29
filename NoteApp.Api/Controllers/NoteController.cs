﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Models;
using NoteApp.Business.Concrete;
using NoteApp.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]s")]
public class NoteController : ControllerBase
{
    NoteManager noteManager = new NoteManager(new EfNoteDal());

    public NoteController()
    {

    }

    [HttpGet("{noteId}")]
    public async Task<IActionResult> GetNoteById(int noteId)
    {
        try
        {
            var result = noteManager.GetById(noteId);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No note was found with this id."); }

        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] NoteModel noteModel)
    {
        try
        {
            Note createdTag = new Note
            {
                Title = noteModel.Title,
                Content = noteModel.Content,
                UserId = noteModel.UserId
            };
            noteManager.Insert(createdTag);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteNote([FromBody] Note note)
    {
        try
        {
            noteManager.Delete(note);
            return Ok($"Successfully deleted note with this id: {note.NoteId}");
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpGet("{id}/user")]
    public async Task<IActionResult> GetAllNotesByUserId(int id)
    {
        try
        {
            var result = noteManager.GetAllNotesByUserId(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No note was found with this id!"); }
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}
