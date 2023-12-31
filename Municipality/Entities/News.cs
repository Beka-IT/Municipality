namespace Municipality.Entities;

public class News : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; }
}