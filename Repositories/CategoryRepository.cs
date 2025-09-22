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
*   Repository for managing Category.
*   Provides basic CRUD operations using Entity Framework Core.
*/
public class CategoryRepository : ICategoryRepository<Category>
{
    /*
    *   Repository context.
    */
    private readonly Context context;



    /*
    *   Initializes a new instance of CategoryRepository.
    *   
    *   @param context Database context used for operations.
    */
    public CategoryRepository(Context context)
    {
        this.context = context;
    }



    /*
    *   Adds a new Category instance to the database.
    *
    *   @param entity Category instance
    */
    public void Add(Category entity)
    {
        context.Set<Category>().Add(entity);
        context.SaveChanges();
    }



    /*
    *   Deletes a specific Category instance from the database.
    *
    *   @param id Category identifier
    */
    public void Delete(int id)
    {
        var category = context.Set<Category>().Find(id);
        if (category != null)
        {
            context.Set<Category>().Remove(category);
            context.SaveChanges();
        }
    }



    /*
    *   Retrieves the complete list of categories stored in the database.
    *
    *   @returns Enumeration of Category
    */
    public IEnumerable<Category> GetAll()
    {
        return context.Set<Category>().OrderByDescending(c => c.Id).ToArray();
    }



    /*
    *   Retrieves a specific Category instance stored in the database by its identifier.
    *
    *   @param id Category identifier
    *   @returns Category instance
    */
    public Category GetById(int id)
    {
        return context.Set<Category>().Find(id);
    }



    /*
    *   Updates an existing Category instance in the database.
    *
    *   @param entity Category instance with updated data
    */
    public void Update(Category entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
