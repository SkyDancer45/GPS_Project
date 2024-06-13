namespace GPS.Api.Endpoint;
using GPS.Api.Dtos;


public static class CarInfoEndpoint
{


  private static readonly List<VehicleDto> vehicles = [new VehicleDto(1, 2, "Honda Civic", "Type R", new DateOnly(2022, 04, 23))];

  public static WebApplication MapCarInfoEndpoints(this WebApplication app)
  {
    var carWorker = app.MapGroup("car");

    carWorker.MapGet("/loc/{vNum}", (int vNum) => vehicles);
    carWorker.MapPost("/", (NewVehicleDtos newVehicle) =>
    {
      vehicles.Add(new VehicleDto(vehicles.Count + 1, newVehicle.OwnerId, newVehicle.Model, newVehicle.Make, newVehicle.Year));
      return Results.Created("A vehicle with the appropreite details has been created", vehicles.Find(g => g.VehicleNum == vehicles.Count));
    });
    carWorker.MapDelete("/{num}", (int num) => vehicles.RemoveAll(g => g.VehicleNum == num));

    carWorker.MapPut("", (VehicleDto replaceVehicle) =>
    {
      // Check if a vehicle with the provided ID exists
      var existingVehicle = vehicles.Find(v => v.VehicleNum == replaceVehicle.VehicleNum);

      if (existingVehicle == null)
      {
        // Return NotFound if no vehicle exists with the ID
        return Results.NotFound("A vehicle with ID '" + replaceVehicle.VehicleNum + "' was not found.");
      }

      // Update existing vehicle properties (assuming replaceVehicle has the desired data)
      existingVehicle.OwnerId = replaceVehicle.OwnerId;  // Update each property as needed
      existingVehicle.Model = replaceVehicle.Model;
      existingVehicle.Make = replaceVehicle.Make;
      existingVehicle.Year = replaceVehicle.Year;

      // Optional: Implement logic to update location data (XCoordinate, YCoordinate, Altitude)

      // Return a successful response (consider returning the updated vehicle)
      return Results.Ok(existingVehicle); // Adjust response based on your needs
    });
    carWorker.MapDelete("{id}",(int id)=>vehicles.RemoveAll(g=>g.VehicleNum==id));

    return app;
  }


}
