using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DotnetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        //Console.WriteLine(config.GetConnectionString("DefaultConnection"));
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("testConnection")]

    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers")]
    //public IActionResult Test()
    public IEnumerable<User> GetUsers()
    {
        string sql = @"
        SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] 
        FROM App3Schema.Users";

        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        
        return users;
    }



     [HttpGet("GetSingleUsers/{userId}")]
    //public IActionResult Test()
    public User GetSingleUsers(int userId)
    {
        string sql = @"
        SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] 
        FROM App3Schema.Users
            WHERE UserId = " + userId.ToString();

        User user = _dapper.LoadDataSingle<User>(sql);
        
        return user;

    }

     [HttpGet("GetUsers/{testValue}")]
    //public IActionResult Test()
    public string[] GetUsers(string testValue)
    {
        string[] responseArray = new string[] {
            "test1",
            "test2",
            testValue

        };

        return responseArray;

    }

}

