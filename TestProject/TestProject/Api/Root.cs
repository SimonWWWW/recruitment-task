using System.Text.Json.Serialization;

namespace TestProject.Api;

/// <summary>
///     Root json class.
/// </summary>
public class Root
{
    [JsonPropertyName("data")]
    public Data? Data { get; set; }
}