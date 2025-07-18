/// <summary>
/// Placeholder for JSON serialization helpers.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System.IO;
using System.Text.Json;

namespace HackenSlay.Core.IO;

/// <summary>
/// Static utilities for reading and writing JSON files.
/// </summary>
public static class JSONHandler
{
    /// <summary>
    /// Reads the given JSON file and deserializes it into a <see cref="JsonDocument"/>.
    /// </summary>
    /// <param name="filePath">Path to the JSON file.</param>
    /// <returns>The parsed <see cref="JsonDocument"/> or <c>null</c> if the file does not exist.</returns>
    public static JsonDocument? LoadDocument(string filePath)
    {
        if (!File.Exists(filePath))
            return null;

        string json = File.ReadAllText(filePath);
        return JsonDocument.Parse(json);
    }

    /// <summary>
    /// Reads the given JSON file and deserializes it to the specified type.
    /// </summary>
    /// <typeparam name="T">Target type for deserialization.</typeparam>
    /// <param name="filePath">Path to the JSON file.</param>
    /// <returns>The deserialized object or <c>null</c> if the file does not exist.</returns>
    public static T? Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}