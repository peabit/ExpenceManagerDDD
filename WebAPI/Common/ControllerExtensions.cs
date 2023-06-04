using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Common;

public static class ControllerExtensions
{
    public static CreatedResult Created(this ControllerBase controller)
        => controller.Created(uri: string.Empty, value: null);
}