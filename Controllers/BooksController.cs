using BookManagemant.DTO;
using BookManagemant.Helper;
using BookManagemant.Models;
using BookManagemant.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookManagemant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly UserManager<UserObject> _userManager;
        //private readonly SignInManager<UserObject> _signInManager;
        //private readonly RoleManager<Role> _roleManager;


        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            //, UserManager<UserObject> userManager,
            //SignInManager< UserObject > signInManager, RoleManager<Role> roleManager
            _bookRepository = bookRepository;
            //_userManager = userManager;
            //_signInManager = signInManager;
            //_roleManager = roleManager;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {

            // create a user
            //var userObject = _userManager.CheckPasswordAsync(UserObject, );

            //_signInManager;

            //_roleManager.


            // pagination








            if(book == null)
            {
                return BadRequest("Provide valid book details");
            }
            _bookRepository.AddBook(book);
            return Ok("Book added to the database");
        }

        [HttpDelete("RemoveBook")]
        public async Task<IActionResult> RemoveBook([FromBody] string Isbn)
        {
            var bookToRemove = _bookRepository.RemoveBook(Isbn);
            if(bookToRemove == null)
            {
                return BadRequest("Book not found");
            }

            return Ok("Book deleted successfully");
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            _bookRepository.UpdateBook(book);
            
            return Ok("Book updated successfully");
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks([FromQuery] PaginatedParameters parameters)
        {
            var books = await _bookRepository.GetBooks(parameters);

            return Ok(APIListResponseDto.Success(books, books.MetaData.PageSize, books.MetaData.TotalPages, books.MetaData.TotalCount,
                books.MetaData.HasPrevious, books.MetaData.HasNext));

            //return Ok();
        }
    }
}
