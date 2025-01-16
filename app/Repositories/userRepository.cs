using k8s.KubeConfigModels;
using Microsoft.EntityFrameworkCore;
using Models;

namespace app.Repositories;


public class UserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Models.User? AuthenticateAsync(string username, string password)
    {
        // Verifica se há um usuário com o nome e senha fornecidos
        var user =  _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == username && u.Password == password);

        return null;
    }
}