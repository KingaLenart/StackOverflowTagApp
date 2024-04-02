using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Domain;

namespace StackOverflowTagApp.Core.Application.Mappers;

public class TagMapper
{
    public TagOutDto MapTag(TagEntity tagEntity)
    {
        return new TagOutDto
        {
            TagId = tagEntity.TagId,
            LastActivityDate = tagEntity.LastActivityDate,
            HasSynonyms = tagEntity.HasSynonyms,
            IsModeratorOnly = tagEntity.IsModeratorOnly,
            IsRequired = tagEntity.IsRequired,
            Count = tagEntity.Count,
            PercentageOfTags = tagEntity.PercentageOfTags,
            Name = tagEntity.Name,
        };
    }
}
