namespace GPS.Api.Endpoint;
using GPS.Api.Dtos;
public static class UserInfoEndpoint
{

  private static readonly List<UserDtos> users = [new("al12", "132"), new("ah23", "423")];
  public static WebApplication MapUserInfoEndpoints(this WebApplication app)
  {
    var userInfo = app.MapGroup("/user/");

    userInfo.MapGet("login/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      var target = users.Find(g => g.Username == userName);
      if (target == null || target.Password != userPassword)
      {
        return Results.NotFound("Incorrect Credentuas entered");
      }
      else
      {
        return Results.Ok("Correct Credentials Entered");
      }
    });
    userInfo.MapPost("register/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      if (users.FindAll(g => g.Username != userName) == null)
      {
        return Results.Conflict("Error A user with this username already exists:" + userName);

      }
      else
      {
        users.Add(new(userName, userPassword));
        return Results.Ok("A user with the entered credentials has been created:" + userName + " :" + userPassword);
      }
    });
    userInfo.MapPut("edit/{userName}/{userPassword}", (string userName, string userPassword) =>
    {
      if ()
      {

      }
    });

    return app;
  }
}
