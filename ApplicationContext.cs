using BookManagemant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookManagemant
{
    public class ApplicationContext : IdentityDbContext<UserObject>
    {
        public ApplicationContext(DbContextOptions options): base(options){}

        public DbSet<Book> BookStores { get; set; }
        public DbSet<UserObject> UserObjects { get; set; }

    }
}

