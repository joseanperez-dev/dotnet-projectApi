using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : Controller
{
    public BookRepository bookRepo;
    public CategoryRepository cateRepo;
    public AuthorRepository authRepo;

    public AuthorController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    [HttpGet]
    [Route("/authors")]
    public IEnumerable<Author> getAllAuthors()
    {
        return authRepo.GetAll();
    }

    [HttpGet]
    [Route("/authors/{id}")]
    public Author getAuthor(int id)
    {
        return authRepo.GetById(id);
    }

    [HttpPost]
    [Route("/authors")]
    public GenericResponseDTO addAuthor(AuthorDTO authorDto)
    {
        Author author = new Author();
        author.Name = authorDto.Name;
        authRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Se ha creado correctamente: {authorDto.Name}"};
    }

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

    [HttpDelete]
    [Route("/authors/delete/{id}")]
    public GenericResponseDTO deleteAuthor(int id)
    {    
        authRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}