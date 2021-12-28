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
  [Route("api/usersList")]
  [ApiController]
  public class UsersListController : ControllerBase
  {
    UsersListRepository _repo;
    //UserRepository _userRepo;

    //User CurrentUser => _userRepo.GetUserById(User.FindFirst((claim) => claim.Type == "user_id").Value);

    public UsersListController(UsersListRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllUsersLists()
    {
      return Ok(_repo.GetAll());
    }

    [HttpGet("getUsersListByUsersId/{UsersId}")]
    public IActionResult GetUsersListByUsersId(int UsersId)
    {
      var usersList = _repo.getUsersListByUsersId(UsersId);

      if (usersList == null)
      {
        return NotFound($"No User With ID of {UsersId} Exists.");
      }

      return Ok(usersList);
    }

    [HttpGet("getUsersListByPartnerId/{PartnerId}")]
    public IActionResult GetUsersListByPartnerId(int PartnerId)
    {
      var usersList = _repo.getUsersListByPartnerId(PartnerId);

      if (usersList == null)
      {
        return NotFound($"No Partner With ID of {PartnerId} Exists.");
      }

      return Ok(usersList);
    }

    [HttpGet("getUsersListById/{Id}")]
    public IActionResult GetUsersListById(int Id)
    {
      var usersList = _repo.getUsersListById(Id);

      if (usersList == null)
      {
        return NotFound($"No List With ID of {Id} Exists.");
      }

      return Ok(usersList);
    }

    [HttpPost]
    public IActionResult AddUsersList(UsersList usersList)
    {
      _repo.Add(usersList);
      return Created($"/UsersList/{usersList.Id}", usersList);
    }

    [HttpDelete]
    public IActionResult RemoveUsersList(int Id)
    {
      _repo.RemoveUsersList(Id);
      return Ok();
    }

    [HttpPut]
    public IActionResult Update(int Id, UsersList usersList)
    {
      var usersListToUpdate = _repo.getUsersListById(Id);
      if (usersListToUpdate is null) return NotFound($"No Users List With ID of {Id} Exists.");

      var updatedUsersList = _repo.Update(Id, usersList);
  
      return Ok();
    }

  }




}
