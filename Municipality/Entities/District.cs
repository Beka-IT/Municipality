namespace Municipality.Entities;

public class District : BaseEntity
{
    public string Title { get; set; }
    public int RegionId { get; set; }
    public ICollection<Village>? Villages { get; set; }
}