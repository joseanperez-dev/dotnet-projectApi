using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    public BookRepository bookRepo;
    public CategoryRepository cateRepo;
    public AuthorRepository authRepo;

    public BookController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    [HttpGet]
    [Route("/books")]
    public IEnumerable<Book> getAllBooks()
    {
        return bookRepo.GetAll();
    }

    [HttpGet]
    [Route("/books/{id}")]
    public Book getBook(int id)
    {
        return bookRepo.GetById(id);
    }

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

    [HttpDelete]
    [Route("/books/delete/{id}")]
    public GenericResponseDTO deleteBook(int id)
    {    
        bookRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}