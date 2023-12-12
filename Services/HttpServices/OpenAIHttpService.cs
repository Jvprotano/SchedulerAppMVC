using AppAgendamentos.Contracts.HttpServices;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace AppAgendamentos.Services.HttpServices;
public class OpenAIHttpService : IOpenAIProxy
{
    readonly string _apiKey;
    readonly string _httpClient;

    public OpenAIHttpService(IConfiguration configuration)
    {
        //👇 reading settings from the configuration file
        _httpClient = configuration["OpenAi:Url"] ?? throw new ArgumentException(nameof(configuration));
        _apiKey = configuration["OpenAi:ApiKey"];
    }

    public async Task<GenerateImageResponse> GenerateImages(GenerateImageRequest prompt, CancellationToken cancellation = default)
    {
        string url = _httpClient;
        string bearerToken = _apiKey;
        string body = $"{{\"prompt\": \"{prompt.Prompt}\"}}";

        // Prepare data for the POST request
        var data = new StringContent(body, Encoding.UTF8, "application/json");

        // Create HttpClient instance
        using HttpClient client = new HttpClient();
        // Set authentication header
        if (bearerToken != null)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        // Perform request
        try
        {
            HttpResponseMessage response = await client.PostAsync(url, data);
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;

                var jsonResponse = await content.ReadFromJsonAsync<GenerateImageResponse>(cancellationToken: cancellation);

                return jsonResponse;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }
}