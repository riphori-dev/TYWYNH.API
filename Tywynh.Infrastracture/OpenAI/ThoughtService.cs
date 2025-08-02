using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Tywynh.Domain.Interfaces;

public class ThoughtService : IUpliftingThoughtService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _url = "https://openrouter.ai/api/v1/chat/completions";

    public ThoughtService(IConfiguration config)
    {
        _apiKey = config["ApiKey"]!;

        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

        _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost"); // Replace with your domain or "http://localhost"
        _httpClient.DefaultRequestHeaders.Add("X-Title", "Tywynh API");
    }

    public async Task<string> GetUpliftingThoughtAsync(string userMessage)
    {
        var requestBody = new
        {
            model = "meta-llama/llama-3-8b-instruct",
            messages = new[]
            {
                new { role = "system", content = "You are an uplifting assistant who always responds with positive and encouraging thoughts. But keep it short, please." },
                new { role = "user", content = userMessage }
            },
            max_tokens = 150,
            temperature = 0.8
        };

        var requestJson = JsonSerializer.Serialize(requestBody);

        int maxRetries = 3;

        for (int attempt = 0; attempt <= maxRetries; attempt++)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            var errorText1 = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                using var document = JsonDocument.Parse(responseText);
                var content = document.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                return content?.Trim() ?? "No response received.";
            }

            if ((int)response.StatusCode == 429 && attempt < maxRetries)
            {
                int delaySeconds = (int)Math.Pow(2, attempt); // 1s, 2s, 4s...
                await Task.Delay(delaySeconds * 1000);
                continue;
            }
            else
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"OpenRouter API error: {response.StatusCode}\n{errorText}");
            }
        }

        throw new Exception("Failed after multiple retries due to rate limiting.");
    }
}
