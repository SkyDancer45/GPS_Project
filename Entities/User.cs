
using System.ComponentModel.DataAnnotations;

namespace GPS.Api.Entities
{
  public class User
  {
    [Key]
    public string UserID { get; set; }

    public required string UserPassword { get; set; }
    public required string OwnerID { get; set; }
    public required string Email { get; set; }
    public required DateOnly Dob { get; set; }
  }
}

