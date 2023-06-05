namespace Core.Application.Common;

public interface IRequestValidator<TRequest>
{
    void ThrowExceptionIfInvalid(TRequest request);   
}