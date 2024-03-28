using System.Text.Json.Serialization;

namespace StackOverflowTagApp.Core.Services.Models
{
    public class StackOverflowTag

    {
        [JsonPropertyName("last_activity_date")]
        public DateTime? LastActivityDate { get; set; }

        [JsonPropertyName("has_synonyms")]
        public bool HasSynonyms { get; set; }

        [JsonPropertyName("is_moderator_only")]
        public bool IsModeratorOnly { get; set; }

        [JsonPropertyName("is_required")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
