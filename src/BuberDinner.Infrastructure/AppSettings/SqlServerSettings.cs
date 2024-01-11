namespace BuberDinner.Infrastructure.AppSettings;

public class SqlServerSettings
{
    public const string SectionName = "SqlServerSettings";
    public string ConnectionString { get; init; } = null!;
}
