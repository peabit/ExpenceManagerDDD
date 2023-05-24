using Core.Application.Rceipts.FindReceiptsByPeriod;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Common;
using Core.Application.Common;
using System.Linq;
using Core.Application.Rceipts.GetReceipt;
using Core.Application.Reports.FindTotalByCategories;

var connectionFactory = new SqliteConnectionFactory("Data source = test.db");
var sqlQueryExecutor = new SqlQueryExecutor(connectionFactory);
var queryHandler = new FindTotalsByCategoriesQueryHandler(sqlQueryExecutor);

var report = await queryHandler.Query(new FindTotalsByCategoriesQuery("", DateTime.Now, DateTime.Now, new []{ "WW1", "W" }));

_ = 0;