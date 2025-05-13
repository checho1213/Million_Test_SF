namespace Million.Infraestructure.Persistence.Mongo.Context;
public sealed class MillionMongoContext
{
    private readonly IMongoDatabase _database;

    public MillionMongoContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["Mongo:Connection"]);
        _database = client.GetDatabase(configuration["Mongo:Database"]);
    }

    public IMongoCollection<Property> Properties => _database.GetCollection<Property>("properties");
    public IMongoCollection<PropertyImages> PropertyImages => _database.GetCollection<PropertyImages>("propertyImages");
    public IMongoCollection<PropertyTrace> PropertyTraces => _database.GetCollection<PropertyTrace>("PropertyTrace");
    public IMongoCollection<Owner> Owners => _database.GetCollection<Owner>("owners");
}
