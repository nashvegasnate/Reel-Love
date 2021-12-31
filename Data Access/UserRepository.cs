using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Reel_Love.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reel_Love.Data_Access
{
  public class UserRepository
  {
    static List<User> _users = new List<User>();
      readonly string _connectionString;

    public UserRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("Reel-Love");
      LoadAllUsers();
    }

    internal void LoadAllUsers()
    {
      using var db = new SqlConnection(_connectionString);
      _users = db.Query<User>("SELECT * FROM USERS").ToList();
    }

    internal List<User> GetAllUsers()
    {
      return _users;
    }

    //internal IEnumerable<User> GetUserById(int Id)
    //{
    //  return _users.Where(user => user.Id == Id);
    //}

    internal User GetUserById(int Id)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT *
                  FROM USERS
                  WHERE Id = @Id";

      var user = db.QuerySingleOrDefault<User>(sql, new { Id });

      return user;
    }

    internal User GetUserByFbId(string FirebaseId)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"SELECT *
                  FROM User
                  WHERE FirebaseId = @FirebaseId";

      var user = db.QuerySingleOrDefault<User>(sql, new { FirebaseId });

      return user;
    }

    //internal User GetUserByNameFromDB(string firstName)
    //{
    //  using var db = new SqlConnection(_connectionString);
    //  var temp = db.QueryFirstOrDefault<User>("SELECT * FROM USERS WHERE firstName = @FirstName", new { firstName });
    //  return temp;
    //}

    internal void Add(User newUser)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"INSERT INTO USERS(FirstName, LastName)
                    output INSERTED.Id
                    VALUES (@FirstName, @LastName)";

      var id = db.ExecuteScalar<int>(sql, newUser);
      newUser.Id = id;
    }

    internal object UpdateUser(int Id, User user)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"Update USERS
                    SET
                    FirstName = @FirstName,
                    LastName = @LastName
                  Output Inserted.*
                  Where id= @Id";

      user.Id = Id;
      var updatedUser = db.QuerySingleOrDefault<User>(sql, user);

      return updatedUser;
    }

    internal void Remove(int id)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"DELETE
                  FROM Users
                  WHERE Id = @id";

      db.Execute(sql, new { id });
    }
  }
}
