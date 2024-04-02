using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;

namespace StackOverflowTagApp.Core.Infrastructure.StackOverflow.Mappers;
public class StackOverflowTagMapper
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