using Identity.WebAPI.Model;

namespace Identity.WebAPI.Services.TokenSender;

public interface ITokenSender
{
    Task SendForEmailConfirmation(User user, string token);
    Task SendForChangePasswordConfirmation(User user, string token);
}