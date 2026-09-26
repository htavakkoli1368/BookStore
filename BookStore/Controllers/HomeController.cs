using System.Diagnostics;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Book> books = new()
        {
            new Book { Id = 1, Title =  "Clean Code",Author="Hossein",Price=2500 },
            new Book { Id = 2, Title =  "The Pragmatic Programmer",Author="Ali",Price=7600 },
            new Book { Id = 3, Title =  "Design Patterns",Author="Saeed",Price=3800 }

        };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
             
            return View(books);
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
