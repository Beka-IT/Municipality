namespace Municipality.Entities;

public class Region : BaseEntity
{
    public string Title { get; set; }
    public ICollection<District>? Districts { get; set; }
}