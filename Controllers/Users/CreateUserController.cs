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
      Validations validations = new(newUser);
      var validatedData = validations.Validate();

      if (validatedData.Status == "Error")
      {
        return BadRequest(validatedData);
      }

      var UserId = await _repository.Create(newUser);

      return Ok($"/user/{UserId}");
    }
    catch (Exception exception)
    {
      return StatusCode(500, exception.Message);
    }
  }
}