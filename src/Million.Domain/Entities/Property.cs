namespace Million.Domain.Entities;
public sealed class Property
{
    public string IdProperty { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string CodeInternal { get; set; }
    public string Year { get; set; }
    public string IdOwner { get; set; }

}
