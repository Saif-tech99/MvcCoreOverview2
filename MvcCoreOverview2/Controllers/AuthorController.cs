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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Authors authors)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Update(authors);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Authors authors)
        {
            if (authors.Author_Id == 0)
            {
                return NotFound();
            }
            _db.Authors.Remove(authors);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
