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
  public async Task<ActionResult> Create([FromBody] User newUser)
  {
    try
    {
      Validations validations = new(newUser);
      var validatedData = validations.Validate();

      if (validatedData.Status == "Error")
      {
        return BadRequest(validatedData);
      }

      var isCpfAlreadyRegistered = await _repository.ListByCpf(newUser.CPF);
      var isEmailAlreadyRegistered = await _repository.ListByEmail(newUser.Email);

      if(isCpfAlreadyRegistered != null || isEmailAlreadyRegistered != null)
      {
        return BadRequest
        (
          new ValidationsReturnViewModel()
          {
            Message = "User already registered",
            Status = "Error"
          }
        );
      }

      var passwordHash = SecurityService.EncryptPassword(newUser.Password);
      newUser.Password = passwordHash;

      var user = await _repository.Create(newUser);



      return Created($"/user/{user.Id}", new UserViewModel() {
        Id = user.Id,
        CPF = user.CPF,
        Email = user.Email,
        Name = user.Name,
        Phone = user.Phone,
        Address = user.Address.Select(x => new AddressViewModel() {
          Id = x.Id,
          Location = x.Location
        }),
        Token = new AuthenticationService().GenerateToken(user)
      });
    }
    catch (Exception exception)
    {
      return StatusCode(500, exception.Message);
    }
  }
}