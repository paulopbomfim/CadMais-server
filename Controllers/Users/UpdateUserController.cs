using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using CadMais.Repositories;
using CadMais.Models;
using CadMais.Services;
using CadMais.ViewModels;

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
  [Authorize]
  public async Task<ActionResult> Delete([FromRoute]int id, [FromBody] UserUpdateViewModel user)
  {
    try
    {
      var isCurrentUser = AuthorizationService.VerifyIdentity(id.ToString(), User);
      if (!isCurrentUser)
      {
        return Unauthorized("You can't update another user");
      }

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