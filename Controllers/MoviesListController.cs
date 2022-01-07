//using Microsoft.AspNetCore.Mvc;
//using Reel_Love.Data_Access;
//using Reel_Love.Models;
//using System;
//using System.Collections.Generic;

//namespace Reel_Love.Controllers
//{
//  [Route("api/moviesList")]
//  [ApiController]
//  public class MoviesListController : ControllerBase
//  {

//    MoviesListRepository _repo;
//    MovieRepository _movieRepo;

//    public MoviesListController

//      (MoviesListRepository repo,
//       MovieRepository movieRepo)
//    {
//      _repo = repo;
//      _movieRepo = movieRepo;
//    }

//    [HttpGet]
//    public List<MoviesList> GetAllMoviesLists()
//    {
//      return _repo.GetAll();
//    }

//    [HttpGet("/GetListById/{Id}")]
//    public IActionResult GetListById(Guid Id)
//    {
//      var movieList = _repo.GetListById(Id);

//      if (movieList == null)
//      {
//        return NotFound($"No list with the ID of {Id} exists.");
//      }

//      return Ok(movieList);

//    }

//    [HttpPost]
//    public IActionResult CreateNewList(MoviesList newList)
//    {
//      _repo.CreateNewList(newList);

//      return Created($"api/moviesList/{newList.Id}", newList);
//    }

//    [HttpDelete]
//    public IActionResult DeleteList(Guid Id)
//    {
//      _repo.Remove(Id);

//      return Ok();
//    }

//    // MOVED TO MOVIES CONTROLLER
//    //[HttpGet("/GetAllMoviesOnAListById/{Id}")]
//    //public IActionResult GetAllMoviesOnAListById(Guid Id)
//    //{
//    //  var movieList = _repo.GetAllMoviesOnAListById(Id);

//    //  if (movieList == null)
//    //  {
//    //    return NotFound($"No list with the ID of {Id} exists.");
//    //  }

//    //  return Ok(movieList);
//    //}


//    [HttpPut("/addMovieToList/{userID}")]
//    public MoviesList AddToList(Guid userID, NewList listMovie)
//    {
//      return _repo.AddToList(userID, listMovie);
//    }


//  }
//}
