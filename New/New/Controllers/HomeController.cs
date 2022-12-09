using Microsoft.AspNetCore.Mvc;
using New.Models;
using System.Diagnostics;

namespace New.Controllers
{
    public class HomeController : Controller
    {

        List<Gra> listagier;

        public HomeController()
        {
            listagier = new List<Gra>()
            {
          new Gra(1,"Battlefield 1","battle.jpg","battle1.jpg","battle2.jpg","FPS",56.99, "Zdobywaj paski dzięki najwyższej klasy pracy zespołowej, walcząc w historii. Nowa broń została stworzona specjalnie dla tego wydania i musisz odkryć, która broń dobrze współpracuje, aby zapewnić bezbłędne zwycięstwo swojej drużynie!Funkcje: ODNOWIONE KLASY - Wybierz jedną z sześciu klas i pamiętaj o odpowiednim planowaniu z członkami drużyny. Klasy zostały całkowicie przerobione, aby nadać grze bardziej uczciwy charakter. Wybierz, czy chcesz mieszkać w pojeździe jako pilot lub czołgista, czy też chcesz leczyć ludzi jako medyk. Dodatkowo możesz wybrać klasę szturmowca, klasę zwiadowcy i klasę wsparcia.CAŁKOWICIE NOWE MAPY - Jak sugeruje tytuł, jednym z najważniejszych aspektów gry jest pole bitwy! Nowe mapy zostały zawarte w tym wydaniu w historycznych ustawieniach I wojny światowej. Na różnych mapach będą wymagane różne umiejętności i musisz opanować je wszystkie, niezależnie od tego, czy walczysz na froncie zachodnim, w Alpach, czy w Arabii.BROŃ SPECJALNA DLA I WOJNY ŚWIATOWEJ - W grze przywiązuje się dużą wagę do szczegółów, a bronie nie mogą się różnić. System walki wręcz został całkowicie przeprojektowany, dzięki czemu gracze mogą teraz grać łopatami, szabelami i trenczami. Jeśli zabraknie amunicji, nie wszystko jest stracone -dowiedz się, jak wygrywać w walce wręcz!"),
         new Gra(2,"Battlefield 1","battle.jpg","battle1.jpg","battle2.jpg","FPS",56.99, "Battlefield 1 to czternasta gra z serii popularnych gier FPS wydawanych przez Electronic Arts. Kontynuuje ona tradycję doskonałego wykonania, której gracze na całym świecie oczekują. Tym razem cofniesz się do czasów I Wojny Światowej, która nigdy wcześniej nie była teatrem walk w serii Battlefield.")
        };


        }


        public IActionResult Index()
        {
      
            return View(listagier);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Game(int id)
        {
         var gra= listagier.FirstOrDefault(x => x.Id==id);
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