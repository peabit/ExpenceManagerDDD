using Core.Domain.AggregatesModel.CategoryAggregate;
using Core.Domain.AggregatesModel.ReceiptAggregate;

namespace Core.Domain.AggregatesModel.UserAggregate;

public class User
{
    public UserId Id { get; set; }
    public string Name { get; set; }    

    public Category CreateCategory(String name, CategoryId parent = null)
    {
        throw new NotImplementedException();
    }

    public Receipt CreateReceipt(String shopName, DateTime dateTime, IEnumerable<ReceiptItem> items)
    {
        throw new NotImplementedException();
    }
}