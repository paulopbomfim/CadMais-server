namespace CadMais.Services;

public class SecurityService
{
  public static string EncryptPassword(string password)
  {
    int workFactor = 16;
    var salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
    var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

    return passwordHash;
  }

  public static bool VerifyPassword(string password, string passwordHash)
  {
    return BCrypt.Net.BCrypt.Verify(password, passwordHash);
  }
}