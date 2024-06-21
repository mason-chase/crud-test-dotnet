using System.Text.Json.Serialization;

namespace Mc2.CrudTest.Presentation.Server.ExceptionHandlers;

/// <summary>
/// Base response model for all failed endpoints
/// </summary>
public record ResponseFailed
{
    /// <summary>
    /// Message
    /// </summary>
    [JsonPropertyName("path"), JsonPropertyOrder(0)]
    public string Path { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    [JsonPropertyName("message"), JsonPropertyOrder(1)]
    public string Message { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    [JsonPropertyName("traceId"), JsonPropertyOrder(2)]
    public string TraceId { get; set; }
}