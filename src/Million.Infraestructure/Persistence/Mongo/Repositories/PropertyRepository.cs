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
        var builder = Builders<Property>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(name))
            filter &= builder.Regex(p => p.Name, new BsonRegularExpression(name, "i"));

        if (!string.IsNullOrEmpty(address))
            filter &= builder.Regex(p => p.Address, new BsonRegularExpression(address, "i"));

        if (minPrice.HasValue)
            filter &= builder.Gte(p => p.Price, minPrice.Value);

        if (maxPrice.HasValue)
            filter &= builder.Lte(p => p.Price, maxPrice.Value);

        var result = await _context.Properties
            .Aggregate()
            .Match(filter)
            .Lookup<Property, Owner, Property>(
                foreignCollection: _context.Owners,
                localField: p => p.IdOwner,
                foreignField: o => o.IdOwner,
                @as: p => p.Owner)
            .Unwind(p => p.Owner, new AggregateUnwindOptions<Property> { PreserveNullAndEmptyArrays = true })
            .ToListAsync();

        return result;

    }
    #endregion
}
