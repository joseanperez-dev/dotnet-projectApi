using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;


namespace projectApi.Controllers;


/*
*   This controller handles operations related to the Author entity.
*   It interacts with the database context.
*/
[ApiController]
[Route("[controller]")]
public class AuthorController : Controller
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
    *   Constructor that initializes a new instance of AuthorController. 
    *   It receives a Context instance and initializes the repositories for Book, Category, and Author.
    *
    *   @param context Context instance used to access the database
    */
    public AuthorController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }


    /*
    *   Method that retrieves the complete list of authors stored in the database.
    *
    *   @returns Enumeration of Author
    */
    [HttpGet]
    [Route("/authors")]
    public IEnumerable<Author> getAllAuthors()
    {
        return authRepo.GetAll();
    }


    /*
    *   Method that retrieves a specific Author instance stored in the database by its identifier.
    *
    *   @param id Author identifier
    *   @returns Author instance
    */
    [HttpGet]
    [Route("/authors/{id}")]
    public Author getAuthor(int id)
    {
        return authRepo.GetById(id);
    }


    /*
    *   Method that creates an Author instance and stores it in the database.
    *
    *   @param authorDto Data transfer object used to create the Author instance
    *   @returns Generic response with the request status
    */
    [HttpPost]
    [Route("/authors")]
    public GenericResponseDTO addAuthor(AuthorDTO authorDto)
    {
        Author author = new Author();
        author.Name = authorDto.Name;
        authRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Successfully created: {authorDto.Name}"};
    }


    /*
    *   Method that retrieves a specific Author instance stored in the database by its identifier
    *   in order to update it.
    *
    *   @param id Author identifier
    *   @param authorDto Data transfer object used to update the Author instance
    *   @returns Generic response with the request status
    */
    [HttpPut]
    [Route("/authors/{id}")]
    public GenericResponseDTO editAuthor(int id, AuthorDTO authorDto)
    {
        Author author = authRepo.GetById(id);
        string oldName = author.Name;
        author.Name = authorDto.Name;
        authRepo.Update(author);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Successfully updated: {oldName} -> {authorDto.Name}"};
    }
    
    /*
    *   Method that retrieves a specific Author instance stored in the database by its identifier
    *   in order to delete it.
    *
    *   @param id Author identifier
    *   @returns Generic response with the request status
    */
    [HttpDelete]
    [Route("/authors/delete/{id}")]
    public GenericResponseDTO deleteAuthor(int id)
    {    
        authRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Successfully deleted" };
    }
}
