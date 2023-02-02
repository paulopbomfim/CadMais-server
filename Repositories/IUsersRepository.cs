using CadMais.Models;
using CadMais.ViewModels;

namespace CadMais.Repositories;

public interface IUsersRepository
{
  public Task<int> Create(User newUser);
  public Task<User?> Delete(int id);
  // public Task<List<UserViewModel>> ListAll();
  // public Task<UserViewModel> ListById(int id);
}