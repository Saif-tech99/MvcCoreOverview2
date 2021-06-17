using Microsoft.AspNetCore.Mvc;
using MvcCoreOverview2.Models;
using MVCEFCoreOverview.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookContext _db;

        public AuthorController(BookContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Authors> lst = _db.Authors;
            //List<Authors> lst = _db.Authors.ToList();
            return View(lst);
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Authors authors)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(authors);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }
    }
}
