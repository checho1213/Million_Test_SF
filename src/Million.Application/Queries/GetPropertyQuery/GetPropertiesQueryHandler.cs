using Million.Application.Common;
using static System.Net.Mime.MediaTypeNames;

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
        //return properties.Select(p => new PropertyDto
        //{
        //    _id = p._id.ToString(),
        //    IdProperty = p.IdProperty,
        //    Owner = new OwnerDto() { IdOwner = p.Owner.IdOwner, Name = p.Owner.Name },
        //    Name = p.Name,
        //    Address = p.Address,
        //    Price = p.Price,
        //    Images = p.Images
        //.Where(img => img.IdProperty == p.IdProperty)
        //.Select(img => new ImagesProperty
        //{

        //    File = img.File,
        //    ThumbnailImageSrc = img.ThumbnailImageSrc,

        //})
        //.ToList()
        //}).ToList();

        var result = properties.Select(p => new PropertyDto
        {
            _id = p._id.ToString(),
            IdProperty = p.IdProperty,
            Owner = new OwnerDto
            {
                IdOwner = p.Owner?.IdOwner,
                Name = p.Owner?.Name
            },
            Name = p.Name,
            Address = p.Address,
            Price = p.Price,
            Images = p.Images
        .Where(img => img.IdProperty == p.IdProperty)
        .Select(img => new ImagesProperty
        {
            
            File = img.File,
            ThumbnailImageSrc = img.ThumbnailImageSrc,
            
        })
        .Distinct() // Evita duplicados en las imágenes (si aplica)
        .ToList()
        })
.DistinctBy(p => p.IdProperty) // Elimina duplicados basados en IdProperty
.ToList();

        return result;

    }
}
