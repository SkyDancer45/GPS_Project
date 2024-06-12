
namespace GPS.Api.Dtos
{
    public record VehicleDto
    {
        public int VehicleNum { get; init; }
        public int OwnerId { get; init; }
        public string Model { get; init; }
        public string Make { get; init; }
        public DateOnly Year { get; init; }
        private decimal XCoordinate;
        private decimal YCoordinate;
        private decimal Altitude;
        

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
