
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrastructure.AppSettings;
using BuberDinner.Infrastructure.Persistence.MongoDB.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
    
namespace BuberDinner.Infrastructure.Persistence.MongoDB.Context;

public class MongoDbContext
{
    public IMongoDatabase Database { get; set; }

    public MongoDbContext(IOptions<MongoSettings> settings)
    {
        //https://www.mongodb.com/docs/drivers/csharp/current/fundamentals/connection/connection-options/#std-label-csharp-connection-options
        //var settings = new MongoClientSettings()
        //{
        //    Scheme = ConnectionStringScheme.MongoDBPlusSrv,
        //    Server = new MongoServerAddress("sample.host", 27017),
        //    ConnectTimeout = new TimeSpan(0, 0, 60),
        //    UseTls = true
        //};
        var client = new MongoClient(settings.Value.ConnectionString);
        Database = client.GetDatabase(settings.Value.DatabaseName);

        UserMongoConfigurations.Register();
        MenuMongoConfigurations.Register();
    }

    public IMongoCollection<User> Users => Database.GetCollection<User>("users");
    public IMongoCollection<Menu> Menus => Database.GetCollection<Menu>("menus");


}
