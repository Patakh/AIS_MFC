using System;
using System.Collections.Generic;
using System.Linq;

namespace AisLogistics.DataLayer.Utils;

//TODO Удалить если не нужно
public static class MimeTypeMap
{
    private static readonly Lazy<IDictionary<string, string>> Mappings =
        new(BuildMappings);

    private static IDictionary<string, string> BuildMappings()
    {
        var mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            
        var cache = mappings.ToList(); // need ToList() to avoid modifying while still enumerating

        foreach (var (key, value) in cache.Where(mapping => !mappings.ContainsKey(mapping.Value)))
        {
            mappings.Add(key, value);
        }

        return mappings;
    }

    public static string GetMimeType(string extension)
    {
        if (extension is null)
        {
            throw new ArgumentNullException(nameof(extension));
        }

        if (!extension.StartsWith("."))
        {
            extension = "." + extension;
        }
            
        return Mappings.Value.TryGetValue(extension, out var mime) ? mime : "application/octet-stream";
    }

    public static string GetExtension(string mimeType)
    {
        if (mimeType is null)
        {
            throw new ArgumentNullException(nameof(mimeType));
        }

        if (mimeType.StartsWith("."))
        {
            throw new ArgumentException("Requested mime type is not valid: " + mimeType);
        }


        if (Mappings.Value.TryGetValue(mimeType, out var extension))
        {
            return extension;
        }

        throw new ArgumentException("Requested mime type is not registered: " + mimeType);
    }
}