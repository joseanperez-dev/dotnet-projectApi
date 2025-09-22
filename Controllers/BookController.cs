using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;


namespace projectApi.Controllers;


/*
*   This controller handles operations related to the Book entity.
*   It interacts with the database context.
*/
[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    /*
    *   Repository for the Book entity.
    */
    public BookRepository bookRepo;
    /*
    *   Repository for the Category entity.
    */
    public CategoryRepository cateRepo;
    /*
    *   Repository for the Author entity.
    */
    public AuthorRepository authRepo;


    /*
    *   Constructor that initializes a new instance of BookController. 
    *   It receives a Context instance and initializes the repositories 
    *   for Book, Category, and Author.
    *
    *   @param context Context instance used to access the database
    */
    public BookController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }


    /*
    *   Method that retrieves the complete list of books stored in the database.
    *
    *   @returns Enumeration of Book
    */
    [HttpGet]
    [Route("/books")]
    public IEnumerable<Book> getAllBooks()
    {
        return bookRepo.GetAll();
    }


    /*
    *   Method that retrieves a specific Book instance stored in the database by its identifier.
    *
    *   @param id Book identifier
    *   @returns Book instance
    */
    [HttpGet]
    [Route("/books/{id}")]
    public Book getBook(int id)
    {
        return bookRepo.GetById(id);
    }
    
    /*
    *   Method that creates a Book instance and stores it in the database.
    *
    *   @param bookDto Data transfer object used to create the Book instance
    *   @returns Generic response with the request status
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
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Successfully created: {bookDto.Title}"};
    }


    /*
    *   Method that retrieves a specific Book instance stored in the database by its identifier 
    *   in order to update it.
    *
    *   @param id Book identifier
    *   @param bookDto Data transfer object used to update the Book instance
    *   @returns Generic response with the request status
    */
    [HttpPut]
    [Route("/books/{id}")]
    public GenericResponseDTO editBook(int id, BookDTO bookDto)
    {
        Book book = bookRepo.GetById(id);
        string oldTitle = book.Title;
        book.Title = bookDto.Title;
        book.Price = bookDto.Price;
        book.AuthorId = bookDto.AuthorId;
        book.CategoryId = bookDto.CategoryId;
        bookRepo.Update(book);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Successfully updated: {oldTitle} -> {bookDto.Title}"};
    }


    /*
    *   Method that retrieves a specific Book instance stored in the database by its identifier 
    *   in order to delete it.
    *
    *   @param id Book identifier
    *   @returns Generic response with the request status
    */
    [HttpDelete]
    [Route("/books/delete/{id}")]
    public GenericResponseDTO deleteBook(int id)
    {    
        bookRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Successfully deleted" };
    }
}
