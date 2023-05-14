﻿using Core.Domain.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public sealed class Receipt : EntityBase<ReceiptId>, IAggregateRoot
{
    public Receipt(User user, string shopName, DateTime dateTime, IEnumerable<ReceiptItem> items)
    {
        User = user ?? throw new ArgumentNullException(nameof(User));
        ShopName = shopName ?? throw new ArgumentNullException(nameof(ShopName));
        DateTime = dateTime;
        Items = items ?? throw new ArgumentNullException(nameof(Items));
    }

    private Receipt() { }

    private readonly List<ReceiptItem> _items;
    private string _shopName;
    private DateTime _dateTime;
   
    public User User { get; private init; }
    
    public string ShopName
    {
        get => _shopName;
        
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("Shop name cannot be empty");
            }

            _shopName = value;
        }
    }

    public DateTime DateTime
    {
        get => _dateTime;

        set
        {
            if (value == DateTime.MinValue)
            {
                throw new InvalidOperationException("Date and time cannot be empty");
            }

            _dateTime = value;
        }
    }

    public decimal Total => _items.Sum(i => i.Coast);
    
    public IEnumerable<ReceiptItem> Items
    {
        get => _items;
        
        init
        {
            if (value.Count() == 0)
            {
                throw new InvalidOperationException("Receipt have to have one or more items");
            }

            _items = value.ToList();
        }
    }

    public void ChangeShopNameTo(string newShopName)
        => ShopName = newShopName;

    public void ChangeDateTimeTo(DateTime newDateTime)
        => DateTime = newDateTime;

    public void DeleteItem(ReceiptItem item)
    {
        if (_items.Count == 1)
        {
            throw new InvalidOperationException("Receipt must contain at least one item");
        }

        var itemForDelete = _items.FirstOrDefault(i => i.Id == item.Id);

        if (itemForDelete is null)
        {
            throw new InvalidOperationException($"Receipt does not have item with id {item.Id}");
        }

        _items.Remove(itemForDelete);
    }

    public void AddItem(ReceiptItem item)
    {
        if (_items.Any(i => i.Id == item.Id))
        {
            throw new InvalidOperationException($"Receipt already contains item with id {item.Id}");
        }

        _items.Add(item);
    }
}