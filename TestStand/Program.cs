using Core.Application.Receipts.FindReceiptsByPeriod;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Common;
using Core.Application.Common;
using System.Linq;
using Core.Application.Receipts.GetReceipt;
using Core.Application.Reports.FindTotalByCategories;
using Dapper;

var connectionFactory = new SqliteConnectionFactory("Data source = test.db");
var sqlQueryExecutor = new SqlQueryExecutor(connectionFactory);
var queryHandler = new FindTotalsByCategoriesQueryHandler(sqlQueryExecutor);
var report = await queryHandler.Query(new FindTotalsByCategoriesQuery("555", DateTime.Parse("2023-05-20"), DateTime.Now, new[] { "WW1", "W" }));

_ = 0;