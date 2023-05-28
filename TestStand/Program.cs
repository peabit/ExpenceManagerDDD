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
using Core.Application.Categories.UnlinkCategoryFromParent;
using Core.Infrastructure.Domain.Categories;

var qwd = Guid.NewGuid().ToString();    

var q = new CategoryRepository(new CoreDbContext());
var categoryChanger = new CategoryChanger(q);
var queryHandler = new UnlinkCategoryFromParentCommandHandler(categoryChanger);

await queryHandler.Handle(new UnlinkCategoryFromParentCommand("d32ab209-fe90-43ae-9930-d8e18b930737", "4d742c18-db6b-4e55-ac0d-2a239f8c195a"));

_ = 0;