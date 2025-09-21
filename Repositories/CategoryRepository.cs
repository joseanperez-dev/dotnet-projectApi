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
*   Repositorio para la gestión de Category.
*   Proporciona las operaciones CRUD básicas utilizando Entity Framework Core.
*/
public class CategoryRepository : ICategoryRepository<Category>
{
    /*
    *   Context del repositorio
    */
    private readonly Context context;


    /*
    *   Inicializa una nueva instancia de CategoryRepository.
    *   
    *   @param context Contexto de base de datos utilizado para las operaciones.
    */
    public CategoryRepository(Context context)
    {
        this.context = context;
    }


    /*
    *   Agrega una nueva instancia de Category a la base de datos.
    *
    *   @param entity Instancia de Category
    */
    public void Add(Category entity)
    {
        context.Set<Category>().Add(entity);
        context.SaveChanges();
    }


    /*
    *   Elimina una instancia concreta de Category de la base de datos.
    *
    *   @param id Identificador de la categoría
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
    *   Obtiene la lista completa de categorías almacenadas en la base de datos.
    *
    *   @returns Enumeración de Category
    */
    public IEnumerable<Category> GetAll()
    {
        return context.Set<Category>().OrderByDescending(c => c.Id).ToArray();
    }


    /*
    *   Obtiene una instancia concreta de Category almacenada en la base de datos por su identificador.
    *
    *   @param id Identificador de la categoría
    *   @returns Instancia de Category
    */
    public Category GetById(int id)
    {
        return context.Set<Category>().Find(id);
    }


    /*
    *   Actualiza la información de una instancia existente de Category en la base de datos.
    *
    *   @param entity Instancia de Category con los datos actualizados
    */
    public void Update(Category entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
