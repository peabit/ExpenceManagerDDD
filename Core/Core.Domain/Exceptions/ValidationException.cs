namespace Core.Domain.Exceptions;

public sealed class ValidationException : DomainException
{
    public ValidationException(string message, IDictionary<string, string[]> errors)
        : base(message)
        => Errors = errors;

    public IDictionary<string, string[]> Errors { get; private init; }   
}