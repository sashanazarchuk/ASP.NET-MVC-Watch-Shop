using Microsoft.AspNetCore.Mvc;
using Data;
using Project.Models;
using System.Diagnostics;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.ViewModels;
using Project.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly WatchShopDbContext context;

        public HomeController(WatchShopDbContext context)
        {
            this.context = context;
        }
        public void SetClockFace()
        {
            var clockface = context.ClockFace.ToList();
            ViewBag.CFList = new SelectList(clockface, nameof(ClockFace.Id), nameof(ClockFace.Name));
        }
        public IActionResult Index()
        {
            var watches = context.Watches.Select(w => new WatchCartViewModel()
            {
                Watch = w,
            }).ToList();

            foreach (var item in watches)
            {
                item.IsInCart = IsProductInCart(item.Watch.Id);
            }

            SetClockFace();
            return View(watches);

        }
        private bool IsProductInCart(int id)
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) return false;

            return ids.Contains(id);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}