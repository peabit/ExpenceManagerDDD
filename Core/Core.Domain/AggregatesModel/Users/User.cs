using Core.Domain.AggregatesModel.Categories;

namespace Core.Domain.AggregatesModel.Users;

public class User
{
    public UserId Id { get; set; }

    public Category CreateCategory(string name, CategoryId? parent = null)
    {
        throw new NotImplementedException();
    }
}