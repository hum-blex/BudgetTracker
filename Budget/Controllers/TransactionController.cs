using Budget.Data;
using Budget.Models;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
	public class TransactionController : Controller
	{
		private readonly ApplicationDbContext _db;
		public TransactionController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(TransactionModel transactionModel)
		{
			var transaction = new TransactionModel
			{
				Name = transactionModel.Name,
				Amount = transactionModel.Amount,
				Category = transactionModel.Category,
				DateTime = DateTime.Now,
				CategoryId = transactionModel.Category.Id,
			};
			await _db.transaction.AddAsync(transaction);
			_db.SaveChanges();
			return View();
		}
	}
}
