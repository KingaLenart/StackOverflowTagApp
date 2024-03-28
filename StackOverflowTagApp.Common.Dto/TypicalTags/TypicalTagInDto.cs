namespace StackOverflowTagApp.Common.Dto.TypicalTags
{
    public class TypicalTagInDto
    {
        public DateTime LastActivityDate { get; set; }
        public bool HasSynonyms { get; set; }
        public bool IsModeratorOnly { get; set; }
        public bool IsRequired { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
