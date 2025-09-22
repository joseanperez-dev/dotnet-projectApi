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
*   Repository for managing Book.
*   Provides basic CRUD operations using Entity Framework Core.
*/
public class BookRepository : IBookRepository<Book>
{
    /*
    *   Repository context.
    */
    private readonly Context context;


    /*
    *   Initializes a new instance of BookRepository.
    *   
    *   @param context Database context used for operations.
    */
    public BookRepository(Context context)
    {
        this.context = context;
    }


    /*
    *   Adds a new Book instance to the database.
    *
    *   @param entity Book instance
    */
    public void Add(Book entity)
    {
        context.Set<Book>().Add(entity);
        context.SaveChanges();
    }


    /*
    *   Deletes a specific Book instance from the database.
    *
    *   @param id Book identifier
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
    *   Retrieves the complete list of books stored in the database.
    *
    *   @returns Enumeration of Book
    */
    public IEnumerable<Book> GetAll()
    {
        return context.Set<Book>().OrderByDescending(c => c.Id).Include(b => b.Author)
                                                             .Include(b => b.Category)
                                                             .ToList();
    }


    /*
    *   Retrieves a specific Book instance stored in the database by its identifier.
    *
    *   @param id Book identifier
    *   @returns Book instance
    */
    public Book GetById(int id)
    {
        return context.Set<Book>().Include(b => b.Author)
                                  .Include(b => b.Category).FirstOrDefault(b => b.Id == id);
    }


    /*
    *   Updates a specific Book instance in the database.
    *
    *   @param entity Book instance
    */
    public void Update(Book entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
