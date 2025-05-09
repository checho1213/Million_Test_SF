namespace Million.Application.Interfaces;
public  interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetFilteredAsync(
            string name,
            string address,
            decimal? minPrice,
            decimal? maxPrice
        );
}
