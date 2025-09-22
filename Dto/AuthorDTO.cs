using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Dto;


/*
*   Data Transfer Object that represents a simplified version of the Author entity.
*/
public class AuthorDTO
{
    /*
    *   Author's name.
    */
    public string Name { get; set; }
}
