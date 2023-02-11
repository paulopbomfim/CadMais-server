using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
  [Authorize]
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

  [HttpGet("id/{id}")]
  [Authorize]
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

  [HttpGet("email/{email}")]
  [Authorize]
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

  [HttpGet("cpf/{cpf}")]
  [Authorize]
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