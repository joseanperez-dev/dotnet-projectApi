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
*   Repositorio para la gestión de Book.
*   Proporciona las operaciones CRUD básicas utilizando Entity Framework Core.
*/
public class BookRepository : IBookRepository<Book>
{
    /*
    *   Context del repositorio
    */
    private readonly Context context;

    /*
    *   Inicializa una nueva instancia de BookRepository.
    *   
    *   @param context Contexto de base de datos utilizado para las operaciones.
    */
    public BookRepository(Context context)
    {
        this.context = context;
    }

    /*
    *   Agrega una nueva instancia de Book a la base de datos.
    *
    *   @param entity Instancia de Book
    */
    public void Add(Book entity)
    {
        context.Set<Book>().Add(entity);
        context.SaveChanges();
    }

    /*
    *   Elimina un instancia concreta de Book de la base de datos.
    *
    *   @param id Identificador del libro
    */
    public void Delete(int id)
    {
        var book = context.Set<Book>().Find(id);
        if (book != null)
        {
            context.Set<Book>().Remove(book);
            context.SaveChanges();
        }
    }

    /*
    *   Obtiene la lista completa de libroes almacenados en la base de datos.
    *
    *   @returns Enumeración de Book
    */
    public IEnumerable<Book> GetAll()
    {
        return context.Set<Book>().OrderByDescending(c => c.Id).Include(b => b.Author)
                                                             .Include(b => b.Category)
                                                             .ToList();
    }

    /*
    *   Obtiene una instancia concreta de Book almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador del libro
    *   @returns Instancia de Book
    */
    public Book GetById(int id)
    {
        return context.Set<Book>().Include(b => b.Author)
                                  .Include(b => b.Category).FirstOrDefault(b => b.Id == id);
    }

    /*
    *   Obtiene una instancia concreta de Book almacenada en la base de datos por su identificador 
    *   para modificarla.
    *
    *   @param id Identificador del libro
    *   @param intity instancia de Book
    *   @returns Respuesta genérica con el estado de la petición
    */
    public void Update(Book entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}