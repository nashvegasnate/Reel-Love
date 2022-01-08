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
  public class MyListRepository
  {
    string _connectionString;

    public MyListRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
    }

    internal IEnumerable<MyLists> GetAll()
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT * 
                  FROM MyLists";

      var lists = db.Query<MyLists>(sql);

      return lists;
    }

    internal MyLists GetListById(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT *
                  FROM MyLists
                  WHERE Id = @Id";

      var list = db.QuerySingleOrDefault<MyLists>(sql, new { Id });

      return list;
    }

    internal Guid Add(MyLists list)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO MyLists(ListName)
                  OUTPUT INSERTED.Id
                  VALUES(@ListName)";

      var id = db.ExecuteScalar<Guid>(sql, list);
      list.Id = id;

      return id;
    }

    internal void Remove(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"DELETE 
                  FROM MyLists
                  WHERE Id = @Id";

      db.Execute(sql, new { Id });

    }

    internal object Update(Guid Id, MyLists list)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"UPDATE MyLists
                  SET 
                  ListName = @ListName
                  OUTPUT INSERTED.*
                  WHERE Id = @Id";

      list.Id = Id;

      var updatedList = db.QuerySingleOrDefault<MyLists>(sql, list);

      return updatedList;
    }

    //MyLists Map(MyLists list, ListMovie listMovie, Movie movie)
    //{
    //  list.ListMovie = listMovie;
    //  list.Movie = movie;
    //  return list;
    //}

    //internal void AddMovieToList(ListMovie movie)
    //{
    //  using var db = new SqlConnection(_connectionString);

    //  var sql = @"INSERT INTO ListMovie
    //                            (ListId, MovieId)
    //                            Output inserted.Id
    //                            values (@ListId, @MovieId)";

    //  var id = db.ExecuteScalar<Guid>(sql, movie);
    //  movie.Id = id;
    //}

  }
}
