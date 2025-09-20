using projectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace projectApi.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}