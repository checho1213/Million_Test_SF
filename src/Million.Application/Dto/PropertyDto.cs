namespace Million.Application.Dto;
public sealed class PropertyDto
{
    public string _id { get; set; }
    public string IdProperty { get; set; }
    public OwnerDto Owner { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }    
}

public sealed class OwnerDto
{
    public string IdOwner { get; set; }
    public string Name { get; set; }
    public decimal Photo { get; set; }
}