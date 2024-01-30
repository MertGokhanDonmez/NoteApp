using System.ComponentModel.DataAnnotations;

namespace NoteApp.Api;

public class UserRegisterModel
{
    [Required(ErrorMessage = "Please write your first name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Please write your last name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please write an email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please write an user name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Please write a password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please write password again")]
    [Compare("Password", ErrorMessage = "Passwords not compare!")]
    public string ConfirmPassword { get; set; }
    


}
