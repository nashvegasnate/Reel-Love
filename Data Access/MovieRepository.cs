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

    internal List<Movie> GetMovieByTitle(string Title)
    {
      return _movies.Where(Movie => Movie.Title == Title).ToList();
    }

    internal string Add(Movie movie)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO Movies
                  (ImdbID, Title, Genre, Runtime, Year, Poster, Plot)
                  VALUES
                  (@ImdbID, @Title, @Genre, @Runtime, @Year, @Poster, @Plot)";

      var id = db.ExecuteScalar<string>(sql, movie);

      movie.ImdbID = id;

      return id;
    }

    internal void Remove(string ImdbID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE
                  FROM Movies
                  WHERE ImdbID = @ImdbID";

      db.Execute(sql, new { ImdbID });
    }


    //------------NOT REFACTORED YET------------------

    //retrieves list of movies on each list 
    //internal IEnumerable<Movie> getMoviesByListsId(Guid Id)
    //{
    //  using var db = new SqlConnection(_connectionString);
    //  var sql = @"SELECT m.Id, ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
    //              FROM Movies m
    //              JOIN MoviesList ml
    //              ON m.Id = ml.MoviesId
    //              WHERE ml.Id = @Id";

    //  var moviesList = db.Query<Movie>(sql, new { Id });

    //  return moviesList;
    //}

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

    internal MoviesList GetAllMoviesOnAListById(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"select ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
                        from Movies m
                        join ListCommand lc
                        on m.ImdbID = lc.MovieId
                        join MoviesList ml
                        on ml.Id = lc.ListId
                        where ml.Id = ml.Id";

      var moviesList = db.QueryFirstOrDefault<MoviesList>(sql, new { Id });

      return moviesList;
    }

  }
}
