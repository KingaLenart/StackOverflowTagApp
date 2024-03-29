using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Models;
using StackOverflowTagApp.Core.Services.Models;
using StackOverflowTagApp.Core.SQL;
using System.Text.Json;

namespace StackOverflowTagApp.Core.Services.Implementations
{
    public class StackOverflowReadTagsService : TagMapper
    {
        private readonly HttpClient _httpClient;
        private readonly TagWriteRepository _tagWriteRepository;
        public StackOverflowReadTagsService(IHttpClientFactory httpClientFactory, TagWriteRepository tagWriteRepository)
        {
            _httpClient = httpClientFactory.CreateClient("StackOverflowClient");
            _tagWriteRepository = tagWriteRepository;
        }

        public async Task<List<StackOverflowTag>> GetTagsAsync()
        {
            int pageNumberMax = 4;
            int pageSize = 100;
            var allTags = new List<StackOverflowTag>();

            for (int pageNumber = 1; pageNumber <= pageNumberMax; pageNumber++)
            {
                var tags = await GetTagsPerPageAsync(pageNumber, pageSize);
                allTags.AddRange(tags);
                await Task.Delay(1000);
            }

            await _tagWriteRepository.TagCreateAsync(allTags);
            return allTags;
        }

        public async Task<List<StackOverflowTag>> GetTagsPerPageAsync(int pageNumber, int pageSize)
        {
            var response = await _httpClient.GetAsync($"tags?order=desc&sort=popular&site=stackoverflow&pagesize={pageSize}&page={pageNumber}");
            response.EnsureSuccessStatusCode();
            string responseBodyJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var tagResponse = JsonSerializer.Deserialize<StackOverflowTagApiResponse>(responseBodyJson, options);

            return tagResponse.Items;
        }

       
    }
}