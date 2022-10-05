using SistemaDeEnvios.Data.Models.Enums;

namespace SistemaDeEnvios.Models;

public class AddParcelModel
{
    public ParcelStatus Status { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}