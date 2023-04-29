using Core.Domain.Exceptions;

namespace Core.Domain.AggregatesModel.Receipts;

public class ReceiptItem
{
    public ReceiptItem(ReceiptItemId id, string name, decimal price, int quantity = 1)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    private ReceiptItem() { }

    private string _name;
    private decimal _price;
    private int _quantity;

    public ReceiptItemId Id { get; private init; }
    
    public string Name
    {
        get => _name;
        private set => _name = !String.IsNullOrWhiteSpace(value) ? value : throw new DomainException("Position name cannot be empty");
    }

    public decimal Price
    {
        get => _price;
        private set => _price = value >= 0 ? value : throw new DomainException("Position price cannot be negative");
    }

    public int Quantity
    {
        get => _quantity;
        private set => _quantity = value > 0 ? value : throw new DomainException("Position quantity cannot be <= 0");
    }

    public decimal Coast => Price * Quantity;

    public void ChangePriceTo(decimal newPrice)
        => Price = newPrice;

    public void ChangeQuantityTo(int newQuantity)
        => Quantity = newQuantity;

    public void ChangeNameTo(string newName)
        => Name = newName;
}