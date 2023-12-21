using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;
using AppAgendamentos.Services.Base;

namespace AppAgendamentos.Services;
public class UserService : Service<User>, IUserService
{
    public UserService(IRepository<User> repositoryBase) : base(repositoryBase)
    {
    }
    public override void Validate(User entity)
    {
        base.Validate(entity);

        if (entity.BirthDate > DateTime.Now)
            throw new Exception("Birth Date cannot be greater than today"
                + DateTime.Now.ToString("dd/MM/yyyy"));

        if (entity.Password != entity.ConfirmPassword)
            throw new Exception("Password and Confirm Password must be the same");

        if (entity.Password.Length < 8)
            throw new Exception("Password must be at least 8 characters");

        if (String.IsNullOrEmpty(entity.Email))
            throw new Exception("E-mail is required");

        if (String.IsNullOrEmpty(entity.Name))
            throw new Exception("Name is required");
    }
    public override Task SaveAsync(User entity)
    {
        this.Validate(entity);

        entity.Password = EncryptPassword(entity.Password);

        return base.SaveAsync(entity);
    }

    private static string EncryptPassword(string password)
    {
        if (String.IsNullOrEmpty(password)) throw new Exception("Password is required");
        byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
        data = System.Security.Cryptography.SHA256.HashData(data);
        return System.Text.Encoding.ASCII.GetString(data);
    }
}