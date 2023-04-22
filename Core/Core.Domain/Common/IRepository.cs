namespace Core.Domain.Common;

public interface IRepository<TAggregateRoot> 
    where TAggregateRoot : IAggregateRoot { }