using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

/*
*   Objeto de transferencia de datos que representa de forma simplicada la entidad Category.
*/
public class CategoryDTO
{
    /*
    *   Nombre de la categoría.
    */
    public string Name { get; set; }
}
