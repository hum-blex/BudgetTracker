using Budget.Data;
using Budget.Models;
using Budget.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Budget.Controllers;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _db;
    public TransactionController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<TransactionModel> objTransactionList = _db.transaction.Include(t => t.Category).ToList();

        return View(objTransactionList);
    }
    [HttpGet]
    public IActionResult Upsert(int? id)
    {
        TransactionVM transactionVM = new()
        {
            CategoryList = _db.categories.Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.Id.ToString(),
            }),
            Transaction = new TransactionModel()

        };
        if (id == null || id == 0)
        {
            return View(transactionVM);
        }
        transactionVM.Transaction = _db.transaction.FirstOrDefault(u => u.Id == id);
        return View(transactionVM);
    }
    [HttpPost]
    public IActionResult Upsert(TransactionVM transactionVM)
    {
        if (ModelState.IsValid)
        {
            transactionVM.Transaction.DateTime = DateTime.Now;
            if (transactionVM.Transaction.Id == 0) _db.transaction.Add(transactionVM.Transaction);
            else
            {
                _db.transaction.Update(transactionVM.Transaction);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(transactionVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int? id)
    {
        var transaction = _db.transaction.Find(id);
        if (transaction == null)
        {
            return NotFound();
        }
        _db.transaction.Remove(transaction);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
