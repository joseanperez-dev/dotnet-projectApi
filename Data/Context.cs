using projectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace projectApi.Data;

/*
*   Representa el contexto de base de datos para la aplicación.
*   Esta clase actúa como puente entre las entidades de dominio y la base de datos, 
*   gestionando la conexión y el mapeo de modelos mediante Entity Framework Core.
*/
public class Context : DbContext
{
    /*
    *   Constructor que inicializa una nueva instancia de Context. Recibe una instancia de 
    *   DbContextOptions y configura la conexión a la base de datos.
    *   
    *   @param options Opciones utilizadas para configurar DbContext
    */
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    /*
    *   Representa la tabla Books en la base de datos.
    */
    public DbSet<Book> Books { get; set; }
    /*
    *   Representa la tabla Authors en la base de datos.
    */
    public DbSet<Author> Authors { get; set; }
    /*
    *   Representa la tabla Categories en la base de datos.
    */
    public DbSet<Category> Categories { get; set; }
}