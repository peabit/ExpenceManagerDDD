using Core.Application.Rceipts.FindReceiptsByPeriod;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Common;
using Core.Application.Common;
using System.Linq;

var connectionFactory = new SqliteConnectionFactory("");
var sqlQuery = new SqlQueryExecutor(connectionFactory);