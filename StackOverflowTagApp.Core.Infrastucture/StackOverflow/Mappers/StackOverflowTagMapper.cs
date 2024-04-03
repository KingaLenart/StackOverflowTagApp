using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;

namespace StackOverflowTagApp.Core.Infrastructure.StackOverflow.Mappers;
public class StackOverflowTagMapper : IMapper<StackOverflowTag, double, TagEntity>
{
    public TagEntity Map(StackOverflowTag source, double populationSum)
    {
       if (source == null)
        {
            throw new ArgumentNullException(nameof(source), "Source cannot be null");
        }
        
        return new TagEntity
        {
            TagId = Guid.NewGuid(),
            LastActivityDate = source.LastActivityDate,
            HasSynonyms = source.HasSynonyms,
            IsModeratorOnly = source.IsModeratorOnly,
            IsRequired = source.IsRequired,
            Count = source.Count,
            PercentageOfTags = 100 * source.Count / populationSum,
            Name = source.Name,
        };

    }
}