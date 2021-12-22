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
    public List<Movie> GetAllMovies()
    {
      return _repo.GetAllMovies();
    }

    [HttpGet("GetMovieByID/{ImdbID}")]
    public List<Movie> GetMovieByID(string ImdbID)
    {
      return _repo.GetMovieByID(ImdbID);
    }

    [HttpGet("GetMovieByTitle/{Title}")]
    public List<Movie> GetMovieByTitle(string Title)
    {
      return _repo.GetMovieByTitle(Title);
    }
  }
}
