using System.Runtime.Serialization;

namespace StackOverflowTagApp.Core.Models
{
    public class UserTagEntity
    {
        [DataMember(Name = "last_activity_date")]
        public DateTime LastActivityDate { get; set; }

        [DataMember(Name = "has_synonyms")]
        public bool HasSynonyms { get; set; }

        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }

        [DataMember(Name = "is_moderator_only")]
        public bool IsModeratorOnly { get; set; }

        [DataMember(Name = "is_required")]
        public bool IsRequired { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
