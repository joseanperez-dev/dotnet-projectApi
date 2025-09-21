using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Models;

/*
*   Este modelo representa a la entidad Books en la base de datos.
*/
public class Book
{
    /*
    *   Indentificador único.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Título del libro.
    */
    public string? Title { get; set; }
    /*
    *   Precio del libro.
    */
    public double? Price { get; set; }
    /*
    *   Identificador del autor del libro.
    */
    public int AuthorId { get; set; }
    /*
    *   Autor del libro.
    */
    public Author Author { get; set; }
    /*
    *   Identificador de la categoría del libro.
    */
    public int CategoryId { get; set; }
    /*
    *   Categoría del libro.
    */
    public Category Category { get; set; }

    
}