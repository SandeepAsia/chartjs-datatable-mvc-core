using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChartJsMvcCore.Entity;
using ChartJsMvcCore.Models;
using System.Diagnostics;
using System.Linq;

namespace ChartJsMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(Product obj)
        {
            obj.list = _context.TblProducts.ToList();
            return View(obj);
        }

        [HttpPost]
        public JsonResult ChartData()
        {
            var iData = _context.TblProducts.ToList();
            return Json(iData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
