namespace Core.Domain.Exceptions;

public sealed class ValidationException : DomainException
{
    public ValidationException(string message, IDictionary<string, string[]> errors = null!)
        : base(message)
    {
        Errors = errors ??= new Dictionary<string, string[]>();
    }

    public IDictionary<string, string[]> Errors { get; private init; }   
}