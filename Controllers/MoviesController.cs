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
  [Route("api/movies")] //exposed at this endpoint
  [ApiController] //api controller means it returns json or xml
  public class MoviesController : ControllerBase
  {
    MovieRepository _repo;

    public MoviesController(MovieRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
      return Ok(_repo.GetAllMovies());
    }

    [HttpGet("GetAllMoviesOnList/{Id}")]
    public IActionResult GetAllMoviesOnList(Guid Id)
    {
      return Ok(_repo.GetAllMoviesOnList(Id));
    }

    [HttpGet("GetMovieByImdbID/{ImdbID}")]
    public IActionResult GetMovieByImdbID(string ImdbID)
    {
      return Ok(_repo.GetMovieByImdbID(ImdbID));
    }

    [HttpDelete]
    public IActionResult DeleteMovie(string ImdbID)
    {
      _repo.Remove(ImdbID);

      return Ok();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
      _repo.Add(movie);

      return Created("movies/{movie.ImdbID}", movie);
    }

    //[HttpGet("GetMovieByTitle/{Title}")]
    //public List<Movie> GetMovieByTitle(string Title)
    //{
    //  return _repo.GetMovieByTitle(Title);
    //}

    //

    ////THIS WORKS!
    //[HttpGet("getMoviesOnListByListName/{ListName}")]
    //public IActionResult getMoviesOnListByListName(string ListName)
    //{
    //  var moviesList = _repo.getMoviesOnListByListName(ListName);
    //  if (moviesList is null) return NotFound($"That List Does Not Exist.");
    //  return Ok(moviesList);
    //}

    ////THIS WORKS!!
    //[HttpGet("/GetAllMoviesOnAListById/{Id}")]
    //public IActionResult GetAllMoviesOnAListById(Guid Id)
    //{
    //  var moviesList = _repo.GetAllMoviesOnAListById(Id);
    //  if (moviesList is null) return NotFound($"That List Does Not Exist.");
    //  return Ok(moviesList);
    //}

    ////THIS WORKS!!
    //[HttpGet("/GetAllMoviesOnAListByUserId/{Id}")]
    //public IActionResult GetAllMoviesOnAListByUserId(Guid Id)
    //{
    //  var moviesList = _repo.GetAllMoviesOnAListByUserId(Id);
    //  if (moviesList is null) return NotFound($"That List Does Not Exist.");
    //  return Ok(moviesList);
    //}

  }
}
