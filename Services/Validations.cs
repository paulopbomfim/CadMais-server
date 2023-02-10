using System.Text.RegularExpressions;
using CadMais.Models;
using CadMais.ViewModels;

namespace CadMais.Services;

public class Validations
{
  public string Password { get; set; }
  public string Cpf { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }

  public Validations (User user) {
    this.Name = user.Name;
    this.Email = user.Email;
    this.Cpf = user.CPF;
    this.Password = user.Password;
    this.Phone = user.Phone;
  }

  public ValidationsReturnViewModel Validate()
  {
      var isPasswordValid = this.ValidatePassword();
      var isCpfValid = this.ValidateCpf();
      var isNameValid = this.ValidateName();
      var isEmailValid = this.ValidateEmail();
      var isPhoneValid = this.ValidatePhone();

      if (!isPasswordValid) {
        return new ValidationsReturnViewModel()
        {
          Message = "The Password format is invalid.",
          Status = "Error"
        };
      }

      if (!isCpfValid) {
        return new ValidationsReturnViewModel()
        {
          Message = "The CPF format is invalid.",
          Status = "Error"
        };
      }

      if (!isNameValid) {
        return new ValidationsReturnViewModel()
        {
          Message = "The Name format is invalid.",
          Status = "Error"
        };
      }

      if (!isEmailValid) {
        return new ValidationsReturnViewModel()
        {
          Message = "The Email format is invalid.",
          Status = "Error"
        };
      }

      if (!isPhoneValid) {
        return new ValidationsReturnViewModel()
        {
          Message = "The Phone format is invalid.",
          Status = "Error"
        };
      }

      return new ValidationsReturnViewModel()
        {
          Message = "the User data format is valid",
          Status = "Success"
        };
  }

  public bool ValidateName()
  {
    var nameRgx = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
    if (this.Name.Length >=4 && nameRgx.IsMatch(this.Name))
    {
      return true;
    }

    return false;
  }

  public bool ValidateEmail()
  {
    var emailRgx = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

    if (emailRgx.IsMatch(this.Email))
    {
      return true;
    }

    return false;
  }

  public bool ValidateCpf()
  {
    if (this.Cpf.Length < 11 || this.Cpf.Length > 11)
    {
      return false;
    }
    
    char[] cpfArray = this.Cpf.ToCharArray();
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

  public bool ValidatePassword()
  {
    var passwordRgx = new Regex(@"^^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%&*])[0-9a-zA-Z!@#$%&*]+");

    if (passwordRgx.IsMatch(this.Password))
    {
      return true;
    }

    return false;
  }

  public bool ValidatePhone()
  {
    var phoneRegex = new Regex(@"\d+");
    if (this.Phone.Length >= 11 && phoneRegex.IsMatch(this.Phone))
    {
      return true;
    }

    return false;
  }
}