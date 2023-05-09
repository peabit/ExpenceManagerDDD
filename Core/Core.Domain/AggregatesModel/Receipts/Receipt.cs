using Core.Domain.AggregatesModel.Users;
using Core.Domain.Common;
using Core.Domain.Exceptions;

namespace Core.Domain.AggregatesModel.Receipts;

public class Receipt : EntityBase<ReceiptId>, IAggregateRoot
{
    public Receipt(UserId userId, string shopName, DateTime dateTime, IEnumerable<ReceiptItem> items)
    {
        UserId = userId;
        ShopName = shopName;
        DateTime = dateTime;
        _items.AddRange(items);
    }

    private Receipt() { }

    private readonly List<ReceiptItem> _items = new();
    private string _shopName;
    public UserId UserId { get; private init; }
    
    public string ShopName
    {
        get => _shopName;
        private set => _shopName = !String.IsNullOrWhiteSpace(value) ? value : throw new DomainException("Shop name cannot be empty"); 
    }

    public DateTime DateTime { get; private set; }
    public decimal Total => _items.Sum(i => i.Coast);
    public IEnumerable<ReceiptItem> Items => _items;

    public void ChangeShopNameTo(string newShopName)
        => ShopName = newShopName;

    public void DeleteItem(ReceiptItem item)
    {
        if (_items.Count == 1)
        {
            throw new DomainException("Receipt must contain at least one item");
        }

        var itemForDelete = _items.FirstOrDefault(i => i.Id == item.Id);

        if (itemForDelete is null)
        {
            throw new DomainException($"Item with id {item.Id} is not in receipt");
        }

        _items.Remove(itemForDelete);
    }

    public void AddItem(ReceiptItem item)
    {
        if (_items.Any(i => i.Id == item.Id))
        {
            throw new DomainException($"Receipt already contains item with id {item.Id}");
        }

        _items.Add(item);
    }
}