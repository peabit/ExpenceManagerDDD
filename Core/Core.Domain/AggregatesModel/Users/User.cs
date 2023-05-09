using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Users;

public class User : EntityBase<UserId>, IAggregateRoot
{
    private User() { }

    public Category CreateCategory(string name, Category? parentCategory = null)
        => new Category(userId: Id, name, parentCategory);
}