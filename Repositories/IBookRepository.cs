using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace projectApi.Repositories;



/*
*   Generic interface for managing Book.
*   Defines the basic CRUD operations that must be implemented in the corresponding repository.
*
*   @typeparam T Entity type (in this case, Book).
*/
public interface IBookRepository<T>
{
    /*
    *   Retrieves a specific Book instance by its identifier.
    *
    *   @param id Book identifier.
    *   @returns Book instance.
    */
    T GetById(int id);


    /*
    *   Retrieves the complete list of Books stored in the database.
    *
    *   @returns Enumeration of Book.
    */
    IEnumerable<T> GetAll();


    /*
    *   Adds a new Book instance to the database.
    *
    *   @param entity Book instance.
    */
    void Add(T entity);


    /*
    *   Updates an existing Book instance in the database.
    *
    *   @param entity Book instance with updated data.
    */
    void Update(T entity);


    /*
    *   Deletes a specific Book instance from the database.
    *
    *   @param id Book identifier.
    */
    void Delete(int id);
}
