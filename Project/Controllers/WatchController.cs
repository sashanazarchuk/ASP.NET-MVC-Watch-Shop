using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Data.Models;
using System;
using Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Project.Controllers
{
    public class WatchController : Controller
    {
        private readonly WatchShopDbContext context;
        public WatchController(WatchShopDbContext context)
        {
            this.context = context;
        }

        public void SetClockFace()
        {
            var clockface = context.ClockFace.ToList();
            ViewBag.CFList = new SelectList(clockface, nameof(ClockFace.Id), nameof(ClockFace.Name));
        }

        [HttpGet]
        public async Task<IActionResult> Watches(string SortOrder)//сортування
        {
            var watches = from w in context.Watches select w;
            watches = context.Watches.Include(w => w.ClockFace);
            ViewData["ModelSortParam"] = string.IsNullOrEmpty(SortOrder) ? "Model" : "";
            ViewData["MaterialSortParam"] = string.IsNullOrEmpty(SortOrder) ? "Material" : "";
            ViewData["GuaranteeSortParam"] = string.IsNullOrEmpty(SortOrder) ? "Guarantee" : "";
            ViewData["ClockFaceSortParam"] = string.IsNullOrEmpty(SortOrder) ? "ClockFace" : "";
            ViewData["PriceSortParam"] = string.IsNullOrEmpty(SortOrder) ? "Price" : "";
            switch (SortOrder)
            {
                case "Model":
                    watches = watches.OrderBy(w => w.Model);
                    watches = watches.OrderByDescending(w => w.Model);
                    break;

                case "Material":
                    watches = watches.OrderBy(w => w.Material);
                    watches = watches.OrderByDescending(w => w.Material);
                    break;

                case "Guarantee":
                    watches = watches.OrderBy(w => w.Guarantee);
                    watches = watches.OrderByDescending(w => w.Guarantee);
                    break;
                case "ClockFace":
                    watches = watches.OrderBy(w => w.ClockFace);
                    watches = watches.OrderByDescending(w => w.ClockFace);
                    break;
                case "Price":
                    watches = watches.OrderBy(w => w.Price);
                    watches = watches.OrderByDescending(w => w.Price);
                    break;

            }
            return View(await watches.AsNoTracking().ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Watches(string SortOrder, string SearchString)//пошук
        {
            ViewData["CurrentFilter"] = SearchString;
            var watches = from w in context.Watches select w;
            if (!String.IsNullOrEmpty(SearchString))
            {
                watches = watches.Where(w => w.Model.Contains(SearchString));
                watches = watches.Include(w => w.ClockFace);
            }
            return View(await watches.AsNoTracking().ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Watch watch = new Watch { Id = id.Value };
                context.Entry(watch).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                TempData["Message"] = "Product was successfully deleted";
                return RedirectToAction("Watches");
            }
            return NotFound();
        }


        public IActionResult Details(int id)
        {
            SetClockFace();
            Watch? watch = context.Watches.Find(id);
            if (watch == null) return NotFound();
            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();
            return View(watch);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetClockFace();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Watch watch)
        {
            if (!ModelState.IsValid)
            {
                SetClockFace();
                return View(watch);
            }

            context.Watches.Add(watch);
            context.SaveChanges();
            TempData["Message"] = "Product is created";
            return RedirectToAction("Watches");
        }

        public IActionResult Edit(int id)
        {

            Watch? watch = context.Watches.Find(id);
            if (watch == null) return NotFound();
            SetClockFace();
            return View(watch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Watch watch)
        {

            if (!ModelState.IsValid)
            {
                SetClockFace();
                return View(watch);
            }
            context.Watches.Update(watch);
            await context.SaveChangesAsync();
            TempData["Message"] = "Product was successfully edited";
            return RedirectToAction("Watches");
        }
    }
}