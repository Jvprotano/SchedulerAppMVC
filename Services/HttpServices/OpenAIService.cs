using AppAgendamentos.Contracts.HttpServices;
using System.Reflection;

namespace AppAgendamentos.Services.HttpServices;
public class OpenAIService : IOpenAIService
{
    public async Task<string> GetUrlNewImageAsync(string userPrompt)
    {
        var config = BuildConfig();

        IOpenAIProxy aiClient = new OpenAIHttpService(config);

        var nImages = int.Parse(config["OpenAi:DALL-E:N"]);
        var imageSize = config["OpenAi:DALL-E:Size"];
        var prompt = new GenerateImageRequest(userPrompt, nImages, imageSize);

        var result = await aiClient.GenerateImages(prompt);

        var selectedResult = result.Data.FirstOrDefault();

        if (selectedResult is null)
            return string.Empty;

        return selectedResult.Url;
    }

    static IConfiguration BuildConfig()
    {
        var dir = Directory.GetCurrentDirectory();
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(dir, "appsettings.json"), optional: false)
            .AddUserSecrets(Assembly.GetExecutingAssembly());

        return configBuilder.Build();
    }
}

public interface IOpenAIService
{
    Task<string> GetUrlNewImageAsync(string userPrompt);
}