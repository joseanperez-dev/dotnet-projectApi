using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace projectApi.Dto;


/*
*   Data Transfer Object that represents a simplified version of the Category entity.
*/
public class CategoryDTO
{
    /*
    *   Category name.
    */
    public string Name { get; set; }
}
