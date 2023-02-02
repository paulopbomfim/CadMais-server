using Microsoft.AspNetCore.Mvc;

using CadMais.Repositories;

namespace CadMais.Controller;

  /// <tag>User</tag>
  /// <summary>
  ///   Deletes a specific user.
  /// </summary>
  /// <param name="id"></param>
  /// <response code="204">When requests is successful</response>
  /// <response code="400">Bad requests when something went wrong</response>
  /// <response code="404">When users requested is not found</response>

[Route("user")]
[Tags("User")]
[ProducesResponseType(204)]
[ProducesResponseType(400)]
[ProducesResponseType(404)]
[ApiController]
public class DeleteUserController : ControllerBase
{
  private readonly IUsersRepository _repository;
  public DeleteUserController(IUsersRepository repository)
  {
    _repository = repository;
  }



  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(int id)
  {
    try
    {
      var user = await _repository.Delete(id);

      if (user is null)
      {
        return NotFound("User not found!");
      }

      return NoContent();
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}