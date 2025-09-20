using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public double? Price { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    
}