using Microsoft.EntityFrameworkCore;
using SistemaDeEnvios.Business.Interfaces;
using SistemaDeEnvios.Data;
using SistemaDeEnvios.Models;

namespace SistemaDeEnvios.Business.Services;

public class ParcelService : IParcelService
{
    private readonly ApiDbContext _context;
    private readonly ILogger<ParcelService> _logger;

    public ParcelService(ApiDbContext context, ILogger<ParcelService> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async Task<Parcel> Add(Parcel parcel)
    {
        try
        {
            await this._context.Parcels.AddAsync(parcel);
            await this._context.SaveChangesAsync();
            return parcel;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not add parcel");
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var parcel = await this._context.Parcels.FindAsync(id);

            if (parcel is null)
            {
                this._logger.LogInformation("Tried to delete parcel with id {0}, which does not exist", id);
                return false;
            }

            this._context.Parcels.Remove(parcel);
            await this._context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not delete parcel");
            throw;
        }
    }

    public async Task<ICollection<Parcel>> GetAll()
    {
        try
        {
            return await this._context.Parcels.ToListAsync();
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not get parcels");
            throw;
        }
    }

    public async Task<Parcel?> GetById(int id)
    {
        try
        {
            return await this._context.Parcels.FindAsync(id);
        }
        catch (Exception e)
        {
            this._logger.LogError(e, "Could not get parcel with id {0}", id);
            throw;
        }
    }

    public async Task<Parcel> Update(Parcel parcel)
    {
        try
        {
            this._context.Parcels.Update(parcel);
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