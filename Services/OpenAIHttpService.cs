using AppAgendamentos.Contracts.HttpServices;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AppAgendamentos.Services;
public class OpenAIHttpService : IOpenAIProxy
{
    readonly HttpClient _httpClient;

    readonly string _subscriptionId;

    readonly string _apiKey;

    public OpenAIHttpService(IConfiguration configuration)
    {
        //👇 reading settings from the configuration file
        var openApiUrl = configuration["OpenAi:Url"] ?? throw new ArgumentException(nameof(configuration));
        _httpClient = new HttpClient { BaseAddress = new Uri(openApiUrl) };

        _subscriptionId = configuration["OpenAi:SubscriptionId"];
        _apiKey = configuration["OpenAi:ApiKey"];
    }

    public async Task<GenerateImageResponse> GenerateImages(GenerateImageRequest prompt, CancellationToken cancellation = default)
    {
        // using var rq = new HttpRequestMessage(HttpMethod.Post, "/v1/images/generations");

        // var jsonRequest = JsonSerializer.Serialize(prompt, new JsonSerializerOptions
        // {
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        // });

        // //serialize the content to JSON and set the correct content type
        // rq.Content = new StringContent(jsonRequest);
        // rq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        // //👇 Including the Authorization Header with API Key
        // var apiKey = _apiKey;
        // rq.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        // //👇 Including the Subscription Id Header
        // // var subscriptionId = _subscriptionId;
        // // rq.Headers.TryAddWithoutValidation("OpenAI-Organization", subscriptionId);

        // var response = await _httpClient.SendAsync(rq, HttpCompletionOption.ResponseHeadersRead, cancellation);

        // response.EnsureSuccessStatusCode();

        // var content = response.Content;

        // var jsonResponse = await content.ReadFromJsonAsync<GenerateImageResponse>(cancellationToken: cancellation);

        // return jsonResponse;


        string url = "https://api.openai.com/v1/images/generations";
        string bearerToken = _apiKey;// Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string body = "{\"model\": \"dall-e-3\",\"prompt\": \"an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail\",\"n\": 1,\"size\": \"1024x1024\"}";

        // Prepare data for the POST request
        var data = new StringContent(body, Encoding.UTF8, "application/json");

        // Create HttpClient instance
        using (HttpClient client = new HttpClient())
        {
            // Set authentication header
            if (bearerToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            }

            // Perform request
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();

                // Retrieve response content
                string responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Request response: " + response.StatusCode);

                // Deserialize JSON
                dynamic responseJson = JsonSerializer.Deserialize<dynamic>(responseString);
                // Rest of your code using responseJson
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        return null;
    }
}