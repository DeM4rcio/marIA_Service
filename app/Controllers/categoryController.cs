using app.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace app.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController:ControllerBase
{
    public readonly AppDbContext _dbcontext;
    public readonly CategoryRepository _repository;
    public CategoryController(AppDbContext context, CategoryRepository repository)
    {
        _repository = repository;
        _dbcontext = context;
    }
    [HttpPost()]
    public void addCategory([FromBody] Category category)     
    {
       _repository.AddCategory(category);
           
    }    
    [HttpDelete("{name}")]
    public async Task DeleteCategory(string name)
    {
        await _repository.DeleteCategory(name);
    }
}