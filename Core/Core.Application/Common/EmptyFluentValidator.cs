using FluentValidation;

namespace Core.Application.Common;

public sealed class EmptyFluentValidator<TRequest> : AbstractValidator<TRequest> { }