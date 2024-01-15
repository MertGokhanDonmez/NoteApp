using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Concrete;
using NoteApp.DataAccess;

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
    public Task<IActionResult> Get(int id)
    {
        try
        {
            // var result = noteManager.
            // if (true)
            // {
                
            // }
            return null;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
