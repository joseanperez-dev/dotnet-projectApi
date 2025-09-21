using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace projectApi.Repositories;


/*
*   Interfaz genérica para la gestión de Author.
*   Define las operaciones CRUD básicas que deben implementarse en el repositorio correspondiente.
*
*   @typeparam T Tipo de entidad (en este caso, Author).
*/
public interface IAuthorRepository<T>
{
    /*
    *   Obtiene una instancia concreta de Author por su identificador.
    *
    *   @param id Identificador del autor.
    *   @returns Instancia de Author.
    */
    T GetById(int id);


    /*
    *   Obtiene la lista completa de autores almacenados en la base de datos.
    *
    *   @returns Enumeración de Author.
    */
    IEnumerable<T> GetAll();


    /*
    *   Agrega una nueva instancia de Author a la base de datos.
    *
    *   @param entity Instancia de Author.
    */
    void Add(T entity);


    /*
    *   Actualiza la información de una instancia existente de Author en la base de datos.
    *
    *   @param entity Instancia de Author con los datos actualizados.
    */
    void Update(T entity);


    /*
    *   Elimina una instancia concreta de Author de la base de datos.
    *
    *   @param id Identificador del autor.
    */
    void Delete(int id);
}
