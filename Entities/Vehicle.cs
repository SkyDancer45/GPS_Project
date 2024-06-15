
using System.ComponentModel.DataAnnotations;

namespace GPS.Api.Entities
{
  public class Vehicle
  {
    [Key]
    public int VehicleNum { get; set; } // Corrected property name

    public required string OwnerId { get; set; }
    public required string Model { get; set; }
    public required string Make { get; set; }
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
    public required DateOnly Year { get; set; }
  }
}

