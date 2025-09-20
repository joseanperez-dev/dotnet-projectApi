using projectApi.Data;
using projectApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projectApi.Repositories;

public class BookRepository : IBookRepository<Book>
{
    private readonly Context context;

    public BookRepository(Context context)
    {
        this.context = context;
    }

    public void Add(Book entity)
    {
        context.Set<Book>().Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var author = context.Set<Book>().Find(id);
        if (author != null)
        {
            context.Set<Book>().Remove(author);
            context.SaveChanges();
        }
    }

    public IEnumerable<Book> GetAll()
    {
        return context.Set<Book>().OrderByDescending(c=>c.Id).Include(b => b.Author)
                                                             .Include(b => b.Category)
                                                             .ToList();
    }

    public Book GetById(int id)
    {
        return context.Set<Book>().Include(b => b.Author)
                                  .Include(b => b.Category).FirstOrDefault(b => b.Id == id);
    }

    public void Update(Book entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}