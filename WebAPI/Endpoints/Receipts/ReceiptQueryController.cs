using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Application.Receipts.FindReceiptsByPeriod;
using Core.Application.Receipts.GetReceipt;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts;

public class ReceiptQueryController 
{
    private readonly IQueryHandler<GetReceiptQuery, ReceiptDto> _getReceiptHandler;
    private readonly IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> _findReceiptsByPeriod;

    private const string UserId = "555";

    public ReceiptQueryController(
        IQueryHandler<GetReceiptQuery, ReceiptDto> getReceiptHandler,
        IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> findReceiptsByPeriod
    )
    {
        _getReceiptHandler = getReceiptHandler;
        _findReceiptsByPeriod = findReceiptsByPeriod;
    }

    public async Task GetSingleByIdAsync(string id)
    {
        //throw new Exception("dfgdfg");

        //var d = new Dictionary<string, string[]>()
        //{
        //    { "F1", new string [] { "E1", "E2" } }
        //};

        //throw new ValidationException("EEEEE", d);
        var query = new GetReceiptQuery("", id);
        var receipt = await _getReceiptHandler.HandleAsync(query);

    }

    public async Task FindByPeriodAsync(DateTime from, DateTime to)
    {
        var query = new FindReceiptsByPeriodQuery(UserId, from, to);
        var receipts = await _findReceiptsByPeriod.HandleAsync(query);

        if (receipts.Any())
        {
        }

    }
}