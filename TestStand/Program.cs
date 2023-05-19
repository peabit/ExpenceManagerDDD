using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure;
using Core.Infrastructure.Domain.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Infrastructure.Domain.Receipts;
using Core.Infrastructure.Domain.Categories;
using Core.Application.Rceipts.CreateReceipt;
using Core.Infrastructure.Domain.Users;
using Core.Application.Rceipts.DeleteReceipt;
using Core.Application.Rceipts.ChangeReceiptDateTime;
using Core.Application.Rceipts.AddItemToReceipt;
using Core.Application.Receipts.Common;

var db = new CoreDbContext();

var receiptrepository = new ReceiptRepository(db);
var categoryRepository = new CategoryRepository(db);
var userProvider = new FakeUserProvider();

//var deleteReceiptCommandHandler = new DeleteReceiptCommandHandler(receiptrepository);

//var user = new User("555");
//categoryRepository.AddAsync(new Category(user, "ХБ"));

//var createReceiptCommandHandler = new CreateReceiptCommandHandler(userProvider, receiptrepository, categoryRepository);

var category = db.Categories.First();

//var items = new List<ReceiptItemDto>()
//{
//    new ReceiptItemDto(category.Id.ToString(), "Булочка с маком", 25, 1),
//    new ReceiptItemDto(category.Id.ToString(), "Булочка с корицей", 30, 1)
//};

//createReceiptCommandHandler.Handle(new CreateReceiptCommand("555", "Пятёрочка", DateTime.Now, items));

var ch = new AddItemToReceiptCommandHandler(receiptrepository);
ch.Handle(new AddItemToReceiptCommand("555", "59ac531b-d857-4e3d-bbf1-1c05a8737e18", new ReceiptItemDto(category.Id.ToString(), "Улитка со шпинатом и сыром", 50, 1)));

_ = 0;