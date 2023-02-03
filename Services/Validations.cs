using System.Text.RegularExpressions;

namespace CadMais.Services;

public class Validations
{
  public bool ValidateName(string name)
  {
    var nameRgx = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
    if (name.Length >=4 && nameRgx.IsMatch(name))
    {
      return true;
    }

    return false;
  }

  public bool ValidateEmail(string email)
  {
    var emailRgx = new Regex(@"([^\.](.*)@(\w+)(\.\w+)(\.?\w+))");

    if (emailRgx.IsMatch(email))
    {
      return true;
    }

    return false;
  }

  public bool ValidateCpf(string cpf)
  {
    char[] cpfArray = cpf.ToCharArray();
    double accumulator = 0;
    int multiplier = 11;

    for(var index = 0; index < 10; index += 1)
    {
      accumulator += char.GetNumericValue(cpfArray[index]) * multiplier;
      multiplier -= 1;
    }

    double rest = accumulator % 11;

    double validationDigit;

    if (rest == 0 || rest == 1)
    {
      validationDigit = 0;
    }
    else {
      validationDigit = 11 - rest;
    }

    if (char.GetNumericValue(cpfArray[10]) == validationDigit)
    {
      return true;
    }

    return false;
  }

  public bool ValidatePassword(string password)
  {
    var passwordRgx = new Regex(@"^^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%&*])[0-9a-zA-Z!@#$%&*]+");

    if (passwordRgx.IsMatch(password))
    {
      return true;
    }

    return false;
  }

  public bool ValidatePhone(string phone)
  {
    var phoneRegex = new Regex(@"\d+");
    if (phone.Length >= 11 && phoneRegex.IsMatch(phone))
    {
      return true;
    }

    return false;
  }
}