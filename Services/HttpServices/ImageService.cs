using AppAgendamentos.Contracts.HttpServices;

using Newtonsoft.Json.Linq;

namespace AppAgendamentos.Services.HttpServices;
public class ImageService : IImageService
{
    private string _imgBbAPiKey;
    private string _imgBbUrl;

    public ImageService(IConfiguration configuration)
    {
        _imgBbAPiKey = configuration["ImgBb:ApiKey"];
        _imgBbUrl = configuration["ImgBb:Url"];
    }

    public async Task<string> UploadImage(string imageString)
    {
        // TODO: Upload to a cloud storage service instead of ImgBB
        string apiUrl = _imgBbUrl;

        using HttpClient client = new HttpClient();
        using MultipartFormDataContent content = new MultipartFormDataContent
        {
            { new StringContent(_imgBbAPiKey), "key" },
            { new StringContent(imageString), "image" }
        };

        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            // Read and parse the JSON response content
            string responseContent = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseContent);

            // Check if the response contains the "url" property
            if (jsonResponse["data"]?["url"] != null)
            {
                // Extract the URL
                string imageUrl = jsonResponse["data"]["url"].ToString();
                return imageUrl;
            }
            else
            {
                throw new Exception("Error: Response does not contain the expected URL property.");
            }
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }

}