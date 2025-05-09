namespace Million.Domain.Entities;
public sealed class PropertyTrace
{
    public string IdPropertyTrace { get; set; }
    public DateTime DateSale { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Tax { get; set; }
    public string IdProperty { get; set; }

}
