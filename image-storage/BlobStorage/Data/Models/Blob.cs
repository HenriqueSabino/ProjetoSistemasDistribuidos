namespace BlobStorage.Data.Models;

public class Blob
{
    public Guid Id { get; set; }

    public byte[] Data { get; set; }
}