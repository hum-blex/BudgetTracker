﻿using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
	}
}
