namespace Identity.WebAPI.Controllers.UserController;

public sealed record ConfirmEmailRequest(string Email, string Token);