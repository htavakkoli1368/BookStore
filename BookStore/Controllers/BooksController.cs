using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewData["TitlePage"] = "Books";
            ViewBag.TitlePage = "Books";
            var books = _context.Books.ToList();
            return View(books);     
        }      
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateForm(CreateBookViewModel model)
        {
            var books = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price
            };
             //save the model into Database
             _context.Books.Add(books);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return Content($"this is id : {id}");
        }
        //browser->routing->controller->action->view->html->browser
    }
}
