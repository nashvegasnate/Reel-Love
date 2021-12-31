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

    [HttpPost]
    public IActionResult CreateNewMoviesList(MoviesList newMoviesList)
    {
     
      _repo.CreateNewMoviesList(newMoviesList);

      return Created($"api/moviesList/{newMoviesList.ListsId}", newMoviesList);
    }

    [HttpDelete]
    public IActionResult DeleteMoviesList(int ListsId)
    {
      _repo.Remove(ListsId);

      return Ok();
    }

    //[HttpGet("{ListsId}")]
    //public IActionResult GetMoviesListByListsId(int ListsId)
    //{
    //  var moviesList = _repo.GetMoviesListByListsId(ListsId);

    //  if (moviesList == null)
    //  {
    //    return NotFound($"No List With ID of {ListsId} Exists.");
    //  }

    //  return Ok(moviesList);
    //}

    //[HttpPut("{ListsId}")]
    //public IActionResult UpdateMoviesList(int ListsId, MoviesList moviesList)
    //{
    //  var listToUpdate = _repo.GetMoviesListByListsId(ListsId);

    //  if (listToUpdate == null)
    //    return NotFound($"Could not locate a list with that ID: {ListsId} for updating.");

    //  var updatedList = _repo.UpdateMoviesList(ListsId, moviesList);

    //  return Ok(updatedList);
    //}


  }
}
