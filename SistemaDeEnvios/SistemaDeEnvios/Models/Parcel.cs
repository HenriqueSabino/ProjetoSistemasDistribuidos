using System.ComponentModel.DataAnnotations;

namespace SistemaDeEnvios.Models;

public class Parcel
{
    [Key]
    public int Id { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}