using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "the Title should be Entered")]
        [StringLength(100,ErrorMessage = "the length of Title should be 100")]
        public string Title { get; set; }
        [Required(ErrorMessage = "the Author should be Entered")]
        [StringLength(100, ErrorMessage = "the length of Author should be 100")]
        public string Author { get; set; }
        [Range(typeof(decimal),"0.01","1000000",ErrorMessage ="the price must be greather than zero")]
        public decimal Price { get; set; }

    }
}
