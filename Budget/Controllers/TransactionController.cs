using Budget.Data;
using Budget.Models;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
	public class TransactionController : Controller
	{
		private readonly ApplicationDbContext db;
		public TransactionController(ApplicationDbContext _db)
		{
			this.db = _db;
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
		public IActionResult Create(TransactionModel transaction)
		{
			return View();
		}
	}
}
