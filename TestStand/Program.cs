using Core.Application.Receipts.FindReceiptsByPeriod;
using Core.Domain.AggregatesModel.Receipts;
using Core.Infrastructure.Domain.Common;
using Core.Application.Common;
using System.Linq;
using Core.Application.Receipts.GetReceipt;
using Core.Application.Reports.FindTotalsByCategories;
using Dapper;
using Core.Application.Categories.Common;
using Core.Application.Categories.GetCategory;

var db = new CoreDbContext();
db.Receipts.Find(new[] { "59ac531b-d857-4e3d-bbf1-1c05a8737e18", "555" });


//var connectionFactory = new SqliteConnectionFactory("Data source = test.db");
//var sqlQueryExecutor = new SqlQueryExecutor(connectionFactory);
//var queryHandler = new GetCategoryQueryHandler(sqlQueryExecutor);
//var report = await queryHandler.Query(new GetCategoryQuery("h555", "S1"));

_ = 0;