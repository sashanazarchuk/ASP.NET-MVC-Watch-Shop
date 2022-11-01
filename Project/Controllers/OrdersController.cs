using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Helpers;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly WatchShopDbContext context;
        public OrdersController(WatchShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = context.Orders.Where(w => w.UserId == userid);      
            return View(order);
        }
        public void SetClockFace()
        {
            var clockface = context.ClockFace.ToList();
            ViewBag.CFList = new SelectList(clockface, nameof(ClockFace.Id), nameof(ClockFace.Name));
        }
        public async Task<IActionResult> Add()
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) return BadRequest();

            List<Watch?> watches = ids.Select(id => context.Watches.Find(id)).ToList();
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Order order = new Order()
            {
                Date = DateTime.Now,
                TotalPrice = watches.Sum(w => w.Price),
                UserId = userid
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
    }
}
