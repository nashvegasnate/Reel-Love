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

    internal MoviesList getMoviesListById(int id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT *
                  FROM MoviesList
                  WHERE id = @Id";

      var moviesList = db.QuerySingleOrDefault<MoviesList>(sql, new { id });

      return moviesList;
    }

  }
}
