using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
public static void ApplySnakeCaseNamingConvention(this ModelBuilder modelBuilder)
{
    modelBuilder.ApplySnakeCaseNamingConventionForEntities();
    modelBuilder.ApplySnakeCaseNamingConventionForProperties();
}

private static void ApplySnakeCaseNamingConventionForEntities(this ModelBuilder modelBuilder)
{
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
entity.SetTableName(entity.GetTableName().ToSnakeCase());
    }
}

private static void ApplySnakeCaseNamingConventionForProperties(this ModelBuilder modelBuilder)
{
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
foreach (var property in entity.GetProperties())
{
    property.SetColumnName(property.GetColumnName().ToSnakeCase());
}
    }
}

private static string ToSnakeCase(this string input)
{
    var reservedNames = new List<string>{ "CNPJ", "CPF"};
    
    if (string.IsNullOrEmpty(input))
    {
return input;
    }

    if (reservedNames.Contains(input.ToUpper()))
    {
return input.ToLower();
    }

    var result = new StringBuilder();
    var lastChar = char.MinValue;

    foreach (var character in input)
    {
if (char.IsUpper(character))
{
    if (result.Length > 0 && lastChar != '_')
    {
result.Append('_');
    }

    result.Append(char.ToLowerInvariant(character));
}
else
{
    result.Append(character);
}

lastChar = character;
    }

    return result.ToString();
}
    }
}