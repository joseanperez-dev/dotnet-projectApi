using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace projectApi.Repositories;


/*
*   Interfaz genérica para la gestión de Book.
*   Define las operaciones CRUD básicas que deben implementarse en el repositorio correspondiente.
*
*   @typeparam T Tipo de entidad (en este caso, Book).
*/
public interface IBookRepository<T>
{
    /*
    *   Obtiene una instancia concreta de Book por su identificador.
    *
    *   @param id Identificador del libro.
    *   @returns Instancia de Book.
    */
    T GetById(int id);

    /*
    *   Obtiene la lista completa de libros almacenados en la base de datos.
    *
    *   @returns Enumeración de Book.
    */
    IEnumerable<T> GetAll();

    /*
    *   Agrega una nueva instancia de Book a la base de datos.
    *
    *   @param entity Instancia de Book.
    */
    void Add(T entity);

    /*
    *   Actualiza la información de una instancia existente de Book en la base de datos.
    *
    *   @param entity Instancia de Book con los datos actualizados.
    */
    void Update(T entity);

    /*
    *   Elimina una instancia concreta de Book de la base de datos.
    *
    *   @param id Identificador del libro.
    */
    void Delete(int id);
}
