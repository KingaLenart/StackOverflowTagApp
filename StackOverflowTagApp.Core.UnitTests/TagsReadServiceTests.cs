using Moq;
using NUnit.Framework;
using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Application.Services;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Domain.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;

namespace StackOverflowTagApp.Core.UnitTests;

[TestFixture]
public class TagsReadServiceTests
{
    private Mock<ITagReadRepository> _mockRepository;
    private Mock<IMapper<TagEntity, TagOutDto>> _mockMapper;
    private TagsReadService _service;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ITagReadRepository>();
        _mockMapper = new Mock<IMapper<TagEntity, TagOutDto>>();
        _service = new TagsReadService(_mockRepository.Object, _mockMapper.Object);
    }

    [Test]
    public void GetTagsPageAsync_InvalidPageNumber_ThrowsArgumentException()
    {
        var pagingRequestModel = new SortPagingInfo { PageNumber = 0, PageSize = 10, OrderBy = "name", SortDirection = SortDirection.Ascending };

        Assert.ThrowsAsync<ArgumentException>(() => _service.GetTagsPageAsync(pagingRequestModel));
    }

    [Test]
    public void GetTagsPageAsync_InvalidOrderBy_ThrowsArgumentException()
    {
        var pagingRequestModel = new SortPagingInfo { PageNumber = 1, PageSize = 10, OrderBy = "count", SortDirection = SortDirection.Ascending };

        Assert.ThrowsAsync<ArgumentException>(() => _service.GetTagsPageAsync(pagingRequestModel));
    }

    [Test]
    public async Task GetTagsPageAsync_ValidRequest_ReturnsCorrectData()
    {
        // Arrange
        var pagingRequestModel = new SortPagingInfo { PageNumber = 1, PageSize = 10, OrderBy = "name", SortDirection = SortDirection.Ascending };
        var tagList = new List<TagEntity> { new TagEntity { Name = "C#", PercentageOfTags = 10 } };
        var tagDtoList = new List<TagOutDto> { new TagOutDto { Name = "C#", PercentageOfTags = 10 } };

        _mockRepository.Setup(r => r.GetPagedTagsAsync(pagingRequestModel))
            .ReturnsAsync(tagList);
        _mockRepository.Setup(r => r.GetTotalCountAsync())
            .ReturnsAsync(1);
        _mockMapper.Setup(m => m.Map(It.IsAny<TagEntity>()))
            .Returns((TagEntity source) => new TagOutDto { Name = source.Name, PercentageOfTags = source.PercentageOfTags });

        // Act
        var result = await _service.GetTagsPageAsync(pagingRequestModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.TotalCount, Is.EqualTo(1));
        Assert.That(result.Collection.ToList()[0].Name, Is.EqualTo(tagDtoList[0].Name));
        Assert.That(result.Collection.ToList()[0].PercentageOfTags, Is.EqualTo(tagDtoList[0].PercentageOfTags));
        Assert.That(result.PageSize, Is.EqualTo(10));
        Assert.That(result.TotalPage, Is.EqualTo(1));
    }

    [Test]
    public async Task GetTagsPageAsync_Request_ReturnsCorrectData()
    {
        // Arrange
        var pagingRequestModel = new SortPagingInfo { PageNumber = 1, PageSize = 10, OrderBy = "percentageOfTags", SortDirection = SortDirection.Ascending };
        var tagList = new List<TagEntity> { new TagEntity { Name = "C#", PercentageOfTags = 10 } };
        var tagDtoList = new List<TagOutDto> { new TagOutDto { Name = "C#", PercentageOfTags = 10 }};

        _mockRepository.Setup(r => r.GetPagedTagsAsync(pagingRequestModel))
            .ReturnsAsync(tagList);
        _mockRepository.Setup(r => r.GetTotalCountAsync())
            .ReturnsAsync(1);
        _mockMapper.Setup(m => m.Map(It.IsAny<TagEntity>()))
            .Returns((TagEntity source) => new TagOutDto { Name = source.Name, PercentageOfTags = source.PercentageOfTags });

        // Act
        var result = await _service.GetTagsPageAsync(pagingRequestModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.PageNumber, Is.EqualTo(pagingRequestModel.PageNumber), "The PageNumber should match the request model.");
        Assert.That(result.PageSize, Is.EqualTo(pagingRequestModel.PageSize));
    }

    [Test]
    public async Task GetTagsPageAsync_InncorrectPageSize_ChangeToCorrectPageSize()
    {
        // Arrange
        var pagingRequestModel = new SortPagingInfo { PageNumber = 1, PageSize = 101, OrderBy = "name", SortDirection = SortDirection.Ascending };
        var tagList = new List<TagEntity> { new TagEntity { Name = "C#", PercentageOfTags = 10 } };
        var tagDtoList = new List<TagOutDto> { new TagOutDto { Name = "C#", PercentageOfTags = 10 } };

        _mockRepository.Setup(r => r.GetPagedTagsAsync(pagingRequestModel))
            .ReturnsAsync(tagList);
        _mockRepository.Setup(r => r.GetTotalCountAsync())
            .ReturnsAsync(1);
        _mockMapper.Setup(m => m.Map(It.IsAny<TagEntity>()))
            .Returns((TagEntity source) => new TagOutDto { Name = source.Name, PercentageOfTags = source.PercentageOfTags });

        // Act
        var result = await _service.GetTagsPageAsync(pagingRequestModel);

        //Assert
        Assert.That(result.PageSize.Equals(100), Is.EqualTo(true));
    }
}
