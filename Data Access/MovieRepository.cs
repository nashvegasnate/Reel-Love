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

    internal List<Movie> GetMovieByImdbID(string ImdbID)
    {
      return _movies.Where(Movie => Movie.ImdbID == ImdbID).ToList();
    }

    internal List<Movie> GetMovieById(int Id)
    {
      return _movies.Where(Movie => Movie.Id == Id).ToList();
    }

    internal List<Movie> GetMovieByTitle(string Title)
    {
      return _movies.Where(Movie => Movie.Title == Title).ToList();
    }

    //retrieves list of movies on each list 
    internal IEnumerable<Movie> getMoviesByListsId(int ListsId)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT m.Id, ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
                  FROM Movies m
                  JOIN MoviesList ml
                  ON m.Id = ml.MoviesId
                  WHERE ml.ListsId = @ListsId";

      var moviesList = db.Query<Movie>(sql, new { ListsId });

      return moviesList;
    }

    internal IEnumerable<Movie> getMoviesOnListByListName(string ListName)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT m.Id, ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
                  FROM Movies m
                  JOIN MoviesList ml
                  ON m.Id = ml.MoviesId
                  WHERE ml.ListName = @ListName";

      var moviesList = db.Query<Movie>(sql, new { ListName });

      return moviesList;
    }
  }
}
