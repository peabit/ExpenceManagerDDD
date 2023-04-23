using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure;
using Core.Infrastructure.Domain.DataAccess;

//var id = new ReceiptId(new Guid("5eaffb73-b3d5-4134-975a-141a56818c02"));
var q = new DomainContext();

var receipt = q.Receipts.First();

q.Dispose();
q = null;

q = new DomainContext();
receipt.Items.First().Name = "Кофе";
q.Receipts.Update(receipt);
//receipt.ShopName = "Пятёрочка";
//q.Receipts.Update(receipt);
//q.SaveChanges();

//var receipt = new Receipt()
//{
//    Id = new ReceiptId(Guid.NewGuid()),
//    ShopName = "ZXCVB",
//    DateTime = DateTime.Now,
//    Items = new List<ReceiptItem>() { new ReceiptItem() { Id = new ReceiptItemId(Guid.NewGuid()), Name = "LLLL" } }
//};

//q.Receipts.Add(receipt);
q.SaveChanges();

_ = 0;