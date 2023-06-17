using Municipality.Entities.PastureModule;

namespace Municipality.Entities;

public class Village : BaseEntity
{
    public string Title { get; set; }
    public int DistrictId { get; set; }
    public bool IsPastureTime { get; set; }
    public ICollection<AgricultureArea>? AgricultureAreas { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Round>? Rounds { get; set; }
    public ICollection<Pasture>? Pastures { get; set; }
}