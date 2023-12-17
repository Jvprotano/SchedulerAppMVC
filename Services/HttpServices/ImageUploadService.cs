using AppAgendamentos.Contracts.HttpServices;

using Azure.Storage.Blobs;

using System.Text.RegularExpressions;

namespace AppAgendamentos.Services.HttpServices;
public class ImageUploadService : IImageUploadService
{
    private readonly string _azureStorage;
    private readonly string _azureContainer;

    public ImageUploadService(IConfiguration configuration)
    {
        _azureStorage = configuration["AzureCfg:StorageCfg"];
        _azureContainer = configuration["AzureCfg:Container"];
    }

    public async Task<string> UploadImage(string imageBase64)
    {
        string fileName = Guid.NewGuid().ToString() + ".jpg";
        var data = new Regex(@"data:image\/[a-z]+;base64, ").Replace(imageBase64, "");

        byte[] bytes = Convert.FromBase64String(data);

        var blobClient = new BlobClient(_azureStorage, _azureContainer, fileName);

        using (var strem = new MemoryStream(bytes))
        {
            await blobClient.UploadAsync(strem);
        }

        return blobClient.Uri.AbsoluteUri;
    }
}