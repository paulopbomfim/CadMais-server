using Microsoft.AspNetCore.Mvc;

using CadMais.ViewModels;
using CadMais.Repositories;

namespace CadMais.Controller;

[Route("user")]
[Tags("User")]
[ApiController]
public class ListUserController : ControllerBase
{
  private readonly IUsersRepository _repository;
  public ListUserController(IUsersRepository repository)
  {
    _repository = repository;
  }

  [HttpGet("/users")]
  [Tags("Users")]
  public async Task<ActionResult<UserViewModel>> List()
  {
    try
    {
      var users = await _repository.List();

      return Ok(users);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<UserViewModel>> ListById(int id)
  {
    try
    {
      var User = await _repository.ListById(id);

      if (User is null)
      {
        return NotFound("User is not found");
      }

      return Ok(User);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{email}")]
  public async Task<ActionResult<UserViewModel>> ListByEmail([FromRoute] string email)
  {
    try
    {
      var User = await _repository.ListByEmail(email);

      if (User is null)
      {
        return NotFound("User is not found");
      }

      return Ok(User);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cpf}")]
  public async Task<ActionResult<UserViewModel>> ListByCpf([FromRoute] string cpf)
  {
    try
    {
      var User = await _repository.ListByCpf(cpf);

      if (User is null)
      {
        return NotFound("User is not found");
      }

      return Ok(User);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}