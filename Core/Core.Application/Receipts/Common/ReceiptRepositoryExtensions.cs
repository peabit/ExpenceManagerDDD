using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.Common;

internal static class ReceiptRepositoryExtensions
{
    public static async Task<Receipt> FindReceiptForChangeAsync(this IReceiptRepository repository, ChangeReceiptCommandBase changeCommand, IUserProvider userProvider)
    {
        var user = await userProvider.GetAsync(changeCommand.UserId);
        
        var receipt = await repository.GetAsync(user, new ReceiptId(changeCommand.ReceiptId));
        
        return receipt;
    }
}