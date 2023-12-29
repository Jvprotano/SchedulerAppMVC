namespace Scheduler.Contracts.HttpServices;
public interface IOpenAIProxy
{
    //👇 Send the Prompt Text with and return a list of image URLs
    Task<GenerateImageResponse> GenerateImages(
        GenerateImageRequest prompt,
        CancellationToken cancellation = default);
}
public record class GenerateImageRequest(
    string Prompt,
    int imagesNumber,
    string Size,
    string Model = "dall-e-3",
    string ResponseFormat = "b64_json");

public record class GenerateImageResponse(
    long Created,
    GeneratedImageData[] Data);

public record class GeneratedImageData(string B64_json);