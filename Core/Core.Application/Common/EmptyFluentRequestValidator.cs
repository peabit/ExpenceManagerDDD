using FluentValidation;

namespace Core.Application.Common;

public sealed class EmptyFluentRequestValidator<TRequest> : AbstractValidator<TRequest> { }