namespace GPS.Api.Dtos;

public record class UserDtos
{
    public required string UserID { get; set; }
    public required string UserPassword { get; set; }
    public required string OwnerID { get; set; }
    public required string Email { get; set; }
    public required DateOnly Dob { get; set; }

    public UserDtos(string userID, string userPassword, string ownerID, string email, DateOnly dob)
    {
        UserID = userID;
        UserPassword = userPassword;
        OwnerID = ownerID;
        Email = email;
        Dob = dob;
    }
}
