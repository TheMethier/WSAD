using Microsoft.AspNetCore.Mvc;
using New.Models;
using System.Diagnostics;
<<<<<<< HEAD
using System.Web;
using Microsoft.AspNetCore.Http;
using New.Helpers;
=======
using System.Dynamic;

>>>>>>> f04acf0876faa0f29d8a97849a6c8ad0cc3a37ab
namespace New.Controllers
{
    public class HomeController : Controller
    {
        //Dodaj stronę główną, kod rabatowy KredekPizza,
        //scrollnav 
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var gry = _context.Gra
                .ToList();
            var card = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            ViewBag.Kosz = card;
            return View(gry);
        }
        public IActionResult Privacy()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            ViewBag.Kosz = cart;
            return View();
        }
        public IActionResult Game(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            var gra = _context.Gra
                .Find(id);
            var card = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            ViewBag.Kosz = card;
            ViewBag.komentarze = _context.NowyKomentarz.ToList();


            var gra = _context.Gra.Find(id);
            ViewBag.komentarze = _context.NowyKomentarz.ToList();
            return View(gra);
        }
        public IActionResult Dodajkomentarz(int id)
        {
            ViewBag.gra = _context.Gra.Find(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodajkomentarz([Bind("GraId", "Username", "Ocena", "Treść")] NowyKomentarz nowykom)
        {
            if (ModelState.IsValid)
            {
                _context.NowyKomentarz.Add(nowykom);
                _context.SaveChanges();
                var gra = _context.Gra.Find(nowykom.GraId);
                ViewBag.komentarze = _context.NowyKomentarz.ToList();
                return View("Game", gra);
            }
            else
            {
                var gra = _context.Gra.Find(nowykom.GraId);
                ViewBag.gra = gra;
                return View(nowykom);
            }
        }
        public IActionResult KoszykAdd(int id)
        {
            var gra = _context.Gra.Find(id);
            if (SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart") == null)
            {
                List<Element_koszyka> kosz = new List<Element_koszyka>();
                if (kosz.Count == 0) {
                    kosz.Add(new Element_koszyka() { Gra = gra, ilość = 1, ElementId = kosz.Count,Razem=gra.Cena });
                    
                }
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", kosz);
            }
            else {
                List<Element_koszyka> kosz = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
                var exist =isExist(id);
                if(exist!=-1)
                {      
                    kosz[exist].ilość += 1;
                    kosz[exist].Razem = kosz[exist].Razem + kosz[exist].Gra.Cena;
                }
                else
                {
                    kosz.Add(new Element_koszyka() { Gra = gra, GraId=gra.Id, ilość = 1, ElementId=kosz.Count, Razem=gra.Cena });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", kosz);
            }
            return RedirectToAction("Koszyk");
        }
        public IActionResult KoszykRemove(int id)
        {
            var gra = _context.Gra.ToList();
            List<Element_koszyka> kosz = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            var exist=isExist(id);
            if (exist!=-1)
            {
                if (kosz[exist].ilość > 1)
                {
                    kosz[exist].ilość -= 1;
                    kosz[exist].Razem=kosz[exist].Razem-kosz[exist].Gra.Cena;
                }
                else
                {               
                    kosz.Remove(kosz[exist]);
                }
            }
            else
            {
                kosz.Remove(kosz[exist]);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", kosz);
            return RedirectToAction("Koszyk");
        }
        public IActionResult Koszyk()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            
            if (cart != null)
            {
                ViewBag.cart = cart.ToList();
                ViewBag.Razem = cart.Sum(x => x.Gra.Cena * x.ilość);
            }
            //pomysł - lista w sesji będzie się "przepisywała" do DB, gdy będzie widoczna, a nie gdy użytkownik będzie poza koszykiem
            return View();
        }
        public IActionResult MakeOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeOrder([Bind("Email, Username, CreditCard")] Order order)
        {
            //Dodaj validacje i zrób, żeby razem się ustawiało w DB 
            if (ModelState.IsValid)
            {
                var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
                order.CreatedDate = DateTime.Now;
                order.Razem = cart.Sum(x => x.ilość * x.Gra.Cena);
                _context.Add(order);
                _context.SaveChanges();
                foreach (var element in cart)
                {
                    if (element != null)
                    {
                        var Gra = element.Gra;
                        if (Gra != null)
                        {
                            var graid = Gra.Id;
                            OrderDetails details = new OrderDetails()
                            {
                                GraId = _context.Gra.Find(graid).Id,
                                OrderId = _context.Order.Find(order.Id).Id,
                                ilość = element.ilość,
                                gra = _context.Gra.Find(graid),
                                Cena = (_context.Gra.Find(graid).Cena * element.ilość),
                                Order = _context.Order.Find(order.Id),
                            };
                            _context.OrderDetails.Add(details);
                        }
                    }
                }
                _context.SaveChanges();
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                var t = _context.OrderDetails.Where(x => x.OrderId == order.Id).ToList();
                return RedirectToAction("PlacedOrder", order);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                return View();
            }
        }
        public IActionResult PlacedOrder(Guid Id)
        {
            var order = _context.Order.Find(Id);
            var orderd = _context.OrderDetails.Where(_x => _x.OrderId == Id).ToList();
            //wiem, że to jest głupie, ale działa. Nie ruszać
            List<Element_koszyka> Games = new List<Element_koszyka>();
            foreach (var item in orderd)
            {
                var gra = _context.Gra.Find(item.GraId);
                Games.Add(new Element_koszyka() { Gra=gra, ilość=item.ilość, Razem=gra.Cena*item.ilość});
            }
            ViewBag.order = order;
            ViewBag.games= Games;
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
        private int isExist(int id)
        {
            List<Element_koszyka> cart = SessionHelper.GetObjectFromJson<List<Element_koszyka>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Gra.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
