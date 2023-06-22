using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.WebAPI.Common;

public static class ModelStateExtensions
{
    public static void AddIdentityErrors(this ModelStateDictionary modelState, IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }
    }
}