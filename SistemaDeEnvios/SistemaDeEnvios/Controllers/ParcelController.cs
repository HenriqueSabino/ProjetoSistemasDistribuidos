using Microsoft.AspNetCore.Mvc;
using SistemaDeEnvios.Business.Interfaces;
using SistemaDeEnvios.Models;

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
    public async Task<IActionResult> GetAll()
    {
        return this.Ok(await this._parcelService.GetAll());
    }

    [HttpGet("[action]/{id}")]
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
    public async Task<IActionResult> Add()
    {
        var newParcel = await this._parcelService.Add(new Parcel());
        var uri = new Uri($"{this.Request.Scheme}://{this.Request.Host}/{nameof(this.GetById)}/{newParcel.Id}");
        return this.CreatedAtRoute(uri, newParcel);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(int id, decimal? latitude, decimal? longitude)
    {
        var parcel = await this._parcelService.GetById(id);

        if (parcel is null)
        {
            return this.NotFound();
        }

        if (latitude.HasValue && longitude.HasValue)
        {
            parcel.Latitude = latitude;
            parcel.Latitude = longitude;
        }

        await this._parcelService.Update(parcel);

        return this.Accepted(parcel);
    }

    [HttpDelete("[action]/{id}")]
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
