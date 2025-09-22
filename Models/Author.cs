using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Models;


/*
*   This model represents the Authors entity in the database.
*/
public class Author
{
    /*
    *   Unique identifier.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Author's name.
    */
    public string Name { get; set; }
}
