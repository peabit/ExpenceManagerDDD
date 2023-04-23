using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure;
using Core.Infrastructure.Domain.DataAccess;

var id = new ReceiptId(new Guid("5eaffb73-b3d5-4134-975a-141a56818c02"));
var q = new DomainContext();

var receipt = q.Receipts.First(r => r.Id == id);

q.Dispose();
q = null;

q = new DomainContext();

receipt.ShopName = "Пятёрочка";
q.Receipts.Update(receipt);
q.SaveChanges();
//var receipt = new Receipt()
//{
//    Id = new ReceiptId(Guid.NewGuid()),
//    ShopName = "ZXCVB",
//    DateTime = DateTime.Now
//};

//q.Receipts.Add(receipt);


_ = 0;