namespace Scheduler.Contracts.HttpServices;
public interface IImageUploadService
{
    Task<string> UploadImage(string imageBase64);
}