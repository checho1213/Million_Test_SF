namespace Million.Application.Interfaces;
public  interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetFilteredAsync(
            string name,
            string address,
            string? owner,
            decimal? maxPrice
        );
}
