using System.ComponentModel.DataAnnotations;

namespace NoteApp.Api.Models;

public class UserLoginModel
{
    [Required(ErrorMessage = "Please write an user name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Please write a password")]
    public string Password { get; set; }
}
