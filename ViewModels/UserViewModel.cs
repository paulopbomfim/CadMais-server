using CadMais.Models;

namespace CadMais.ViewModels;

public class UserViewModel
{
  public int Id { get; set; }
  public string? CPF { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public IEnumerable<Address>? Address { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}