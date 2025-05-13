namespace Million.Domain.Entities;
public sealed class Owner
{
    [BsonId]
    public ObjectId _id { get; set; }
    public string IdOwner { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Photo { get; set; }
    public DateTime Birthhday { get; set; }
}
