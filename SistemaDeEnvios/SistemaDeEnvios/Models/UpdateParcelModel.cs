using SistemaDeEnvios.Data.Models.Enums;

namespace SistemaDeEnvios.Models;

public class UpdateParcelModel
{
    public int Id { get; set; }

    public string OrderId { get; set; }

    public ParcelStatus Status { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}