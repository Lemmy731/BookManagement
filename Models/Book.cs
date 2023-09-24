using System.ComponentModel.DataAnnotations;

namespace BookManagemant.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Authot name cannot be more than 50 characters")] // Data annotation
        [Required]
        public string Author { get; set; }
        public string? BookName { get; set; }
        public string? Publisher { get; set; }
        public string? ISBN { get; set; }
        public DateTime DatePublsihed { get; set; }
        public string Title { get; set; }
    }
}
