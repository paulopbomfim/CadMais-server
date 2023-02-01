namespace CadMais.Models;

public class User
{
  public int Id { get; set; }
  public string CPF { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Password { get; set; }
  public IList<Address> Address { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}