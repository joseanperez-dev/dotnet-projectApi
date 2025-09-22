using projectApi.Models;
using Microsoft.EntityFrameworkCore;


namespace projectApi.Data;


/*
*   Represents the database context for the application.
*   This class acts as a bridge between domain entities and the database,
*   managing the connection and the model mapping through Entity Framework Core.
*/
public class Context : DbContext
{
    /*
    *   Constructor that initializes a new instance of Context. Receives an instance of
    *   DbContextOptions and configures the connection to the database.
    *   
    *   @param options Options used to configure DbContext
    */
    public Context(DbContextOptions<Context> options) : base(options)
    {


    }


    /*
    *   Represents the Books table in the database.
    */
    public DbSet<Book> Books { get; set; }
    /*
    *   Represents the Authors table in the database.
    */
    public DbSet<Author> Authors { get; set; }
    /*
    *   Represents the Categories table in the database.
    */
    public DbSet<Category> Categories { get; set; }
}
