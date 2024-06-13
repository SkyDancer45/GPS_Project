namespace GPS.Api.Endpoint;
using GPS.Api.Dtos;

public static class UserInfoEndpoint
{
  private static readonly List<UserDtos> users = new List<UserDtos>
    {
        new("al12", "132"),
        new("ah23", "423")
    };

  public static WebApplication MapUserInfoEndpoints(this WebApplication app)
  {
    var userInfo = app.MapGroup("/user/");

    userInfo.MapGet("login/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      var target = users.Find(g => g.Username == userName);
      if (target == null || target.Password != userPassword)
      {
        return Results.NotFound("Incorrect credentials entered");
      }
      else
      {
        return Results.Ok("Correct credentials entered");
      }
    });
    userInfo.MapGet("show", () => users);

    userInfo.MapPost("register/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      if (users.Exists(g => g.Username == userName))
      {
        return Results.Conflict("Error: A user with this username already exists: " + userName);
      }
      else
      {
        users.Add(new UserDtos(userName, userPassword));
        return Results.Ok("A user with the entered credentials has been created: " + userName + " :" + userPassword);
      }
    });

    userInfo.MapPut("edit/{userName}/{userPassword}/{newUserName}/{newUserPassword}", (string userName, string userPassword, string newUserName, string newUserPassword) =>
    {
      var target = users.Find(g => g.Username == userName);
      if (target == null || target.Password != userPassword)
      {
        return Results.NotFound("Incorrect credentials entered");
      }
      else
      {
        users.Remove(target);
        users.Add(new(newUserName, newUserPassword));
        return Results.Ok("User info updated");
      }
    });

    userInfo.MapDelete("delete/{userName}", (string userName) =>
    {
      int removedCount = users.RemoveAll(g => g.Username == userName);
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

public record UserDtos(string Username, string Password);
