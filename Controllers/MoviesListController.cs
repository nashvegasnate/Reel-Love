using Reel_Love.Data_Access;
using Reel_Love.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Reel_Love.Controllers
{
  [Route("api/moviesList")]
  [ApiController]
  public class MoviesListController : ControllerBase
  {

    MoviesListRepository _repo;
    MovieRepository _movieRepo;

    public MoviesListController

      (MoviesListRepository repo,
       MovieRepository movieRepo)
    {
      _repo = repo;
      _movieRepo = movieRepo;
    }

    [HttpGet]
    public IActionResult GetAllMoviesLists()
    {
      return Ok(_repo.GetAll());
    }

    //[HttpGet("getMoviesByListsId/{ListsId}")]
    //public IActionResult GetMoviesByListsId(int ListsId)
    //{
    //  var moviesList = _repo.getMoviesByListsId(ListsId);
    //  _movieRepo.GetMovieById(ListsId);

    //  if (moviesList == null)
    //  {
    //    return NotFound($"No List With That ID Exists.");
    //  }

    //  return Ok(moviesList);
    //}
  }

  
}
