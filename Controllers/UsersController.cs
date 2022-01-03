using Reel_Love.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reel_Love.Data_Access;
using Microsoft.AspNetCore.Authorization;

namespace Reel_Love.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    UserRepository _repo;

    public UsersController(UserRepository repo)
    {
      _repo = repo;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAllUsers()
    {
      return Ok(_repo.GetAllUsers());
    }

    [HttpGet("{Id}")]
    public IActionResult GetUserById(Guid Id)
    {
      var user = _repo.GetUserById(Id);

      if (user == null)
      {
        return NotFound($"No user with the ID of {Id} could be found.");
      }
      return Ok(user);
    }

    [HttpGet("GetUserByFbId/{FirebaseId}")]
    public IActionResult GetUserByFbId(string FirebaseId)
    {
      var user = _repo.GetUserByFbId(FirebaseId);

      if (user == null)
      {
        return NotFound($"No User With That FirebaseId Exists.");
      }

      return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult AddUser(User newUser)
    {
      if (string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName))
      {
        return BadRequest("First and Last Name are required fields.");
      }
      _repo.Add(newUser);

      return Created($"api/users/{newUser.Id}", newUser);
    }

    [AllowAnonymous]
    [HttpPut("{Id}")]
    public IActionResult UpdateUser(Guid Id, User user)
    {
      var userToUpdate = _repo.GetUserById(Id);

      if (userToUpdate == null)
        return NotFound($"Could not locate a user with that ID: {Id} for updating.");

      var updatedUser = _repo.UpdateUser(Id, user);

      return Ok(updatedUser);
    }

    [HttpDelete]
    public IActionResult DeleteUser(Guid Id)
    {
      _repo.Remove(Id);

      return Ok();
    }
  }
}
