using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Models;
using NoteApp.Entities.Concrete;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]s")]
public class LoginController : ControllerBase
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserLoginModel userLoginModel)
    {
        try
        {
            if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, false, true);

            if (result.Succeeded)
            {
                return Ok("Login Succeed!");
            }
        }return BadRequest();
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
        
    }
}
