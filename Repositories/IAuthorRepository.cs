using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace projectApi.Repositories;



/*
*   Generic interface for managing Author.
*   Defines the basic CRUD operations that must be implemented in the corresponding repository.
*
*   @typeparam T Entity type (in this case, Author).
*/
public interface IAuthorRepository<T>
{
    /*
    *   Retrieves a specific Author instance by its identifier.
    *
    *   @param id Author identifier.
    *   @returns Author instance.
    */
    T GetById(int id);



    /*
    *   Retrieves the complete list of Authors stored in the database.
    *
    *   @returns Enumeration of Author.
    */
    IEnumerable<T> GetAll();



    /*
    *   Adds a new Author instance to the database.
    *
    *   @param entity Author instance.
    */
    void Add(T entity);



    /*
    *   Updates an existing Author instance in the database.
    *
    *   @param entity Author instance with updated data.
    */
    void Update(T entity);



    /*
    *   Deletes a specific Author instance from the database.
    *
    *   @param id Author identifier.
    */
    void Delete(int id);
}
