using CadMais.Models;
using CadMais.ViewModels;

namespace CadMais.Repositories;

public interface IUsersRepository
{
  public Task<int> Create(User newUser);
  public Task<User?> Delete(int id);
  public Task<IList<UserViewModel>> List();
  public Task<UserViewModel?> ListById(int id);
  public Task<UserViewModel?> ListByEmail(string email);
  public Task<UserViewModel?> ListByCpf(string cpf);
  public Task<User?> Update(int id, User user);
}