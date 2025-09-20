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

public class AuthorRepository : IAuthorRepository<Author>
{
    private readonly Context context;

    public AuthorRepository(Context context)
    {
        this.context = context;
    }

    public void Add(Author entity)
    {
        context.Set<Author>().Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var author = context.Set<Author>().Find(id);
        if (author != null)
        {
            context.Set<Author>().Remove(author);
            context.SaveChanges();
        }
    }

    public IEnumerable<Author> GetAll()
    {
        return context.Set<Author>().OrderByDescending(c=>c.Id).ToArray();
    }

    public Author GetById(int id)
    {
        return context.Set<Author>().Find(id);
    }

    public void Update(Author entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}