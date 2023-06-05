using FluentValidation;

namespace Core.Application.Common;

public sealed class FluentRequestValidator<TRequest> : IRequestValidator<TRequest>
{
    private readonly IValidator<TRequest> _validator;

    public FluentRequestValidator(IValidator<TRequest> validator)
        => _validator = validator;

    public void ThrowExceptionIfInvalid(TRequest request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new Domain.Exceptions.ValidationException("Invalid request", validationResult.ToDictionary());
        }     
    }
}