using System.ComponentModel.DataAnnotations;

namespace Identity.WebAPI.Controllers.UserController;

public sealed record RegisterRequest(
    [Required]
    string UserName,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);