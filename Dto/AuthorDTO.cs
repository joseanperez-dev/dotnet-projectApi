using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

/*
*   Objeto de transferencia de datos que representa de forma simplicada la entidad Author.
*/
public class AuthorDTO
{
    /*
    *   Nombre del autor.
    */
    public string Name { get; set; }
}
