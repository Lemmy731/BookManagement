namespace BookManagemant.DTO
{
    public class BookDto // Data transfer object
    {
        public string Author { get; set; }
        public string? BookName { get; set; }
        public string? Publisher { get; set; }
        public string? ISBN { get; set; }
        public DateTime DatePublsihed { get; set; }
        public string Title { get; set; }
    }
}
