using Microsoft.AspNetCore.Mvc;

using CadMais.Repositories;
using CadMais.Models;

namespace CadMais.Controller;

[Route("user")]
[Tags("User")]
[ProducesResponseType(204)]
[ProducesResponseType(400)]
[ProducesResponseType(404)]
[ApiController]
public class UpdateUserController : ControllerBase
{
  private readonly IUsersRepository _repository;
  public UpdateUserController(IUsersRepository repository)
  {
    _repository = repository;
  }



  [HttpPut("{id}")]
  public async Task<ActionResult> Delete([FromRoute]int id, [FromBody] User user)
  {
    try
    {
      var updatedUser = await _repository.Update(id, user);

      if (updatedUser is null)
      {
        return NotFound("User not found!");
      }

      return Ok();
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}