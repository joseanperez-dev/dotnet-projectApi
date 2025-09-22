using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;


namespace projectApi.Controllers;


/*
*   This controller handles operations related to the Category entity.
*   It interacts with the database context.
*/
[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
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
    *   Constructor that initializes a new instance of CategoryController. 
    *   It receives a Context instance and initializes the repositories 
    *   for Book, Category, and Author.
    *
    *   @param context Context instance used to access the database
    */
    public CategoryController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }


    /*
    *   Method that retrieves the complete list of categories stored in the database.
    *
    *   @returns Enumeration of Category
    */
    [HttpGet]
    [Route("/categories")]
    public IEnumerable<Category> getAllCategorys()
    {
        return cateRepo.GetAll();
    }


    /*
    *   Method that retrieves a specific Category instance stored in the database by its identifier.
    *
    *   @param id Category identifier
    *   @returns Category instance
    */
    [HttpGet]
    [Route("/categories/{id}")]
    public Category getCategory(int id)
    {
        return cateRepo.GetById(id);
    }


    /*
    *   Method that creates a Category instance and stores it in the database.
    *
    *   @param categoryDto Data transfer object used to create the Category instance
    *   @returns Generic response with the request status
    */
    [HttpPost]
    [Route("/categories")]
    public GenericResponseDTO addCategory(CategoryDTO authorDto)
    {
        Category author = new Category();
        author.Name = authorDto.Name;
        cateRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Successfully created: {authorDto.Name}"};
    }


    /*
    *   Method that retrieves a specific Category instance stored in the database by its identifier 
    *   in order to update it.
    *
    *   @param id Category identifier
    *   @param categoryDto Data transfer object used to update the Category instance
    *   @returns Generic response with the request status
    */
    [HttpPut]
    [Route("/categories/{id}")]
    public GenericResponseDTO editCategory(int id, CategoryDTO authorDto)
    {
        Category author = cateRepo.GetById(id);
        string oldName = author.Name;
        author.Name = authorDto.Name;
        cateRepo.Update(author);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Successfully updated: {oldName} -> {authorDto.Name}"};
    }


    /*
    *   Method that retrieves a specific Category instance stored in the database by its identifier 
    *   in order to delete it.
    *
    *   @param id Category identifier
    *   @returns Generic response with the request status
    */
    [HttpDelete]
    [Route("/categories/delete/{id}")]
    public GenericResponseDTO deleteCategory(int id)
    {    
        cateRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Successfully deleted" };
    }
}
