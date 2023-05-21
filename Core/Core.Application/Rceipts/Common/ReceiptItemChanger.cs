using Core.Domain.AggregatesModel.Receipts;

namespace Core.Application.Rceipts.Common
{
    public abstract class ReceiptItemChanger
    {
        private readonly ReceiptChanger _receiptChanger;

        protected ReceiptItemChanger(ReceiptChanger receiptChanger)
            => _receiptChanger = receiptChanger;

        public async Task Change<TCommand>(TCommand command, Action<ReceiptItem> action)
            where TCommand : ManipulateReceiptItemCommand
        {
            await _receiptChanger.Change(command, receipt =>
            {
                var item = receipt.GetItem(new ReceiptItemId(command.ItemId));
                action(item);
            });
        }
    }
}