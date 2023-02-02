using CadMais.Models;
namespace CadMais.ViewModels;

public class UserPostViewModel {
  public string CPF { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Password { get; set; }
  public IList<Address>  Address { get; set; }
}