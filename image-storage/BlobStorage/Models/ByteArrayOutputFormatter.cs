using Microsoft.AspNetCore.Mvc.Formatters;

namespace BlobStorage.Models;

public class ByteArrayOutputFormatter : OutputFormatter
{
    public ByteArrayOutputFormatter()
    {
        SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream"));
    }

    public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        return base.CanWriteResult(context);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override IReadOnlyList<string>? GetSupportedContentTypes(string contentType, Type objectType)
    {
        return base.GetSupportedContentTypes(contentType, objectType);
    }

    public override string? ToString()
    {
        return base.ToString();
    }

    public override Task WriteAsync(OutputFormatterWriteContext context)
    {
        return base.WriteAsync(context);
    }

    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    {
        throw new NotImplementedException();
    }

    public override void WriteResponseHeaders(OutputFormatterWriteContext context)
    {
        base.WriteResponseHeaders(context);
    }

    protected override bool CanWriteType(Type? type)
    {
        return base.CanWriteType(type);
    }
}