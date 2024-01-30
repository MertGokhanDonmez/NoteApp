using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Entities.Concrete;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]s")]
public class RegisterController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserRegisterModel model)
    {
        try
        {
            AppUser appUser = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    return Ok("User Registered Successfully");
                }else
                {
                    return BadRequest(result.Errors);
                }
            }else
            {
                return BadRequest(model);
            }
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}