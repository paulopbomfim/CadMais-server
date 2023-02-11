using Microsoft.AspNetCore.Mvc;

using CadMais.Repositories;
using CadMais.ViewModels;
using CadMais.Services;

namespace CadMais.Controller;

[Route("login")]
[Tags("Login")]
[ApiController]
public class LoginController : ControllerBase
{
  private readonly IUsersRepository _repository;

  public LoginController(IUsersRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public async Task<ActionResult> Login([FromBody] LoginViewModel login)
  {
    try
    {
      var user = await _repository.Login(login.Email);
      if (user == null)
      {
        return Unauthorized("User email or password are incorrect");
      }

      var isUserValid = SecurityService.VerifyPassword(login.Password, user.Password);
      if (!isUserValid)
      {
        return Unauthorized("User email or password are incorrect");
      }

      return Ok("User successfully logged in");

    }
    catch (Exception exception)
    {
      return StatusCode(500, exception.Message);
    }
  }
}