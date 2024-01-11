namespace BuberDinner.Infrastructure.AppSettings;

public class MongoSettings
{
    public const string SectionName = "MongoDBSettings";
    public string ConnectionString { get; init; } = null!;
    public string DatabaseName { get; init; } = null!;
}
