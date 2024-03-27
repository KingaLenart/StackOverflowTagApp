using StackOverflowTagApp.Core.SQL;

namespace StackOverflowTagApp.Core.Services
{
    public class StackOverflowReadTagsService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        public StackOverflowReadTagsService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task FetchTagsAsync()
        {
            string url = "https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&site=stackoverflow";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }
    }

}
