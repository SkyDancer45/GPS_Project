using GPS.Api.Data;
using GPS.Api.Entities;
namespace GPS.Api.Endpoint;
using GPS.Api.Dtos;

public static class UserInfoEndpoint
{
    private static readonly List<UserDtos> users = new List<UserDtos>
    {
        new UserDtos("user1", "password1", "owner1", "user1@example.com", new DateOnly(1990, 1, 1)),
        new UserDtos("user2", "password2", "owner2", "user2@example.com", new DateOnly(1992, 2, 2))
    };

  public static WebApplication MapUserInfoEndpoints(this WebApplication app)
  {
    var userInfo = app.MapGroup("/user/");

    userInfo.MapGet("login/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      var target = users.Find(g => g.UserID == userName);
      if (target == null || target.UserPassword != userPassword)
      {
        return Results.NotFound("Incorrect credentials entered");
      }
      else
      {
        return Results.Ok("Correct credentials entered");
      }
    });
    userInfo.MapGet("show", () => users);

    userInfo.MapPost("register/{userName}/{userPassword}", (UserDtos newUser, GpsContext dbContext) =>
    {
      /* User user = new(); */
      if (users.Exists(g => g.UserID == newUser.UserID))
      {
        return Results.Conflict("Error: A user with this username already exists: " + newUser.UserID);
      }
      else
      {
        users.Add(new UserDtos{
          UserID=newUser.UserID,
        UserPassword=newUser.UserPassword,
        OwnerID=newUser.OwnerID,
        Email=newUser.Email,
        Dob=newUser.Dob});
        return Results.Ok("A user with the entered credentials has been created: " + newUser.UserID + " :" + newUser.UserPassword);
      }
    });

    userInfo.MapPut("edit", (UserDtos newUser) =>
    {
      var target = users.Find(g => g.UserID == newUser.UserID);
      if (target == null || target.UserPassword != newUser.UserPassword)
      {
        return Results.NotFound("Incorrect credentials entered");
      }
      else
      {
        users.Remove(target);
        users.Add(new UserDtos{
          UserID=newUser.UserID,
        UserPassword=newUser.UserPassword,
        OwnerID=newUser.OwnerID,
        Email=newUser.Email,
        Dob=newUser.Dob});        return Results.Ok("User info updated");
      }
    });

    userInfo.MapDelete("delete/{userName}", (string userName) =>
    {
      int removedCount = users.RemoveAll(g => g.UserID == userName);
      if (removedCount > 0)
      {
        return Results.Ok("User deleted");
      }
      else
      {
        return Results.NotFound("User not found");
      }
    });

    return app;
  }
}

