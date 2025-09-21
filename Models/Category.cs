using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Models;

/*
*   Este modelo representa a la entidad Categories en la base de datos.
*/
public class Category
{
    /*
    *   Indentificador único.
    */
    [Key]
    public int Id { get; set; }
    /*
    *   Nombre de la categoría.
    */
    public string Name { get; set; }
}