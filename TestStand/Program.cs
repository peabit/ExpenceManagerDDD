using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure;
using Core.Infrastructure.Domain.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Infrastructure.Domain.Receipts;
using Core.Infrastructure.Domain.Categories;
using Core.Application.Rceipts.CreateReceipt;
using Core.Infrastructure.Domain.Users;

var db = new CoreDbContext();

var receiptrepository = new ReceiptRepository(db);
var categoryRepository = new CategoryRepository(db);
var userProvider = new FakeUserProvider();

var user = new User("555");
categoryRepository.AddAsync(new Category(user, "ХБ"));

var createReceiptCommandHandler = new CreateReceiptCommandHandler(userProvider, receiptrepository, categoryRepository);

var category = db.Categories.First();

var items = new List<ReceiptItemDto>()
{
    new ReceiptItemDto(category.Id.ToString(), "", 25, 1),
    new ReceiptItemDto(category.Id.ToString(), "Булочка с корицей", 30, 1)
};

createReceiptCommandHandler.Handle(new CreateReceiptCommand("555", "Пятёрочка", DateTime.Now, items));

var createdReceipt = db.Receipts.First();
_ = 0;