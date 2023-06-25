using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure.Application;

namespace Core.WebAPI;

public sealed class TestDataInitializer
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUserProvider _userProvider;
    private readonly IUnitOfWork _unitOfWork;

    public TestDataInitializer(ICategoryRepository categoryRepository, IReceiptRepository receiptRepository, IUserProvider userProvider, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Initialize()
    {
        var user = await _userProvider.GetAsync(userId: "9eadfc0a-bca1-44d5-b9b0-e73b1299fa58");

        var breadCategory = user.CreateCategory(name: "Хлебобулочные изделия");
        await _categoryRepository.AddAsync(breadCategory);

        var fruitCategory = user.CreateCategory(name: "Фрукты");
        await _categoryRepository.AddAsync(fruitCategory);

        var receiptItems = new List<ReceiptItem>();
        receiptItems.Add(breadCategory.CreateReceiptItem(name: "Булочка с творогом", price: 25));
        receiptItems.Add(fruitCategory.CreateReceiptItem(name: "Банан", price: 15, quantity: 3));

        var receipt = user.CreateReceipt(shopName: "Пятёрочка", dateTime: DateTime.Parse("2023-06-25 00:00"), receiptItems);
        await _receiptRepository.AddAsync(receipt);

        await _unitOfWork.CommitAsync();
    }
}