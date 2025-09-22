using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace projectApi.Repositories;



/*
*   Generic interface for managing Category.
*   Defines the basic CRUD operations that must be implemented in the corresponding repository.
*
*   @typeparam T Entity type (in this case, Category).
*/
public interface ICategoryRepository<T>
{
    /*
    *   Retrieves a specific Category instance by its identifier.
    *
    *   @param id Category identifier.
    *   @returns Category instance.
    */
    T GetById(int id);


    /*
    *   Retrieves the complete list of Categories stored in the database.
    *
    *   @returns Enumeration of Category.
    */
    IEnumerable<T> GetAll();


    /*
    *   Adds a new Category instance to the database.
    *
    *   @param entity Category instance.
    */
    void Add(T entity);


    /*
    *   Updates an existing Category instance in the database.
    *
    *   @param entity Category instance with updated data.
    */
    void Update(T entity);


    /*
    *   Deletes a specific Category instance from the database.
    *
    *   @param id Category identifier.
    */
    void Delete(int id);
}
