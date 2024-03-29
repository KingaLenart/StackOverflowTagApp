using StackOverflowTagApp.Core.Models;
using StackOverflowTagApp.Core.Services.Models;

namespace StackOverflowTagApp.Core.Services.Implementations
{
    public class TagMapper
    {
        public TagEntity MapTag(StackOverflowTag stackOverflowTag, double populationSum)
        {
            return new TagEntity
            {
                TagId = Guid.NewGuid(),
                LastActivityDate = stackOverflowTag.LastActivityDate,
                HasSynonyms = stackOverflowTag.HasSynonyms,
                IsModeratorOnly = stackOverflowTag.IsModeratorOnly,
                IsRequired = stackOverflowTag.IsRequired,
                Count = stackOverflowTag.Count,
                PercentageOfTags = 100 * stackOverflowTag.Count / populationSum,
                Name = stackOverflowTag.Name,
            };
        }
    }
}