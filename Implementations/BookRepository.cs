using Azure;
using BookManagemant.DTO;
using BookManagemant.Helper;
using BookManagemant.Models;
using BookManagemant.Services;
using Microsoft.EntityFrameworkCore;

namespace BookManagemant.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context)  // Repository pattern
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
        }
        public async Task<PageList<BookDto>> GetBooks(PaginatedParameters parameters)
        {

            //var books = await _context.BookStores.Select(x =>
            //new BookDto
            //{
            //    Author = x.Author,
            //    DatePublsihed = x.DatePublsihed,
            //    BookName = x.BookName,
            //    ISBN = x.ISBN,
            //    Publisher = x.Publisher,
            //    Title = x.Title
            //}).ToListAsync();

            PageList<BookDto> res = new PageList<BookDto>(await _context.BookStores.Select(x =>
            new BookDto
            {
                Author = x.Author,
                DatePublsihed = x.DatePublsihed,
                BookName = x.BookName,
                ISBN = x.ISBN,
                Publisher = x.Publisher,
                Title = x.Title
            }).ToListAsync(), 41, parameters.PageNumber, parameters.PageSize);

            return res;
        }

        public string RemoveBook(string Isbn)
        {
            var book = _context.BookStores.FirstOrDefault(x => x.ISBN == Isbn);

            if (book == null)
                return null;

            // delete book
            _context.Remove(book);
            _context.SaveChanges();

            return Isbn;
        }
    }
}
