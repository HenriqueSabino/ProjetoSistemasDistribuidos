using BlobStorage.Business.Interfaces;
using BlobStorage.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.Controllers;


[ApiController]
[Route("[controller]")]
public class BlobController : ControllerBase
{
    private readonly IBlobService _blobService;

    public BlobController(IBlobService parcelService)
    {
        this._blobService = parcelService;
    }

    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var blob = await this._blobService.GetById(id);

        if (blob is null)
        {
            return this.NotFound();
        }

        return this.File(blob.Data, "application/octet-stream");
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] byte[] blobData)
    {
        var newBlob = await this._blobService.Add(new Blob()
        {
            Data = blobData
        });

        var uri = new Uri($"{this.Request.Scheme}://{this.Request.Host}/{nameof(this.GetById)}/{newBlob.Id}");
        return this.CreatedAtRoute(uri, newBlob.Id);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(Guid id, [FromBody] byte[] blobData)
    {
        var blob = await this._blobService.GetById(id);

        if (blob is null)
        {
            return this.NotFound();
        }

        blob.Data = blobData;

        await this._blobService.Update(blob);

        return this.Accepted(blob.Id);
    }

    [HttpDelete("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await this._blobService.Delete(id);

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