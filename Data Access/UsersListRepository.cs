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
  public class UsersListRepository
  {
    readonly string _connectionString;

    public UsersListRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
    }

    internal IEnumerable<UsersList> GetAll()
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT * 
                  FROM UsersList";

      var usersList = db.Query<UsersList>(sql);

      return usersList;
    }

    internal UsersList getUsersListById(int id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT * 
                  FROM UsersList
                  WHERE id = @Id";

      var usersList = db.QuerySingleOrDefault<UsersList>(sql, new { id });

      return usersList;
    }

    internal UsersList getUsersListByUsersId(int UsersId)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT * 
                  FROM UsersList
                  WHERE usersId = @usersId";

      var usersList = db.QuerySingleOrDefault<UsersList>(sql, new { UsersId });

      return usersList;
    }

    internal UsersList getUsersListByPartnerId(int PartnerId)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"SELECT * 
                  FROM UsersList
                  WHERE partnerId = @PartnerId";

      var usersList = db.QuerySingleOrDefault<UsersList>(sql, new { PartnerId });

      return usersList;
    }

    internal void Add(UsersList newUsersList)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT into UsersList(UsersId, ListTitle, PartnerId)
                  OUTPUT inserted.Id
                  VALUES (@UsersId, @ListTitle, @PartnerId)";

      var Id = db.ExecuteScalar<int>(sql, newUsersList);

      newUsersList.Id = Id;
    }

    internal void RemoveUsersList(int Id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE
                  FROM UsersList
                  WHERE Id = @Id";

      db.Execute(sql, new { Id });
    }

    internal object Update(int Id, UsersList usersList)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"UPDATE UsersList
                  SET UsersId = @UsersId,
                      PartnerId = @PartnerId,
                      ListTitle = @ListTitle
                  OUTPUT INSERTED.*
                  WHERE Id = @Id";

      usersList.Id = Id;

      var updatedUsersList = db.QuerySingleOrDefault<UsersList>(sql, usersList);

      return updatedUsersList;
    }
  }
}
