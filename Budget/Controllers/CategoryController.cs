using Budget.Data;
using Budget.Models;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers;

public class CategoryController : Controller
{
	private readonly ApplicationDbContext _db;
	public CategoryController(ApplicationDbContext db)
	{
		_db = db;
	}
	public IActionResult Index()
	{
		List<CategoryModel> objCategoryList = _db.categories.ToList();
		return View(objCategoryList);
	}
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public IActionResult Create(CategoryModel obj)
	{
		if (ModelState.IsValid)
		{
			_db.categories.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View();
	}

	public IActionResult Edit(Guid? id)
	{
		if (id == null || id == Guid.Empty)
		{
			return NotFound();
		}
		CategoryModel? categoryfromdb = _db.categories.FirstOrDefault(c => c.Id == id);
		if (categoryfromdb == null)
		{
			return NotFound();
		}
		return View(categoryfromdb);
	}
	[HttpPost]
	public IActionResult Edit(CategoryModel obj)
	{
		if (ModelState.IsValid)
		{
			_db.categories.Update(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View();
	}

	public IActionResult Delete(Guid? id)
	{
		if (id == null || id == Guid.Empty)
		{
			return NotFound();
		}
		CategoryModel? categoryfromdb = _db.categories.FirstOrDefault(c => c.Id == id);
		if (categoryfromdb == null)
		{
			return NotFound();
		}
		return View(categoryfromdb);
	}

	[HttpPost, ActionName("Delete")]
	public IActionResult DeletePOST(Guid? id)
	{
		CategoryModel? obj = _db.categories.FirstOrDefault(u => u.Id == id);
		if (obj == null)
		{
			return NotFound(id);
		}
		_db.categories.Remove(obj);
		_db.SaveChanges();
		return RedirectToAction("Index");
	}
}
