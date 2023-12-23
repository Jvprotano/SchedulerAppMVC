using AppAgendamentos.Contracts.Services;

namespace AppAgendamentos.Services;
public class UserService : IUserService
{
    private static string EncryptPassword(string password)
    {
        if (String.IsNullOrEmpty(password)) throw new Exception("Password is required");
        byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
        data = System.Security.Cryptography.SHA256.HashData(data);
        return System.Text.Encoding.ASCII.GetString(data);
    }
}