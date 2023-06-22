using Core.Domain.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI;

public static class HellangProblemDetailsConfigurator
{
    public static void AddHellangProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(opt =>
        {
            opt.IncludeExceptionDetails = (ctx, ex) => false;

            opt.OnBeforeWriteDetails = (ctx, details) =>
            {
                if (details.Status is not StatusCodes.Status500InternalServerError)
                {
                    var exceptionHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();
                    details.Detail = exceptionHandlerFeature!.Error.Message;
                }

                details.Type ??= $"https://httpstatuses.io/{details.Status!.Value}";
                details.Instance = ctx.Request.Path;
            };

            opt.MapToStatusCode<NotFoundException>(StatusCodes.Status400BadRequest);

            opt.Map<ValidationException>((httpContext, ex)
                => new ValidationProblemDetails(ex.Errors) { Status = StatusCodes.Status400BadRequest });

            opt.MapToStatusCode<DomainException>(StatusCodes.Status400BadRequest);
            opt.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        });
    }

    public static void UseHellangProblemDetails(this WebApplication app)
        => app.UseProblemDetails();
}