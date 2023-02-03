using Microsoft.AspNetCore.Mvc;

using CadMais.ViewModels;
using CadMais.Models;
using CadMais.Repositories;
using CadMais.Services;

namespace CadMais.Controller;

[Route("user")]
[Tags("User")]
[ApiController]
public class CreateUserController : ControllerBase
{
  private readonly IUsersRepository _repository;
  public CreateUserController(IUsersRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public async Task<ActionResult<UserViewModel>> Create([FromBody] User newUser)
  {
    try
    {
      Validations validations = new();

      var isPasswordValid = validations.ValidatePassword(newUser.Password);
      var isCpfValid = validations.ValidateCpf(newUser.CPF);
      var isNameValid = validations.ValidateName(newUser.Name);
      var isEmailValid = validations.ValidateEmail(newUser.Name);
      var isPhoneValid = validations.ValidatePhone(newUser.Name);

      if (!isCpfValid || !isNameValid)
      {
        return BadRequest("Check the entries and try again");
      }
      if (!isPasswordValid)
      {
        return BadRequest("Check the entries and try again");
      }

      var UserId = await _repository.Create(newUser);

      return Ok($"/user/{UserId}");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}