using System.ComponentModel.DataAnnotations;

namespace Identity.WebAPI.Controllers;

public sealed record RegisterRequest(
    [Required]
    string UserName,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);