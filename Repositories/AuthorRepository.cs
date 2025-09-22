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
*   Repository for managing Author.
*   Provides basic CRUD operations using Entity Framework Core.
*/
public class AuthorRepository : IAuthorRepository<Author>
{
    /*
    *   Repository context.
    */
    private readonly Context context;


    /*
    *   Initializes a new instance of AuthorRepository.
    *   
    *   @param context Database context used for operations.
    */
    public AuthorRepository(Context context)
    {
        this.context = context;
    }


    /*
    *   Adds a new Author instance to the database.
    *
    *   @param entity Author instance
    */
    public void Add(Author entity)
    {
        context.Set<Author>().Add(entity);
        context.SaveChanges();
    }


    /*
    *   Deletes a specific Author instance from the database.
    *
    *   @param id Author identifier
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
    *   Retrieves the complete list of authors stored in the database.
    *
    *   @returns Enumeration of Author
    */
    public IEnumerable<Author> GetAll()
    {
        return context.Set<Author>().OrderByDescending(c => c.Id).ToArray();
    }


    /*
    *   Retrieves a specific Author instance stored in the database by its identifier.
    *
    *   @param id Author identifier
    *   @returns Author instance
    */
    public Author GetById(int id)
    {
        return context.Set<Author>().Find(id);
    }


    /*
    *   Updates a specific Author instance in the database.
    *
    *   @param entity Author instance
    */
    public void Update(Author entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
