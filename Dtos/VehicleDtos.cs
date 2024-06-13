
namespace GPS.Api.Dtos
{
    public class VehicleDto
    {
        public int VehicleNum { get; init; } // Immutable
        public int OwnerId { get; set; }     // Mutable
        public string Model { get; set; }
        public string Make { get; set; }
        public DateOnly Year { get; set; }

        public VehicleDto(int vehicleNum, int ownerId, string model, string make, DateOnly year)
        {
            VehicleNum = vehicleNum;
            OwnerId = ownerId;
            Model = model;
            Make = make;
            Year = year;
        }
    }

}
