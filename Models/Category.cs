using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Models;


/*
*   This model represents the Categories entity in the database.
*/
public class Category
{
    /*
    *   Unique identifier.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Category name.
    */
    public string Name { get; set; }
}
