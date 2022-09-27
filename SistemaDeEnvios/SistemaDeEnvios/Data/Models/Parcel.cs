using System.ComponentModel.DataAnnotations;
using SistemaDeEnvios.Data.Models.Enums;

namespace SistemaDeEnvios.Data.Models;

public class Parcel
{
    [Key]
    public int Id { get; set; }

    public ParcelStatus Status { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}