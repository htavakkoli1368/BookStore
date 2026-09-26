using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly List<Book> books = new()
        {
            new Book { Id = 1, Title =  "Clean Code",Author="Hossein",Price=2500 },
            new Book { Id = 2, Title =  "The Pragmatic Programmer",Author="Ali",Price=7600 },
            new Book { Id = 3, Title =  "Design Patterns",Author="Saeed",Price=3800 }
            
        };

        public IActionResult Index()
        {
            //ViewData["TitlePage"] = "Books";
            ViewBag.TitlePage = "Books";
            return View(books);     
        }      
        
        public IActionResult Create()
        {
            return View();
        }     
        public IActionResult CreateForm(CreateBookViewModel model)
        {
            var books = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price
            };
             //save the model into Database       
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return Content($"this is id : {id}");
        }
        //browser->routing->controller->action->view->html->browser
    }
}
