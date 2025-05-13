namespace Million.Domain.Entities;

public sealed class PropertyImages
{
    [BsonId]
    public ObjectId _id { get; set; }
    public string IdProperty { get; set; }
    public string File { get; set; }
    public string ThumbnailImageSrc { get; set; }
    public bool Enabled { get; set; }
}
