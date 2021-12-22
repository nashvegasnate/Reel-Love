using Reel_Love.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reel_Love.Data_Access;

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

    [HttpGet]
    public List<User> GetAllUsers()
    {
      return _repo.GetAllUsers();
    }

    [HttpGet("{Id}")]
    public IActionResult GetUserById(int Id)
    {
      var user = _repo.GetUserById(Id);

      if (user == null)
      {
        return NotFound($"No user with the ID of {Id} could be found.");
      }
      return Ok(user);
    }

    //[HttpGet("GetUserByNameFromDB/{firstName}")]
    //public IEnumerable<User> GetUserFirstNameFromList(string firstName)
    //{
    //  return (IEnumerable<User>)_repo.GetUserByNameFromDB(firstName);
    //}

    [HttpPost]
    public IActionResult AddUser(User newUser)
    {
      if (string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName))
      {
        return BadRequest("First and Last Name are required fields.");
      }
      _repo.Add(newUser);

      return Created("api/users/1", newUser);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
      _repo.Remove(id);

      return Ok();
    }
  }
}
