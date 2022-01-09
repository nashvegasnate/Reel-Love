using Reel_Love.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Reel_Love.Data_Access
{
  public class MovieRepository

  {

    readonly string _connectionString;

    public MovieRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
    }

    internal IEnumerable<Movie> GetAllMovies()
    {
      using var db = new SqlConnection(_connectionString);

      var movies = db.Query<Movie>(@"SELECT * from MOVIES");

      return movies;
    }

    internal Movie GetMovieByImdbID(string ImdbID)
    {

      using var db = new SqlConnection(_connectionString);

      var sql = @"Select *
                  From Movies
                  where ImdbID = @ImdbID";

      var movie = db.QuerySingleOrDefault<Movie>(sql, new { ImdbID });

      if (movie == null) return null;

      return movie;
    }

    internal IEnumerable<Movie> GetAllMoviesOnList(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT ImdbID, Title, Genre, Runtime, [Year], Poster, Plot 
                                  FROM MOVIES m
                                      JOIN MyLists ml
                                        ON ml.Id = m.ListId
                                      WHERE ml.Id = @Id";

      var moviesList = db.Query<Movie>(sql, new { Id });


      return moviesList;
    }

  

    internal void Remove(string ImdbID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE 
                  FROM Movies
                  Where ImdbID = @ImdbID";

      db.Execute(sql, new { ImdbID });
    }

    internal void Add(Movie movie)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO Movies(ImdbID, Title, Genre, Runtime, Year, Poster, Plot, ListId)
                  VALUES(@ImdbID, @Title, @Genre, @Runtime, @Year, @Poster, @Plot, @ListId)";

      var id = db.ExecuteScalar<string>(sql, movie);

      movie.ImdbID = id;

    }

    internal object UpdateMovie(string ImdbID, Movie movie)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"UPDATE Movies
                  SET ImdbID = @ImdbID, 
                      Title = @Title,
                      Genre = @Genre, 
                      Runtime = @Runtime,
                      Year = @Year, 
                      Poster = @Poster,
                      Plot = @Plot, 
                      ListId = @ListId";
      movie.ImdbID = ImdbID;
      var updatedMovie = db.QuerySingleOrDefault<Movie>(sql, movie);
      return updatedMovie;

    }

  }
}


    

//    internal List<Movie> GetMovieByTitle(string Title)
//    {
//      return _movies.Where(Movie => Movie.Title == Title).ToList();
//    }

//   

//    internal void Remove(string ImdbID)
//    {
//      using var db = new SqlConnection(_connectionString);
//      var sql = @"DELETE
//                  FROM Movies
//                  WHERE ImdbID = @ImdbID";

//      db.Execute(sql, new { ImdbID });
//    }


//    //------------NOT REFACTORED YET------------------

//    //retrieves list of movies on each list 
//    //internal IEnumerable<Movie> getMoviesByListsId(Guid Id)
//    //{
//    //  using var db = new SqlConnection(_connectionString);
//    //  var sql = @"SELECT m.Id, ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
//    //              FROM Movies m
//    //              JOIN MoviesList ml
//    //              ON m.Id = ml.MoviesId
//    //              WHERE ml.Id = @Id";

//    //  var moviesList = db.Query<Movie>(sql, new { Id });

//    //  return moviesList;
//    //}

//    //THIS WORKS!!
//    internal IEnumerable<Movie> getMoviesOnListByListName(string ListName)
//    {
//      using var db = new SqlConnection(_connectionString);
//      var sql = @"SELECT ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
//                  FROM Movies m
//                  JOIN ListCommand lc
//                  ON m.ImdbID = lc.MovieId
//                  JOIN MoviesList ml
//                  ON ml.Id = lc.ListId
//                  WHERE ml.ListName = @ListName";

//      var moviesList = db.Query<Movie>(sql, new { ListName });

//      return moviesList;
//    }

//    //THIS WORKS!!
//    internal IEnumerable<Movie> GetAllMoviesOnAListById(Guid Id)
//    {
//      using var db = new SqlConnection(_connectionString);

//      var sql = @"SELECT ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
//                        FROM Movies m
//                        JOIN ListCommand lc
//                        ON m.ImdbID = lc.MovieId
//                        JOIN MoviesList ml
//                        ON ml.Id = lc.ListId
//                        WHERE ml.Id = @Id";

//      var moviesList = db.Query<Movie>(sql, new { Id });

//      return moviesList;
//    }

//    //THIS WORKS!!
//    internal IEnumerable<Movie> GetAllMoviesOnAListByUserId(Guid Id)
//    {
//      using var db = new SqlConnection(_connectionString);

//      var sql = @"SELECT ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
//                        FROM Movies m
//                        JOIN ListCommand lc
//                        ON m.ImdbID = lc.MovieId
//                        JOIN MoviesList ml
//                        ON ml.Id = lc.ListId
//                        JOIN Users u
//                        ON u.Id = ml.UserId
//                        WHERE u.Id = @Id";

//      var moviesList = db.Query<Movie>(sql, new { Id });

//      return moviesList;
//    }


//  }
// }

