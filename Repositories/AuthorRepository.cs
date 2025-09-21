using projectApi.Data;
using projectApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projectApi.Repositories;

/*
*   Repositorio para la gestión de Author.
*   Proporciona las operaciones CRUD básicas utilizando Entity Framework Core.
*/
public class AuthorRepository : IAuthorRepository<Author>
{
    /*
    *   Context del repositorio
    */
    private readonly Context context;

    /*
    *   Inicializa una nueva instancia de AuthorRepository.
    *   
    *   @param context Contexto de base de datos utilizado para las operaciones.
    */
    public AuthorRepository(Context context)
    {
        this.context = context;
    }

    /*
    *   Agrega una nueva instancia de Author a la base de datos.
    *
    *   @param entity Instancia de Author
    */
    public void Add(Author entity)
    {
        context.Set<Author>().Add(entity);
        context.SaveChanges();
    }

    /*
    *   Elimina un instancia concreta de Author de la base de datos.
    *
    *   @param id Identificador del autor
    */
    public void Delete(int id)
    {
        var author = context.Set<Author>().Find(id);
        if (author != null)
        {
            context.Set<Author>().Remove(author);
            context.SaveChanges();
        }
    }

    /*
    *   Obtiene la lista completa de autores almacenados en la base de datos.
    *
    *   @returns Enumeración de Author
    */
    public IEnumerable<Author> GetAll()
    {
        return context.Set<Author>().OrderByDescending(c => c.Id).ToArray();
    }

    /*
    *   Obtiene una instancia concreta de Author almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador del autor
    *   @returns Instancia de Author
    */
    public Author GetById(int id)
    {
        return context.Set<Author>().Find(id);
    }

    /*
    *   Obtiene una instancia concreta de Author almacenada en la base de datos por su identificador 
    *   para modificarla.
    *
    *   @param id Identificador del autor
    *   @param intity instancia de Author
    *   @returns Respuesta genérica con el estado de la petición
    */
    public void Update(Author entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}