using Reel_Love.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Reel_Love.Data_Access
{
  public class MovieRepository

  {
    static List<Movie> _movies = new List<Movie>();
    readonly string _connectionString;

    public MovieRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
      LoadAllMovies();
    }

    internal void LoadAllMovies()
    {
      using var db = new SqlConnection(_connectionString);
      _movies = db.Query<Movie>("SELECT * FROM MOVIES").ToList();
    }

    internal List<Movie> GetAllMovies()
    {
      return _movies;
    }

    internal List<Movie> GetMovieByID(string ImdbID)
    {
      return _movies.Where(Movie => Movie.ImdbID == ImdbID).ToList();
    }

    internal List<Movie> GetMovieByTitle(string Title)
    {
      return _movies.Where(Movie => Movie.Title == Title).ToList();
    }
  }
}
