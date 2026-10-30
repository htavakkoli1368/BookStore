using BookStore.Models;

namespace BookStore.ViewModel
{
    public class BooksIndexViewModel
    {
        public List<Book> Books { get; set; } = new();
        public string? SearchItem { get; set; }
        public string? SelectedAuthor { get; set; }
        public List<string> Authors { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
