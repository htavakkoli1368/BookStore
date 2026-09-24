using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly List<string> books = new()
        {
             "Clean Code",
            "The Pragmatic Programmer",
            "Design Patterns" 
        };

        public IActionResult Index()
        {
            return View(books);     
        }
        public IActionResult Details(int id)
        {
            return Content($"this is id : {id}");
        }
        //browser->routing->controller->action->view->html->browser
    }
}
