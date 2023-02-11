using CadMais.Models;

namespace CadMais.ViewModels;

public class UserUpdateViewModel
{
    public int Id { get; set; }
  public string CPF { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public IEnumerable<Address> Address { get; set; }
  public string? Token { get; set; }
}