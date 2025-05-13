using Million.Application.Common;

namespace Million.Application.Queries.GetPropertyQuery;
public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, List<PropertyDto>>
{
    private readonly IPropertyRepository _repository;

    public GetPropertiesQueryHandler(IPropertyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PropertyDto>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
    {
        var properties = await _repository.GetFilteredAsync(request.Name, request.Address, request.Owner, request.MaxPrice);
        if (properties == null)
            throw new NotFoundException(nameof(Property), request.Name);
        return properties.Select(p => new PropertyDto
        {
            _id = p._id.ToString(),
            IdProperty = p.IdProperty,
            Owner = new OwnerDto() { IdOwner = p.Owner.IdOwner, Name = p.Owner.Name },
            Name = p.Name,
            Address = p.Address,
            Price = p.Price,
            //TODO: ImageUrl = p.ImageUrl
        }).ToList();
    }
}
