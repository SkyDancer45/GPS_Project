using GPS.Api.Dtos;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<VehicleDto> vehicles = [new VehicleDto(1, 2, "Honda Civic", "Type R", new DateOnly(2022, 04, 23))];
app.MapGet("/loc/{vNum}", (int vNum) => vehicles);
app.MapPost("/",(NewVehicleDtos newVehicle)=>{
      vehicles.Add(new VehicleDto(vehicles.Count+1,newVehicle.OwnerId,newVehicle.Model,newVehicle.Make,newVehicle.Year)) ;
       return Results.Created("A vehicle with the appropreite details has been created",vehicles.Find(g=>g.VehicleNum==vehicles.Count));
 });

app.Run();
