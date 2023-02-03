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

  public async Task<IList<UserViewModel>> List()
  {
    return await _context.User.AsNoTracking()
      .Include(x => x.Address)
      .Select(x => new UserViewModel()
      {
        Id = x.Id,
        CPF = x.CPF,
        Name = x.Name,
        Email = x.Email,
        Phone = x.Phone,
        Address = x.Address.Select(y =>
          new AddressViewModel() {
            Id = y.Id,
            Location = y.Location
          }
        ),
      })
      .ToListAsync();
  }

  public async Task<UserViewModel?> ListById(int id)
  {
    return await _context.User.AsNoTracking()
      .Include(x => x.Address)
      .Select(x => new UserViewModel()
      {
        Id = x.Id,
        CPF = x.CPF,
        Name = x.Name,
        Email = x.Email,
        Phone = x.Phone,
        Address = x.Address.Select(y =>
          new AddressViewModel() {
            Id = y.Id,
            Location = y.Location
          }
        ),
      })
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<UserViewModel?> ListByEmail(string email)
  {
      return await _context.User.AsNoTracking()
      .Include(x => x.Address)
      .Select(x => new UserViewModel()
      {
        Id = x.Id,
        CPF = x.CPF,
        Name = x.Name,
        Email = x.Email,
        Phone = x.Phone,
        Address = x.Address.Select(y =>
          new AddressViewModel() {
            Id = y.Id,
            Location = y.Location
          }
        ),
      })
      .FirstOrDefaultAsync(x => x.Email == email);
  }

  public async Task<UserViewModel?> ListByCpf(string cpf)
  {
      return await _context.User.AsNoTracking()
      .Include(x => x.Address)
      .Select(x => new UserViewModel()
      {
        Id = x.Id,
        CPF = x.CPF,
        Name = x.Name,
        Email = x.Email,
        Phone = x.Phone,
        Address = x.Address.Select(y =>
          new AddressViewModel() {
            Id = y.Id,
            Location = y.Location
          }
        ),
      })
      .FirstOrDefaultAsync(x => x.CPF == cpf);
  }

  public async Task<User?> Update(int id, User user)
  {
    var userFound = await _context.User
      .Include(x => x.Address)
      .FirstOrDefaultAsync(x => x.Id == id);

    // var userAddress = await _context.Address.

    if (userFound is null)
    {
      return null;
    }

    userFound.CPF = user.CPF;
    userFound.Name = user.Name;
    userFound.Email = user.Email;
    userFound.Phone = user.Phone;
    userFound.Address = user.Address;

    _context.User.Update(userFound);

    await _context.SaveChangesAsync();
    return userFound;
  }
}
