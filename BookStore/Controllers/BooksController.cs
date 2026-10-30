using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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

        public IActionResult Index(string? searchTerm,string? author,int page=1)
        {
            int pageSize = 5;   
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm)) 
            { 
                query = query.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm));
            }
            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(b =>b.Author == author);
            }
            var authors =_context.Books.Select(b => b.Author)
                .Distinct()
                 .OrderBy(a => a)
                .ToList();
            int totalCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            page = Math.Clamp(page, 1, totalPages);
            var books = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var viewModel = new BooksIndexViewModel
            {
                Books = books,
                SearchItem = searchTerm,
                SelectedAuthor = author,
                Authors = authors,
                CurrentPage = page,
                TotalPages = totalPages
            };
            return View(viewModel);     
        }      
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateForm(CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
          
            var books = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price
            };
             //save the model into Database
             _context.Books.Add(books);
            _context.SaveChanges();
            
            TempData["SuccessMessage"] = "Book created successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return Content($"this is id : {id}");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        //browser->routing->controller->action->view->html->browser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            _context.Books.Update(book);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Book updated successfully!";

            return RedirectToAction(nameof(Index));
        }
        // GET: Books/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Book deleted successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}
