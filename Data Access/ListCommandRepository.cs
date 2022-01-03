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
  public class ListCommandRepository
  {
    readonly string _connectionString;

    public ListCommandRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
    }

    internal List<ListCommand> GetAll()
    {
      using var db = new SqlConnection(_connectionString);

      var listCommand = db.Query<ListCommand>(@"SELECT *
                                                FROM ListCommand").ToList();

      return listCommand;
    }

    internal List<ListCommand> GetById(Guid Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT *
                  FROM ListCommand
                  WHERE Id = @Id";

      var currentListCommand = db.Query<ListCommand>(sql, new { Id }).ToList();

      return currentListCommand;
    }
  }
}
