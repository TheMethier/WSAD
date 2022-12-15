using Microsoft.AspNetCore.Mvc;
using New.Models;
using System.Diagnostics;
using System.Dynamic;

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
            var gra = _context.Gra.Find(id);
            ViewBag.komentarze = _context.NowyKomentarz.ToList();
            return View(gra);
        }
        public IActionResult Koszyk()
        {

            return View();
        }
        public IActionResult Dodajkomentarz(int id)
        {
            ViewBag.gra = _context.Gra.Find(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodajkomentarz([Bind("GraId","Username","Ocena", "Treść")] NowyKomentarz nowykom)
        {
            if (ModelState.IsValid)
            {
                _context.NowyKomentarz.Add(nowykom);
                _context.SaveChanges();
                var gra = _context.Gra.Find(nowykom.GraId);
                ViewBag.komentarze = _context.NowyKomentarz.ToList();
                return View("Game",gra);
            }
            else
            {
                return View(nowykom);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}