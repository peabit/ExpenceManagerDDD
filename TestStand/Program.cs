using Core.Application.Rceipts.FindReceiptsByPeriod;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Common;
using Core.Application.Common;
using System.Linq;
using Core.Application.Rceipts.GetReceipt;

var connectionFactory = new SqliteConnectionFactory("Data source = test.db");
var sqlQueryExecutor = new SqlQueryExecutor(connectionFactory);
var queryHandler = new GetReceiptQueryHandler(sqlQueryExecutor);

var receipts = await queryHandler.Query(new GetReceiptQuery("555", "59ac531b-d857-4e3d-bbf1-1c05a8737e46"));

_ = 0;