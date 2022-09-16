using System.ComponentModel.DataAnnotations;
using SistemaDeEnvios.Models.Enums;

namespace SistemaDeEnvios.Models;

public class Parcel
{
    [Key]
    public int Id { get; set; }

    public ParcelStatus Status { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}