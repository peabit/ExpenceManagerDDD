using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Exceptions;
using Core.Domain.AggregatesModel.Users;

namespace Core.Infrastructure.Domain.Receipts;

public class ReceiptCreationService : IReceiptCreationService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public ReceiptCreationService(ICategoryRepository categoryRepository, IUserRepository userRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
    }

    public async Task<Receipt> CreateReceiptAsync(UserId userId, string shopName, DateTime dateTime, IEnumerable<ReceiptItem> items)
    {
        if (!await _userRepository.Contains(userId))
        {
            throw new DomainException($"User with id {userId} does not exist");
        }

        foreach (var item in items)
        {
            if (!await _categoryRepository.Contains(userId, item.CategoryId))
            {
                throw new DomainException($"User with {userId} does not have category with id {item.CategoryId}");
            }
        }

        return new Receipt(userId, shopName, dateTime, items);
    }
}