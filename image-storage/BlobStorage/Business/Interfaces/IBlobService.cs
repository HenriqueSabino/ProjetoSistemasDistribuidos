using BlobStorage.Data.Models;

namespace BlobStorage.Business.Interfaces;

public interface IBlobService
{
    Task<ICollection<Blob>> GetAll();

    Task<Blob?> GetById(Guid id);

    Task<Blob> Add(Blob blob);

    Task<Blob> Update(Blob blob);

    Task<bool> Delete(Guid id);
}