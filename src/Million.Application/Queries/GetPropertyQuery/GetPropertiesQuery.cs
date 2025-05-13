
namespace Million.Application.Queries.GetPropertyQuery;
public class GetPropertiesQuery : IRequest<List<PropertyDto>>
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Owner { get; set; }
    public decimal? MaxPrice { get; set; }
}
