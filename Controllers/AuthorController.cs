using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

/*
*   Este controlador maneja las operaciones relacionadas con la entidad Author.
*   Interactúa con el contexto de la base de datos.
*/
[ApiController]
[Route("[controller]")]
public class AuthorController : Controller
{
    /*
    *   Repositorio para la entidad Book.
    */
    public BookRepository bookRepo;
    /*
    *   Repositorio para la entidad Category.
    */
    public CategoryRepository cateRepo;
    /*
    *   Repositorio para la entidad Author.
    */
    public AuthorRepository authRepo;

    /*
    *   Constructor que inicializa una nueva instancia de AuthorController. Recibe una instancia de 
    *   Context e inicializa una instancia de los repositorios de Book, Category y Author.
    *
    *   @param context Instancia de Context utilizada para acceder a la base de datos
    */
    public AuthorController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    /*
    *   Método que obtiene la lista completa de autores almacenados en la base de datos.
    *
    *   @returns Enumeración de Author
    */
    [HttpGet]
    [Route("/authors")]
    public IEnumerable<Author> getAllAuthors()
    {
        return authRepo.GetAll();
    }

    /*
    *   Método que obtiene una instancia concreta de Author almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador del autor
    *   @returns Instancia de Author
    */
    [HttpGet]
    [Route("/authors/{id}")]
    public Author getAuthor(int id)
    {
        return authRepo.GetById(id);
    }

    /*
    *   Método que crea una instancia de Author y la almacena en la base de datos.
    *
    *   @param authorDto Objeto de transferencia de datos para crear la instancia de Author
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpPost]
    [Route("/authors")]
    public GenericResponseDTO addAuthor(AuthorDTO authorDto)
    {
        Author author = new Author();
        author.Name = authorDto.Name;
        authRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Se ha creado correctamente: {authorDto.Name}"};
    }

    /*
    *   Método que obtiene una instancia concreta de Author almacenada en la base de datos por su identificador 
    *   para modificarla.
    *
    *   @param id Identificador del autor
    *   @param authorDto Objeto de transferencia de datos para modificar la instancia de Author
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpPut]
    [Route("/authors/{id}")]
    public GenericResponseDTO editAuthor(int id, AuthorDTO authorDto)
    {
        Author author = authRepo.GetById(id);
        string nombreDesactualizado = author.Name;
        author.Name = authorDto.Name;
        authRepo.Update(author);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Se ha Actualizado correctamente: {nombreDesactualizado} -> {authorDto.Name}"};
    }
    
    /*
    *   Método que obtiene una instancia concreta de Author almacenada en la base de datos por su identificador 
    *   para eliminarla.
    *
    *   @param id Identificador del autor
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpDelete]
    [Route("/authors/delete/{id}")]
    public GenericResponseDTO deleteAuthor(int id)
    {    
        authRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}