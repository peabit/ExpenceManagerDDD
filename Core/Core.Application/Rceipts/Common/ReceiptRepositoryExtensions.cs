using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Rceipts.Common;

internal static class ReceiptRepositoryExtensions
{
    internal static async Task<Receipt> GetForManipulateCommandAsync(this IReceiptRepository repository, ManipulateReceiptCommand command)
    {
        var receipt = await repository.GetAsync(new User(command.UserId), new ReceiptId(command.ReceiptId));
        return receipt;
    }
}