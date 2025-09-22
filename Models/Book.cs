using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Models;


/*
*   This model represents the Books entity in the database.
*/
public class Book
{
    /*
    *   Unique identifier.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Book title.
    */
    public string? Title { get; set; }
    /*
    *   Book price.
    */
    public double? Price { get; set; }
    /*
    *   Book's author identifier.
    */
    public int AuthorId { get; set; }
    /*
    *   Book's author.
    */
    public Author Author { get; set; }
    /*
    *   Book's category identifier.
    */
    public int CategoryId { get; set; }
    /*
    *   Book's category.
    */
    public Category Category { get; set; }
}
