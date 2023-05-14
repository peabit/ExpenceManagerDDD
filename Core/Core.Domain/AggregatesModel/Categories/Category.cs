using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public sealed class Category : EntityBase<CategoryId>, IAggregateRoot
{
    public Category(User user, string name, Category? parentCategory = null)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ParentId = parentCategory?.Id; 
    }

    private Category() { }

    private CategoryId? _parentId;
    private string _name;

    public User User { get; private init; }
    
    public string Name
    {
        get => _name;
        
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("Category name cannot be empty");
            }

            _name = value;
        }
    }

    public CategoryId? ParentId
    {
        get => _parentId;
        
        private set
        {
            if (value == Id)
            {
                throw new InvalidOperationException("Сategory cannot be a parent to itself");
            }

            _parentId = value;
        }
    }

    public ReceiptItem CreateReceiptItem(string name, decimal price, int quantity = 1)
        => new ReceiptItem(categoryId: Id, name, price, quantity);

    public void ChangeNameTo(string newName)
        => Name = newName;

    public bool HasParentCategory()
        => ParentId is not null;

    public void LinkToParentCategory(Category parentCategory)
        => ParentId = parentCategory.Id ?? throw new ArgumentNullException(nameof(parentCategory));

    public void UnlinkFromParentCategory()
        => _parentId = HasParentCategory() ? null : throw new InvalidOperationException("Category has no parent");
}