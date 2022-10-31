using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        private readonly WatchShopDbContext context;
        public CartController(WatchShopDbContext context)
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
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) ids = new List<int>();

            List<Watch?> watches = ids.Select(id => context.Watches.Find(id)).ToList();
            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();
            SetClockFace();
            return View(watches);
        }

        public IActionResult Add(int id)
        {
            if (context.Watches.Find(id) == null) return NotFound();

            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");

            if (ids == null) ids = new List<int>();

            ids.Add(id);
          
            HttpContext.Session.SetObject("cartKey", ids);
            TempData["Message"] = "Product added to the cart";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");

            if (ids == null) return NotFound();

            ids.Remove(id);

            HttpContext.Session.SetObject("cartKey", ids);
            TempData["Message"] = "Product removed from the cart";
            return RedirectToAction("Index", "Home");
        }
    }
}
