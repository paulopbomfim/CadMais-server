using Microsoft.EntityFrameworkCore;

using CadMais.Data;
using CadMais.Models;
using CadMais.ViewModels;

namespace CadMais.Repositories;

public class UsersRepository : IUsersRepository
{
  private readonly CadMaisDataContext _context;
  public UsersRepository(CadMaisDataContext context)
  {
    _context = context;
  }
  public async Task<int> Create(User newUser)
  {
    var content = await _context.User.AddAsync(newUser);
    await _context.SaveChangesAsync();

    return content.Entity.Id;
  }

  public async Task<User?> Delete(int id)
  {
    var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

    if (user is null)
    {
      return null;
    }

    _context.User.Remove(user);
    await _context.SaveChangesAsync();

    return user;
  }
}
