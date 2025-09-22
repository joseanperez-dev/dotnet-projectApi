using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Dto;


/*
*   Data Transfer Object that represents a simplified version of the Book entity.
*/
public class BookDTO
{
    /*
    *   Book title.
    */
    public string Title { get; set; }
    /*
    *   Book price.
    */
    public double Price { get; set; }
    /*
    *   Book's author identifier.
    */
    public int AuthorId { get; set; }
    /*
    *   Book's category identifier.
    */
    public int CategoryId { get; set; }
}
