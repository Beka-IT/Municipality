namespace Municipality.Entities;

public class Village : BaseEntity
{
    public string Title { get; set; }
    public int DistrictId { get; set; }
    public ICollection<AgricultureArea>? AgricultureAreas { get; set; }
}