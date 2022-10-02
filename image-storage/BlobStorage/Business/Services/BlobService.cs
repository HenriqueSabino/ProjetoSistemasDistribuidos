using Microsoft.EntityFrameworkCore;
using BlobStorage.Business.Interfaces;
using BlobStorage.Data;
using BlobStorage.Data.Models;

namespace BlobStorage.Business.Services;

public class BlobService : IBlobService
{
    private readonly ApiDbContext _context;
    private readonly ILogger<BlobService> _logger;

    public BlobService(ApiDbContext context, ILogger<BlobService> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async Task<Blob> Add(Blob parcel)
    {
        try
        {
            await this._context.Blobs.AddAsync(parcel);
            await this._context.SaveChangesAsync();
            return parcel;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not add parcel");
            throw;
        }
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var parcel = await this._context.Blobs.FindAsync(id);

            if (parcel is null)
            {
                this._logger.LogInformation("Tried to delete parcel with id {0}, which does not exist", id);
                return false;
            }

            this._context.Blobs.Remove(parcel);
            await this._context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not delete parcel");
            throw;
        }
    }

    public async Task<ICollection<Blob>> GetAll()
    {
        try
        {
            return await this._context.Blobs.ToListAsync();
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not get parcels");
            throw;
        }
    }

    public async Task<Blob?> GetById(Guid id)
    {
        try
        {
            return await this._context.Blobs.FindAsync(id);
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not get parcel with id {0}", id);
            throw;
        }
    }

    public async Task<Blob> Update(Blob parcel)
    {
        try
        {
            this._context.Blobs.Update(parcel);
            await this._context.SaveChangesAsync();

            return parcel;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not add parcel");
            throw;
        }
    }
}