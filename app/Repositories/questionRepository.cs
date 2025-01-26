using app.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace app.Repositories;

public class QuestionRepository{
    public readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task addQuestion (Question question)
    {
        var category = await _context.Categories.FindAsync(question.Id);

        if (category == null)
        {
           
        }

        var questionadd = new Question{
            Text = question.Text,
            categoryId = question.categoryId,
            answer = question.answer,
        };

        _context.Questions.Add(questionadd);
        _context.SaveChangesAsync();

        
           
    }

    [HttpGet("{id}")]
    public async Task GetQuestionById(int id)
    {
        var question = await _context.Questions
            .Include(q => q.categoryId) // Carregar a categoria associada
            .FirstOrDefaultAsync(q => q.Id == id);

        if (question == null)
        {
            
        }

       
    }

    [HttpGet]
    public async Task<List<string>> listQuestion(int? pagesize = 0)
    {
        return await _context.Questions.Select(e => e.Text).ToListAsync();
    }
}