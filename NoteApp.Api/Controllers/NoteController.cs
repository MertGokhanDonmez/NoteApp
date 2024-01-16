using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Concrete;
using NoteApp.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class NoteController : ControllerBase
{
    NoteManager noteManager = new NoteManager(new EfNoteDal());

    public NoteController()
    {
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        try
        {
            var result = noteManager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No note was found with this id.");}
            
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] Note note)
    {
        try
        {
            noteManager.Insert(note);
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllNotesByUserId(int id)
    {
        try
        {
            var result = noteManager.GetAllNotesByUserId(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No note was found with this id!");}
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}
