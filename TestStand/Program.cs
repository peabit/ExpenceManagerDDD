using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure;
using Core.Infrastructure.Domain.Common;
using Core.Domain.AggregatesModel.Categories;

var user = new User("01");
var category = new Category(user, "Выпечка");

var items = new List<ReceiptItem>()
{
    category.CreateReceiptItem("Булочка с маком", 45),
    category.CreateReceiptItem("Булочка с изюмом", 55)
};

var receipt = new Receipt(user, "Вкусвил", DateTime.Now, items);

var db = new SqliteContext();
db.Receipts.Add(receipt);
db.SaveChanges();

db.Dispose();
db = null;
db = new SqliteContext();

var readedReceipt = db.Receipts.First();

_ = 0;