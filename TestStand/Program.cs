using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure;
using Core.Infrastructure.Domain.Common;
using Core.Domain.AggregatesModel.UserAggregate;

//var id = new ReceiptId(new Guid("5eaffb73-b3d5-4134-975a-141a56818c02"));
//var items = new List<ReceiptItem>()
//{
//    new ReceiptItem(new ReceiptItemId(Guid.NewGuid()), "Молоко", 64, 2),
//    new ReceiptItem(new ReceiptItemId(Guid.NewGuid()), "Хлеб", 34)
//};

//var receipt = new Receipt(id, new UserId(Guid.NewGuid()), "Пятёрочка", DateTime.Now, items);

var db = new SqliteContext();
//db.Receipts.Add(receipt);
//db.SaveChanges();

//db.Dispose();
//db = new SqliteContext();

var receipt = db.Receipts.First();
receipt.ChangeShopNameTo("Вкусвил");

receipt.DeleteItem(receipt.Items.First());
receipt.Items.First().ChangeNameTo("Сметана");

receipt.AddItem(new ReceiptItem(new ReceiptItemId(Guid.NewGuid()), "Макароны", 95));
db.Receipts.Update(receipt);

//db.Dispose();
//db = new SqliteContext();

//receipt.ShopName = "Перекрёсток";
//receipt.Items.First().Name = "Кефир";

//db.Receipts.Update(receipt);
db.SaveChanges();

_ = 0;