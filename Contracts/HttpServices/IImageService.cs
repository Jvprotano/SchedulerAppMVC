namespace AppAgendamentos.Contracts.HttpServices;
public interface IImageService
{
    Task<string> UploadImage(string imageString);
}