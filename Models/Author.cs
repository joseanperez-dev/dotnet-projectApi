using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Models;

/*
*   Este modelo representa a la entidad Authors en la base de datos.
*/
public class Author
{
    /*
    *   Indentificador único.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Nombre del autor.
    */
    public string Name { get; set; }
}