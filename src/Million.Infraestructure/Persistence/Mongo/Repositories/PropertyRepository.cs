namespace Million.Infraestructure.Persistence.Mongo.Repositories;
public sealed class PropertyRepository : IPropertyRepository
{
    private readonly MillionMongoContext _context;

    #region constructor
    public PropertyRepository(MillionMongoContext context)
    {
        _context = context;
    }
    #endregion

    #region implement
    public async Task<IEnumerable<Property>> GetFilteredAsync(string name, string address, decimal? minPrice, decimal? maxPrice)
    {
        var filter = Builders<Property>.Filter.Empty;

        if (!string.IsNullOrEmpty(name))
            filter &= Builders<Property>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));

        if (!string.IsNullOrEmpty(address))
            filter &= Builders<Property>.Filter.Regex(p => p.Address, new MongoDB.Bson.BsonRegularExpression(address, "i"));

        if (minPrice.HasValue)
            filter &= Builders<Property>.Filter.Gte(p => p.Price, minPrice);

        if (maxPrice.HasValue)
            filter &= Builders<Property>.Filter.Lte(p => p.Price, maxPrice);

        return await _context.Properties.Find(filter).ToListAsync();
    }
    #endregion
}
