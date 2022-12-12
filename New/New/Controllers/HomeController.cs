using Microsoft.AspNetCore.Mvc;
using New.Models;
using System.Diagnostics;

namespace New.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var gry = _context.Gra
                .ToList();
            return View(gry);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Game(int id)
        {
            var gra = _context.Gra
                .Find(id);
            return View(gra);
        }
        public IActionResult Koszyk()
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