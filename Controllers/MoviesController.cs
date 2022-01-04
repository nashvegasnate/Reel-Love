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
    MoviesListRepository _listRepo;

    public MoviesController(MovieRepository repo, MoviesListRepository listRepo)
    {
      _repo = repo;
      _listRepo = listRepo;
    }

    [HttpGet]
    public List<Movie> GetAllMovies()
    {
      return _repo.GetAllMovies();
    }

    [HttpGet("GetMovieByImdbID/{ImdbID}")]
    public List<Movie> GetMovieByImdbID(string ImdbID)
    {
      return _repo.GetMovieByImdbID(ImdbID);
    }

    [HttpPost]
    public IActionResult AddMovieToDb(Movie movie)
    {
      _repo.Add(movie);
      return Created($"/movie/{movie.ImdbID}", movie);
    }

    [HttpGet("GetMovieByTitle/{Title}")]
    public List<Movie> GetMovieByTitle(string Title)
    {
      return _repo.GetMovieByTitle(Title);
    }

    [HttpDelete]
    public IActionResult DeleteMovieFromDb(string ImdbID)
    {
      _repo.Remove(ImdbID);

      return Ok();
    }

    //[HttpGet("/GetAllMoviesOnAListById/{Id}")]
    //public List<Movie> GetAllMoviesOnAListById(Guid Id)
    //{
    //  return _listRepo.GetAllMoviesOnAListById(Id);
    //}

    //--------------NOT ADDED YET--------------
    [HttpGet("getMoviesOnListByListName/{ListName}")]
    public IActionResult getMoviesOnListByListName(string ListName)
    {
      var moviesList = _repo.getMoviesOnListByListName(ListName);
      if (moviesList is null) return NotFound($"That List Does Not Exist.");
      return Ok(moviesList);
    }

    //[HttpGet("getMoviesByListsId/{Id}")]
    //public IActionResult GetMoviesByListsId(int Id)
    //{
    //  var moviesList = _repo.getMoviesByListsId(Id);
    //  if (moviesList is null) return NotFound($"That List Does Not Exist.");
    //  return Ok(moviesList);
    //}

  }
}
