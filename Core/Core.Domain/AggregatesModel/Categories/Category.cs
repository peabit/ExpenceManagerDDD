using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.Users;
using Core.Domain.Common;
using Core.Domain.Exceptions;

namespace Core.Domain.AggregatesModel.Categories;

public class Category : EntityBase<CategoryId>, IAggregateRoot
{
    public Category(UserId userId, string name, Category? parentCategory = null)
    {
        UserId = userId;
        Name = name;
        ParentId = parentCategory is not null ? parentCategory.Id : null;
    }

    private Category() { }

    private CategoryId? _parentId;
    private string _name;

    public UserId UserId { get; private init; }
    
    public string Name
    {
        get => _name;
        set => _name = !String.IsNullOrWhiteSpace(value) ? value : throw new DomainException("Category name cannot be empty");
    }

    public CategoryId? ParentId
    {
        get => _parentId;
        set => _parentId = Id != value ? value : throw new DomainException("Сategory cannot be a parent to itself");
    }

    public ReceiptItem CreateReceiptItem(string name, decimal price, int quantity = 1)
        => new ReceiptItem(categoryId: Id, name, price, quantity);

    public void ChangeNameTo(string newName)
        => Name = newName;

    public bool HasParentCategory()
        => ParentId is not null;

    public void LinkToParentCategory(Category parentCategory)
        => ParentId = parentCategory is not null ? parentCategory.Id : throw new ArgumentNullException(nameof(parentCategory));

    public void UnlinkFromParentCategory()
        => _parentId = HasParentCategory() ? null : throw new DomainException("Category has no parent");
}