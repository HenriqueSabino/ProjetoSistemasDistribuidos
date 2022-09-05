using SistemaDeEnvios.Models;

namespace SistemaDeEnvios.Business.Interfaces;

public interface IParcelService
{
    Task<ICollection<Parcel>> GetAll();

    Task<Parcel> GetById(int id);

    Task<Parcel> Add(Parcel parcel);

    Task<Parcel> Update(Parcel parcel);

    Task<bool> Delete(int id);
}