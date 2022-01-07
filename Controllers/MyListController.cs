using Reel_Love.Data_Access;
using Reel_Love.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reel_Love.Controllers
{
  [Route("api/mylists")]
  [ApiController]
  public class MyListController : ControllerBase
  {
    MyListRepository _repo;


  public MyListController(MyListRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllLists()
    {
      return Ok(_repo.GetAll());
    }

    [HttpGet("getListById/{Id}")]
    public IActionResult GetListById(Guid Id)
    {
      var list = _repo.GetListById(Id);

      if (list == null) return NotFound($"No List With That Id Exists.");

      return Ok(list);
    }

    [HttpPost]
    public IActionResult AddList(MyLists list)
    {
      _repo.Add(list);

      return Created($"/mylists/{list.Id}", list);
    }

    [HttpDelete("{Id}")]
    public IActionResult RemoveList(Guid Id)
    {
      _repo.Remove(Id);

      return Ok();
    }

    [HttpPut("{Id}")]
    public IActionResult UpdateList(Guid Id, MyLists list)
    {
      var listToUpdate = _repo.Update(Id, list);

      if (listToUpdate == null) return NotFound($"No List With That ID Exists.");

      var updatedList = _repo.Update(Id, list);
      return Ok(updatedList);
    }

    //[HttpPut("movieToList")]
    //public IActionResult AddMovieToList(ListMovie movie)
    //{
    //  _repo.AddMovieToList(movie);
    //  return Created($"/api/mylist/{movie.ImdbID}", movie);
    //}

    //[HttpGet("movielist/{ListId}")]
    //public IActionResult GetMovieList(Guid ListId)
    //{
    //  var list = _repo.GetMovieList(ListId);

    //  if (list == null)
    //  {
    //    return NotFound("No list by this ID exists.");
    //  }

    //  return Ok(list);
    //}
  } 
}
