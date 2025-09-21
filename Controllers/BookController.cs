using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

/*
*   Este controlador maneja las operaciones relacionadas con la entidad Book.
*   Interactúa con el contexto de la base de datos.
*/
[ApiController]
[Route("[controller]")]
public class BookController : Controller
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
    *   Constructor que inicializa una nueva instancia de BookController. Recibe una instancia de 
    *   Context e inicializa una instancia de los repositorios de Book, Category y Author.
    *
    *   @param context Instancia de Context utilizada para acceder a la base de datos
    */
    public BookController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    /*
    *   Método que obtiene la lista completa de libros almacenados en la base de datos.
    *
    *   @returns Enumeración de Book
    */
    [HttpGet]
    [Route("/books")]
    public IEnumerable<Book> getAllBooks()
    {
        return bookRepo.GetAll();
    }

    /*
    *   Método que obtiene una instancia concreta de Book almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador del libro
    *   @returns Instancia de Book
    */
    [HttpGet]
    [Route("/books/{id}")]
    public Book getBook(int id)
    {
        return bookRepo.GetById(id);
    }
    
    /*
    *   Método que crea una instancia de Book y la almacena en la base de datos.
    *
    *   @param bookDto Objeto de transferencia de datos para crear la instancia de Book
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpPost]
    [Route("/books")]
    public GenericResponseDTO addBook(BookDTO bookDto)
    {
        Book book = new Book();
        book.Title = bookDto.Title;
        book.Price = bookDto.Price;
        book.AuthorId = bookDto.AuthorId;
        book.CategoryId = bookDto.CategoryId;
        bookRepo.Add(book);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Se ha creado correctamente: {bookDto.Title}"};
    }

    /*
    *   Método que obtiene una instancia concreta de Book almacenada en la base de datos por su identificador 
    *   para modificarla.
    *
    *   @param id Identificador del libro
    *   @param bookDto Objeto de transferencia de datos para modificar la instancia de Book
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpPut]
    [Route("/books/{id}")]
    public GenericResponseDTO editBook(int id, BookDTO bookDto)
    {
        Book book = bookRepo.GetById(id);
        string nombreDesactualizado = book.Title;
        book.Title = bookDto.Title;
        book.Price = bookDto.Price;
        book.AuthorId = bookDto.AuthorId;
        book.CategoryId = bookDto.CategoryId;
        bookRepo.Update(book);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Se ha Actualizado correctamente: {nombreDesactualizado} -> {bookDto.Title}"};
    }

    /*
    *   Método que obtiene una instancia concreta de Book almacenada en la base de datos por su identificador 
    *   para eliminarla.
    *
    *   @param id Identificador del libro
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpDelete]
    [Route("/books/delete/{id}")]
    public GenericResponseDTO deleteBook(int id)
    {    
        bookRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}