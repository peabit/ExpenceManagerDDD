using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace WebAPI.ExceptionHandling;

public sealed class ExceptionHandlerMiddleware
{
    private readonly IReadOnlyDictionary<int, ClientErrorData> _statusCodeDescriptions;

    public ExceptionHandlerMiddleware(RequestDelegate next, IOptions<ApiBehaviorOptions> behaviorOptions)
        => _statusCodeDescriptions = behaviorOptions.Value.ClientErrorMapping.AsReadOnly();

    public async Task Invoke(HttpContext context)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

        var problemDetails = exceptionHandlerFeature!.Error switch
        {
            ValidationException validationException => CreateValidationProblemDetails(validationException),
            NotFoundException notFoundException => CreateProblemDetails(statusCode: 404, notFoundException.Message),
            DomainException domainException => CreateProblemDetails(statusCode: 400, domainException.Message),
            
            _  => CreateProblemDetails(statusCode: 500, "Unexpected internal server error. Try it again later.")
        };

        await Handle(problemDetails, context.Response);
    }

    private ValidationProblemDetails CreateValidationProblemDetails(ValidationException exception)
    {
        var validationProblemDetails = new ValidationProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Detail = exception.Message,
        };

        foreach (var errorField in exception.Errors.Keys)
        {
            validationProblemDetails.Errors[errorField] = exception.Errors[errorField];
        }

        EnrichDescription(validationProblemDetails);
        return validationProblemDetails;
    }

    private ProblemDetails CreateProblemDetails(int statusCode, string detail)
    {
        var problemDetails = new ProblemDetails() 
        { 
            Status = statusCode, 
            Detail = detail
        };

        EnrichDescription(problemDetails);
        return problemDetails;
    }

    private void EnrichDescription<TProblemDetails>(TProblemDetails problemDetails)
        where TProblemDetails : ProblemDetails
    {
        var statusCodeDescription = _statusCodeDescriptions[problemDetails.Status!.Value];
        problemDetails.Type = statusCodeDescription.Link;
        problemDetails.Title = statusCodeDescription.Title;
    }

    private static async Task Handle<TProblemDetails>(TProblemDetails problemDetails, HttpResponse response)
        where TProblemDetails : ProblemDetails
    {
        response.StatusCode = (int)problemDetails.Status!;

        // Explicit conversion is necessary to correct parsing ValidationProblemDetails to json.
        await response.WriteAsJsonAsync((object)problemDetails);
    }
}