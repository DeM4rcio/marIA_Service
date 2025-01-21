using app.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController:ControllerBase
{
    public readonly AppDbContext _dbcontext;
    public readonly CategoryRepository _repository;
    public CategoryController(AppDbContext context, CategoryRepository repository)
    {
        _repository = repository;
        _dbcontext = context;
    }
    [HttpPost("add/category")]
    public void addCategory([FromBody] Category category)     
    {
       _repository.AddCategory(category);
           
    }    
    [HttpDelete("delete/repository")]
    public async Task DeleteCategory([FromBody] Category category)
    {
        await _repository.DeleteCategory(category.Name);
    }
    [HttpGet("/list/category")]
    public async Task<List<string>> ListCategory()
    {
        return await _repository.ListCategory();
    }
}