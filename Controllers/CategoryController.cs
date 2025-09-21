using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using projectApi.Data;
using projectApi.Dto;
using projectApi.Models;
using projectApi.Repositories;

namespace projectApi.Controllers;

/*
*   Este controlador maneja las operaciones relacionadas con la entidad Category.
*   Interactúa con el contexto de la base de datos.
*/
[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
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
    *   Constructor que inicializa una nueva instancia de CategoryController. Recibe una instancia de 
    *   Context e inicializa una instancia de los repositorios de Book, Category y Author.
    *
    *   @param context Instancia de Context utilizada para acceder a la base de datos
    */
    public CategoryController(Context context)
    {
        this.bookRepo = new BookRepository(context);
        this.cateRepo = new CategoryRepository(context);
        this.authRepo = new AuthorRepository(context);
    }

    /*
    *   Método que obtiene la lista completa de categorías almacenadas en la base de datos.
    *
    *   @returns Enumeración de Category
    */
    [HttpGet]
    [Route("/categories")]
    public IEnumerable<Category> getAllCategorys()
    {
        return cateRepo.GetAll();
    }

    /*
    *   Método que obtiene una instancia concreta de Category almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador de la categoría
    *   @returns Instancia de Category
    */
    [HttpGet]
    [Route("/categories/{id}")]
    public Category getCategory(int id)
    {
        return cateRepo.GetById(id);
    }

    /*
    *   Método que crea una instancia de Category y la almacena en la base de datos.
    *
    *   @param categoryDto Objeto de transferencia de datos para crear la instancia de Category
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpPost]
    [Route("/categories")]
    public GenericResponseDTO addCategory(CategoryDTO authorDto)
    {
        Category author = new Category();
        author.Name = authorDto.Name;
        cateRepo.Add(author);
        return new GenericResponseDTO{Status="201 | CREATED", Name=$"Se ha creado correctamente: {authorDto.Name}"};
    }

    /*
    *   Método que obtiene una instancia concreta de Category almacenada en la base de datos por su identificador 
    *   para modificarla.
    *
    *   @param id Identificador de la categoría
    *   @param categoryDto Objeto de transferencia de datos para modificar la instancia de Category
    *   @returns Respuesta genérica con el estado de la petición
    */
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

    /*
    *   Método que obtiene una instancia concreta de Category almacenada en la base de datos por su identificador 
    *   para eliminarla.
    *
    *   @param id Identificador del categoría
    *   @returns Respuesta genérica con el estado de la petición
    */
    [HttpDelete]
    [Route("/categories/delete/{id}")]
    public GenericResponseDTO deleteCategory(int id)
    {    
        cateRepo.Delete(id);
        return new GenericResponseDTO { Status = "200 | OK", Name = $"Se ha Borrado correctamente" };
    }
}