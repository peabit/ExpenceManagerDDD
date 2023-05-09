using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure;
using Core.Infrastructure.Domain.Common;
using Core.Domain.AggregatesModel.Users;
using Core.Domain.AggregatesModel.Categories;

//var userId = new UserId(Guid.NewGuid());

//var category = new Category(userId, "Выпечка");

//var items = new List<ReceiptItem>()
//{
//    category.CreateReceiptItem("Булочка с маком", 45),
//    category.CreateReceiptItem("Булочка с изюмом", 55)
//};

//var receipt = new Receipt(userId, "Вкусвил", DateTime.Now, items);

var db = new SqliteContext();
//db.Receipts.Add(receipt);
//db.SaveChanges();

//db.Dispose();
//db = null;
//db = new SqliteContext();

var readedReceipt = db.Receipts.First();

_ = 0;