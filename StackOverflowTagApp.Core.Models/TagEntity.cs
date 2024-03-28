namespace StackOverflowTagApp.Core.Models
{
    public class TagEntity
    {
        public Guid TagId { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool HasSynonyms { get; set; }
        public bool IsModeratorOnly { get; set; }
        public bool IsRequired { get; set; }
        public int Count { get; set; }
        public double? PercentageOfTags { get; set; }
        public string Name { get; set; }
    }
}
