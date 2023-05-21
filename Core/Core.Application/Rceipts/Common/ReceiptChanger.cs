﻿using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Rceipts.Common
{
    public abstract class ReceiptChanger
    {
        private readonly IReceiptRepository _receiptRepository;

        protected ReceiptChanger(IReceiptRepository receiptRepository)
            => _receiptRepository = receiptRepository; 

        public async Task Change<TCommand>(TCommand command, Action<Receipt> action)
            where TCommand : ManipulateReceiptCommand
        {
            var receipt = await _receiptRepository.GetAsync(new User(command.UserId), new ReceiptId(command.ReceiptId));
            action(receipt);
            await _receiptRepository.UpdateAsync(receipt);
        }
    }
}