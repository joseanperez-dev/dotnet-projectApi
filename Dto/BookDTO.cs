using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

/*
*   Objeto de transferencia de datos que representa de forma simplicada la entidad Book.
*/
public class BookDTO
{
    /*
    *   Título del libro.
    */
    public string Title { get; set; }
    /*
    *   Precio del libro.
    */
    public double Price { get; set; }
    /*
    *   Identificador del autor del libro.
    */
    public int AuthorId { get; set; }
    /*
    *   Identificador de la categoría del libro.
    */
    public int CategoryId { get; set; }
}
