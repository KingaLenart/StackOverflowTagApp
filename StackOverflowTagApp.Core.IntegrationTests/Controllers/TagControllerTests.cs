using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;
using System.Net;
using System.Text;

namespace StackOverflowTagApp.Core.IntegrationTests.Controllers;

[TestFixture]
public class TagControllerTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task SyncTags_EndpointReturnsSuccess()
    {
        // Act
        var response = await _client.PostAsync("/Tag/sync", null);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var tags = JsonConvert.DeserializeObject<List<StackOverflowTag>>(content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task Paged_EndpointReturnsSuccessAndCorrectNumbersData()
    {
        // Arrange
        var sortPagingInfo = new SortPagingInfo
        {
            PageNumber = 1,
            PageSize = 10,
            OrderBy = "Name",
            SortDirection = SortDirection.Ascending
        };
        var content = new StringContent(JsonConvert.SerializeObject(sortPagingInfo), Encoding.UTF8, "application/json");

        //// Act
        var response = await _client.PostAsync("/Tag/paged", content);

        //// Assert
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var pagedResult = JsonConvert.DeserializeObject<PagedCollectionOutDto<TagOutDto>>(responseContent);
        
        Assert.That("result", Is.Not.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(pagedResult?.PageNumber, Is.EqualTo(1));
        Assert.That(pagedResult?.PageSize, Is.EqualTo(10));
        Assert.That(pagedResult?.Collection.Count, Is.LessThanOrEqualTo(10));
    }
}
