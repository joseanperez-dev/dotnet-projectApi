using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

public class BookDTO
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}
