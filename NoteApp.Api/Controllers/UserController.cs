
using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Concrete;
using NoteApp.DataAccess;
using NoteApp.Entities.Concrete;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    UserManager userManager = new UserManager(new EfUserDal());

    public UserController()
    {

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var result = userManager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No user was found with this id!"); }

        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        try
        {
            userManager.Insert(user);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromBody] User user)
    {
        try
        {
            // users must not be delete
            userManager.Delete(user);
            return Ok($"Successfully deleted user with this id: {user.UserId}");
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}
