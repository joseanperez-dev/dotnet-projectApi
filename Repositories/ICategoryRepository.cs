using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace projectApi.Repositories;


/*
*   Interfaz genérica para la gestión de Category.
*   Define las operaciones CRUD básicas que deben implementarse en el repositorio correspondiente.
*
*   @typeparam T Tipo de entidad (en este caso, Category).
*/
public interface ICategoryRepository<T>
{
    /*
    *   Obtiene una instancia concreta de Category por su identificador.
    *
    *   @param id Identificador de la categoría.
    *   @returns Instancia de Category.
    */
    T GetById(int id);

    /*
    *   Obtiene la lista completa de categorías almacenadas en la base de datos.
    *
    *   @returns Enumeración de Category.
    */
    IEnumerable<T> GetAll();

    /*
    *   Agrega una nueva instancia de Category a la base de datos.
    *
    *   @param entity Instancia de Category.
    */
    void Add(T entity);

    /*
    *   Actualiza la información de una instancia existente de Category en la base de datos.
    *
    *   @param entity Instancia de Category con los datos actualizados.
    */
    void Update(T entity);

    /*
    *   Elimina una instancia concreta de Category de la base de datos.
    *
    *   @param id Identificador de la categoría.
    */
    void Delete(int id);
}
