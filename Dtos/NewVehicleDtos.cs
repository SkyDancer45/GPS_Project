namespace GPS.Api.Dtos;

public  record class NewVehicleDtos
{

        public int OwnerId { get; init; }
        public string Model { get; init; }
        public string Make { get; init; }
        public DateOnly Year { get; init; }
        private decimal XCoordinate;
        private decimal YCoordinate;
        private decimal Altitude;
        
        
    
}
