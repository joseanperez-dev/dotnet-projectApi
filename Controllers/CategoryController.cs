using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    public BookRepository bookRepo;
    public CategoryRepository cateRepo;
    public AuthorRepository authRepo;

    public CategoryController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    [HttpGet]
    [Route("/categories")]
    public IEnumerable<Category> getAllCategorys()
    {
        return cateRepo.GetAll();
    }

    [HttpGet]
    [Route("/categories/{id}")]
    public Category getCategory(int id)
    {
        return cateRepo.GetById(id);
    }

    [HttpPost]
    [Route("/categories")]
    public GenericResponseDTO addCategory(CategoryDTO authorDto)
    {
        Category author = new Category();
        author.Name = authorDto.Name;
        cateRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Se ha creado correctamente: {authorDto.Name}"};
    }

    [HttpPut]
    [Route("/categories/{id}")]
    public GenericResponseDTO editCategory(int id, CategoryDTO authorDto)
    {
        Category author = cateRepo.GetById(id);
        string nombreDesactualizado = author.Name;
        author.Name = authorDto.Name;
        cateRepo.Update(author);
        return new GenericResponseDTO{Status="200 | OK", Name=$"Se ha Actualizado correctamente: {nombreDesactualizado} -> {authorDto.Name}"};
    }

    [HttpDelete]
    [Route("/categories/delete/{id}")]
    public GenericResponseDTO deleteCategory(int id)
    {    
        cateRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}