using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;

namespace Core.Domain.Users;

public sealed record User
{
    public User(string id)
        => _id = id;

    private User() { }

    private string _id;

    public Receipt CreateReceipt(string shopName, DateTime dateTime, IEnumerable<ReceiptItem> items)
        => new Receipt(user: this, shopName, dateTime, items);

    public Category CreateCategory(string name, Category? parentCategory = null)
        => new Category(user: this, name, parentCategory);

    public override string ToString()
        => _id;
}