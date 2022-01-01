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
  public class MoviesListRepository
  {
    readonly string _connectionString;

    public MoviesListRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
    }

    internal IEnumerable<MoviesList> GetAll()
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT * 
                  FROM MoviesList";

      var moviesList = db.Query<MoviesList>(sql);

      return moviesList;
    }

    internal MoviesList GetMoviesListById(int id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT *
                  FROM MoviesList
                  WHERE id = @Id";

      var moviesList = db.QuerySingleOrDefault<MoviesList>(sql, new { id });

      return moviesList;
    }

    internal void CreateNewMoviesList(MoviesList newMoviesList)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO MoviesList(ListName, ListsId, MoviesId)
                    output INSERTED.Id
                    VALUES (@ListName, @ListsId, @MoviesId)";

      var id = db.ExecuteScalar<int>(sql, newMoviesList);
      newMoviesList.Id = id;

    }

    internal void Remove(int ListsId)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE
                  FROM MoviesList
                  WHERE ListsId = @ListsId";

      db.Execute(sql, new { ListsId });
    }

    //internal MoviesList AddMovieToList(int ListsId, NewMovieOnList addedMovie)
    //{
    //  var db = new SqlConnection(_connectionString);

    //  //find the user to grab the list
    //  var userSql = @"SELECT *
    //                  FROM Users
    //                  WHERE Id = @Id";

    //  var userList = db.QueryFirstOrDefault<User>(userSql, new { ListsId });

    //  //use the User to find their list
    //  var listToUpdateSql = @"SELECT ListsId
    //                          FROM MoviesList ml
    //                          JOIN UsersList ul
    //                          ON ul.UsersId = ml.ListsId
    //                          WHERE ml.ListsId = @ml.ListsId";

    //  var listToUpdate = db.QueryFirstOrDefault<MoviesList>(listToUpdateSql, new { ListsId });

    //  var listId = listToUpdate.ListsId;

    //  //get the movies currently on the list so we can add to it
    //  var currentMoviesListSql = @"SELECT *
    //                               FROM MoviesList
    //                               WHERE ListsId = @ListsId";

    //  var currentListDetails = db.Query<MoviesList>(currentMoviesListSql, new { ListsId }).ToList();
      
    //  //local list that is being created to push current movies and new movie
    //  var currentMoviesList = new List<NewList>
    //}

    //internal void AddMovieToList(Movie movie)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql =@"INSERT INTO MoviesList" 
    //}





    //internal object UpdateMoviesList(int ListsId, MoviesList moviesList)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql = @"Update MoviesList
    //                SET
    //                MoviesId = @MoviesId,
    //                ListName = @ListName
    //              Output Inserted.*
    //              Where ListsId= @ListsId";

    //  moviesList.ListsId = ListsId;
    //  var updatedList = db.QueryFirstOrDefault<User>(sql, moviesList);

    //  return updatedList;
    //}

    //internal MoviesList GetMoviesListByListsId(int ListsId)
    //{
    //  using var db = new SqlConnection(_connectionString);
    //  var sql = @"SELECT * 
    //              FROM MoviesList
    //              WHERE ListsId = @ListsId";

    //  var moviesList = db.QueryFirstOrDefault<MoviesList>(sql, new { ListsId });

    //  return moviesList;
    //}

    //internal MoviesList CreateNewMoviesList(int ListsId)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql = @"INSERT into MoviesList(ListsId, Id)
    //              OUTPUT inserted.*
    //              VALUES (@ListsId, @Id)";

    //  var newList = db.QueryFirstOrDefault<MoviesList>(sql, new { ListsId });


    //  return newList;
    //}

  }
}
