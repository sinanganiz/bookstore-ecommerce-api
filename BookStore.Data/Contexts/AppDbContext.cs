using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }




}
