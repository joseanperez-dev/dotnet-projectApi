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

public class CategoryRepository : ICategoryRepository<Category>
{
    private readonly Context context;

    public CategoryRepository(Context context)
    {
        this.context = context;
    }

    public void Add(Category entity)
    {
        context.Set<Category>().Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var category = context.Set<Category>().Find(id);
        if (category != null)
        {
            context.Set<Category>().Remove(category);
            context.SaveChanges();
        }
    }

    public IEnumerable<Category> GetAll()
    {
        return context.Set<Category>().OrderByDescending(c=>c.Id).ToArray();
    }

    public Category GetById(int id)
    {
        return context.Set<Category>().Find(id);
    }

    public void Update(Category entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}