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

        // Default parameterless constructor
        public User() { }

        public User(string userID, string userPassword, string ownerID, string email, DateOnly dob)
        {
            UserID = userID;
            UserPassword = userPassword;
            OwnerID = ownerID;
            Email = email;
            Dob = dob;
        }
    }
}
