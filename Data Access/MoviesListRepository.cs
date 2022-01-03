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

    internal List<MoviesList> GetAll()
    {
      using var db = new SqlConnection(_connectionString);

      var moviesLists = db.Query<MoviesList>(@"SELECT *
                                                FROM MoviesList").ToList();

      return moviesLists;
    }

    internal MoviesList GetListById(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT *
                  FROM MoviesList
                  WHERE Id = @Id";

      var moviesList = db.QuerySingleOrDefault<MoviesList>(sql, new { Id });

      return moviesList;
    }

    internal void CreateNewList(MoviesList newList)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO MoviesList (UserId, PartnerId, ListName)
                         OUTPUT INSERTED.Id
                          VALUES (@UserId, @PartnerId, @ListName)";

      var id = db.ExecuteScalar<Guid>(sql, newList);

      newList.Id = id;
     
    }

    internal void Remove(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE
                  FROM MoviesList
                  WHERE Id = @Id";

      db.Execute(sql, new { Id });
    }

    //MOVED TO MOVIES REPO
    //internal MoviesList GetAllMoviesOnAListById(Guid Id)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql = @"select ImdbID, Title, Genre, Runtime, [Year], Poster, Plot
    //                    from Movies m
    //                    join ListCommand lc
    //                    on m.ImdbID = lc.MovieId
    //                    join MoviesList ml
    //                    on ml.Id = lc.ListId
    //                    where ml.Id = ml.Id";

    //  var moviesList = db.QueryFirstOrDefault<MoviesList>(sql, new { Id });

    //  return moviesList;
    //}

    //public IActionResult CreateNewList(ListCommand command)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql = @"INSERT INTO MoviesList(UserId, PartnerId, ListName)
    //                output INSERTED.Id
    //                VALUES (@UserId, @PartnerId, @ListName)";

    //  var id = db.ExecuteScalar<Guid>(sql, newList);
    //  newList.Id = id;

    //}


    //internal void Remove(int ListsId)
    //{
    //  using var db = new SqlConnection(_connectionString);
    //  var sql = @"DELETE
    //              FROM MoviesList
    //              WHERE ListsId = @ListsId";

    //  db.Execute(sql, new { ListsId });
    //}

    internal MoviesList AddToList(Guid Id, NewList addedMovie)
    {
      var db = new SqlConnection(_connectionString);

      //We need to find the user, so we can can grab their list
      var userSql = @"SELECT *
                    FROM USERS
                    WHERE Id = @Id";

      var userList = db.QueryFirstOrDefault<User>(userSql, new { Id });

      //Using the user to find their list
      var listToUpdateSql = @"SELECT *
                              FROM MoviesList 
                              WHERE UserId = @UserId";

      var listToUpdate = db.QueryFirstOrDefault<MoviesList>(listToUpdateSql, new { Id });

      var listId = listToUpdate.Id;

      //Now get the movies currently in the list, so we can add to it
      var currentListItemsSql = @"SELECT *
                                  FROM ListCommand
                                  WHERE ListId = @thisQueryParam";

      var currentListDetails = db.Query<ListCommand>(currentListItemsSql, new { thisQueryParam = listId}).ToList();

      //Local list that we are creating to push current items and the new item
      var currentListOfMovies = new List<NewList>();

      //Add current movies to local list of movies
      foreach (var currentList in currentListDetails)
      {
        var thisMovie = new NewList { MovieId = currentList.MovieId };
        currentListOfMovies.Add(thisMovie);
      }

      //Now add the item we are adding to the cart
      currentListOfMovies.Add(addedMovie);

      //This block of code is resetting the cart based on the cart with the added items
      //var thisOrderSubtotal = 0m;

      foreach (var listMovie in currentListOfMovies)
      {
        //Get the movie from the database 
        var moviesQuery = @"SELECT *
                         FROM Movies
                         WHERE MovieId = @MovieId";

        var listMovieId = listMovie.MovieId;

        var thisMovie = db.QueryFirstOrDefault<Movie>(moviesQuery, new { id = listMovieId});

      }

      //Create a local list to update the list with the new movie
      var listToReturn = new MoviesList
      {
        Id = listToUpdate.Id,
        UserId = listToUpdate.UserId
      };

      //Update the list in the database based on new movie
      var updateListSql = @"UPDATE MoviesList
                            SET Id = @Id
                                ,UserId = @UserId
                             WHERE Id = @Id";

      var theUpdatedList = db.Execute(updateListSql, listToReturn);

      //Now that we have updated the list, save this to return to the user
      var theFinalList = db.QueryFirstOrDefault<MoviesList>(listToUpdateSql, new { Id });

      //Now we need to update the ListDetails or line items
      foreach (var listDetailMovie in currentListOfMovies)
      {
        //Get the movie per line item
        var moviesQuery = @"SELECT *
                         FROM Movie
                         WHERE MovieId = @id";
        //*******************IS THIS RIGHT?^^ Or should it be MovieId?????******************

        var listMovieId = listDetailMovie.MovieId;

        var thisMovie = db.QueryFirstOrDefault<Movie>(moviesQuery, new { id = listMovieId });

        //Create a local ListCommand to push to the database. 
        var createListCommandToCreate = new ListCommand
        {
          Id = theFinalList.Id,
          MovieId = thisMovie.ImdbID,
          ListId = listDetailMovie.ListId
         
        };

        //Only add the newly added movie to List Details
        var createListCommandSql = @"IF NOT EXISTS(SELECT *
                                                  FROM ListCommand
                                                  WHERE Id=@Id AND MovieId=@MovieId)
                                                  INSERT INTO ListCommand
                                                  (Id, ListId, MovieId)
                                              VALUES
                                                  (@Id, @ListId, @MovieId)";

        //Update the database by adding the added item
        var resultOfAdd = db.Execute(createListCommandSql, createListCommandToCreate);
      }

      //And finally return the newly created Cart 
      return theFinalList;
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
