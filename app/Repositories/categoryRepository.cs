using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models;
using Npgsql.Internal;
using YamlDotNet.Core.Tokens;

namespace app.Repositories;

public class CategoryRepository
{
    public readonly AppDbContext  _dbcontext;
    public CategoryRepository(AppDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Category> GetById(int id)
    {
        Category category= await _dbcontext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return category ?? throw new ArgumentException("");
    }

    public async Task<Category> GetByName(string name)
    {
        Category category= await _dbcontext.Categories.FirstOrDefaultAsync(c => string.Equals(c.Name, name));
        return category ?? throw new ArgumentException("");
    }

    public async Task DeleteCategory(string name)
    {
        var category= await GetByName(name) ?? throw new Exception("Not Found");
        _dbcontext.Categories.Remove(category);
    }

    public void AddCategory(Category category)
    {
        _dbcontext.Categories.Add(category);
        _dbcontext.SaveChangesAsync();
    }
 
}