using Core.Application.Rceipts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Rceipts.ChangeReceiptItemQuantity;

public sealed record ChangeReceiptItemQuantityCommand : ManipulateReceiptItemCommand
{
    public ChangeReceiptItemQuantityCommand(string userId, string receiptId, string itemId, int newQuantity) 
        : base(userId, receiptId, itemId)
    {
        NewQuantity = newQuantity;
    }

    public int NewQuantity { get; private init; }
}
