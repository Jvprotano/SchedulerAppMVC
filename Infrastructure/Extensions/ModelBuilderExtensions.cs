using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
***REMOVED***public static void ApplySnakeCaseNamingConvention(this ModelBuilder modelBuilder)
***REMOVED***{
***REMOVED***    modelBuilder.ApplySnakeCaseNamingConventionForEntities();
***REMOVED***    modelBuilder.ApplySnakeCaseNamingConventionForProperties();
***REMOVED***}

***REMOVED***private static void ApplySnakeCaseNamingConventionForEntities(this ModelBuilder modelBuilder)
***REMOVED***{
***REMOVED***    foreach (var entity in modelBuilder.Model.GetEntityTypes())
***REMOVED***    {
***REMOVED******REMOVED***entity.SetTableName(entity.GetTableName().ToSnakeCase());
***REMOVED***    }
***REMOVED***}

***REMOVED***private static void ApplySnakeCaseNamingConventionForProperties(this ModelBuilder modelBuilder)
***REMOVED***{
***REMOVED***    foreach (var entity in modelBuilder.Model.GetEntityTypes())
***REMOVED***    {
***REMOVED******REMOVED***foreach (var property in entity.GetProperties())
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    property.SetColumnName(property.GetColumnName().ToSnakeCase());
***REMOVED******REMOVED***}
***REMOVED***    }
***REMOVED***}

***REMOVED***private static string? ToSnakeCase(this string? input)
***REMOVED***{
***REMOVED***    if (string.IsNullOrEmpty(input))
***REMOVED***    {
***REMOVED******REMOVED***return input;
***REMOVED***    }

***REMOVED***    var result = new StringBuilder();
***REMOVED***    var lastChar = char.MinValue;

***REMOVED***    foreach (var character in input)
***REMOVED***    {
***REMOVED******REMOVED***if (char.IsUpper(character))
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    if (result.Length > 0 && lastChar != '_')
***REMOVED******REMOVED***    {
***REMOVED******REMOVED******REMOVED***result.Append('_');
***REMOVED******REMOVED***    }

***REMOVED******REMOVED***    result.Append(char.ToLowerInvariant(character));
***REMOVED******REMOVED***}
***REMOVED******REMOVED***else
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    result.Append(character);
***REMOVED******REMOVED***}

***REMOVED******REMOVED***lastChar = character;
***REMOVED***    }

***REMOVED***    return result.ToString();
***REMOVED***}
    }
}