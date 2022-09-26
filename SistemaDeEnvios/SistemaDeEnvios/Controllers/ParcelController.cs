using Microsoft.AspNetCore.Mvc;
using SistemaDeEnvios.Business.Interfaces;
using SistemaDeEnvios.Data.Models;
using SistemaDeEnvios.Data.Models.Enums;

namespace SistemaDeEnvios.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{
    private readonly IParcelService _parcelService;

    public ParcelController(IParcelService parcelService)
    {
        this._parcelService = parcelService;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return this.Ok(await this._parcelService.GetAll());
    }

    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id)
    {
        var parcel = await this._parcelService.GetById(id);

        if (parcel is null)
        {
            return this.NotFound();
        }

        return this.Ok(parcel);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(ParcelStatus status = ParcelStatus.Posted, decimal? latitude = null, decimal? longitude = null)
    {
        var newParcel = await this._parcelService.Add(new Parcel()
        {
            Status = status,
            Latitude = latitude,
            Longitude = longitude,
        });

        var uri = new Uri($"{this.Request.Scheme}://{this.Request.Host}/{nameof(this.GetById)}/{newParcel.Id}");
        return this.CreatedAtRoute(uri, newParcel);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(int id, ParcelStatus status, decimal? latitude, decimal? longitude)
    {
        var parcel = await this._parcelService.GetById(id);

        if (parcel is null)
        {
            return this.NotFound();
        }

        parcel.Status = status;

        if (latitude.HasValue && longitude.HasValue)
        {
            parcel.Latitude = latitude;
            parcel.Longitude = longitude;
        }

        await this._parcelService.Update(parcel);

        return this.Accepted(parcel);
    }

    [HttpDelete("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await this._parcelService.Delete(id);

        if (result)
        {
            return this.Accepted();
        }
        else
        {
            return this.NotFound();
        }
    }
}
