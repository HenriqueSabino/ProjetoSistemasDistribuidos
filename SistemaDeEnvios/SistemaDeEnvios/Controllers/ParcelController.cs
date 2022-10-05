using Microsoft.AspNetCore.Mvc;
using SistemaDeEnvios.Business.Interfaces;
using SistemaDeEnvios.Data.Models;
using SistemaDeEnvios.Data.Models.Enums;
using SistemaDeEnvios.Models;

namespace SistemaDeEnvios.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{
    private readonly IParcelService _parcelService;
    private readonly IBus _messageBus;

    public ParcelController(IParcelService parcelService, IBus messageBus, ILogger<ParcelController> logger)
    {
        this._parcelService = parcelService;
        this._messageBus = messageBus;

        this._messageBus.ReceiveAsync<AddParcelModel>("parcel-requests", this.AddParcel);
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
    public async Task<IActionResult> Add([FromBody] AddParcelModel model)
    {
        var newParcel = await this._parcelService.Add(new Parcel()
        {
            Status = model.Status,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        });

        var uri = new Uri($"{this.Request.Scheme}://{this.Request.Host}/{nameof(this.GetById)}/{newParcel.Id}");
        await this._messageBus.SendAsync<Parcel>("parcels-updates", newParcel);

        return this.CreatedAtRoute(uri, newParcel);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update([FromBody] UpdateParcelModel model)
    {
        var parcel = await this._parcelService.GetById(model.Id);

        if (parcel is null)
        {
            return this.NotFound();
        }

        parcel.Status = model.Status;

        if (model.Latitude.HasValue && model.Longitude.HasValue)
        {
            parcel.Latitude = model.Latitude;
            parcel.Longitude = model.Longitude;
        }

        await this._parcelService.Update(parcel);
        await this._messageBus.SendAsync<Parcel>("parcels-updates", parcel);

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

    private async void AddParcel(AddParcelModel model)
    {
        var newParcel = await this._parcelService.Add(new Parcel()
        {
            Status = model.Status,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        });

        var uri = new Uri($"{this.Request.Scheme}://{this.Request.Host}/{nameof(this.GetById)}/{newParcel.Id}");
        await this._messageBus.SendAsync<Parcel>("parcels-updates", newParcel);
    }
}
