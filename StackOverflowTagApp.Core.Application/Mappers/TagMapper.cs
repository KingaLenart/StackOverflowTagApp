using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;

namespace StackOverflowTagApp.Core.Application.Mappers;

public class TagMapper : IMapper<TagEntity, TagOutDto>
{
    public TagOutDto Map(TagEntity source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source), "Source cannot be null");
        }
        return new TagOutDto
        {
            TagId = source.TagId,
            LastActivityDate = source.LastActivityDate,
            HasSynonyms = source.HasSynonyms,
            IsModeratorOnly = source.IsModeratorOnly,
            IsRequired = source.IsRequired,
            Count = source.Count,
            PercentageOfTags = source.PercentageOfTags,
            Name = source.Name,
        };
    }

    
}
