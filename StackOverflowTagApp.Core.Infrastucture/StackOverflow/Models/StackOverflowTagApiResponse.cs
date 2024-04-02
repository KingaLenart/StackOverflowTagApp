using System.Text.Json.Serialization;

namespace StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;

public class StackOverflowTagApiResponse
{
    public List<StackOverflowTag> Items { get; set; }
    [JsonPropertyName("has_max")]
    public bool HasMore { get; set; }
    [JsonPropertyName("quota_max")]
    public int QuotaMax { get; set; }
    [JsonPropertyName("quota_remaining")]
    public int QuotaRemaining { get; set; }
}
