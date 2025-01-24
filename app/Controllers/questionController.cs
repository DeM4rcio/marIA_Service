using app.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace app.Controllers;
[ApiController]
[Route("api/question")]
public class QuestionController: ControllerBase
{
    public readonly AppDbContext _context;
    public readonly QuestionRepository _repository;
    public QuestionController(AppDbContext context, QuestionRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    [HttpPost]
    public async Task addQuestion([FromBody] Question question)
    {
        await _repository.addQuestion(question);   
    }

    [HttpGet("list")]
    public async Task<List<string>> listQuestion()
    {
        return await _repository.listQuestion();
    }
}