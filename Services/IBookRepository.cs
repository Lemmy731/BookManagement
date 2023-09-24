using BookManagemant.DTO;
using BookManagemant.Helper;
using BookManagemant.Models;

namespace BookManagemant.Services
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        string RemoveBook(string Isbn);
        void UpdateBook(Book book);
        //Task<List<BookDto>> GetBooks(); 
        Task<PageList<BookDto>> GetBooks(PaginatedParameters parameters); 
    }
}
