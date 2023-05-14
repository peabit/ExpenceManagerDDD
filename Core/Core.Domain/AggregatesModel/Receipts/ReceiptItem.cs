using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public sealed class ReceiptItem : EntityBase<ReceiptItemId>
{
    public ReceiptItem(CategoryId categoryId, string name, decimal price, int quantity = 1)
    {
        CategoryId = categoryId ?? throw new ArgumentNullException(nameof(CategoryId));
        Name = name ?? throw new ArgumentNullException(nameof(Name));
        Price = price;
        Quantity = quantity;
    }

    private ReceiptItem() { }

    private string _name;
    private decimal _price;
    private int _quantity;
    
    public string Name
    {
        get => _name;

        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("Position name cannot be empty");
            }

            _name = value;
        }
    }

    public decimal Price
    {
        get => _price;
        
        private set
        {
            if (value < 0)
            {
                throw new InvalidOperationException("Position price cannot be negative");
            }

            _price = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        
        private set
        {
            if (value <= 0)
            {
                throw new InvalidOperationException("Position quantity cannot be <= 0");
            }

            _quantity = value;
        }
    }

    public CategoryId CategoryId { get; private init; }

    public decimal Coast => Price * Quantity;

    public void ChangePriceTo(decimal newPrice)
        => Price = newPrice;

    public void ChangeQuantityTo(int newQuantity)
        => Quantity = newQuantity;

    public void ChangeNameTo(string newName)
        => Name = newName;
}