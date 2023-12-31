namespace Municipality.Entities;

public class AgricultureArea : BaseEntity
{
    public string Title { get; set; }
    public decimal Area { get; set; }
    public int VillageId { get; set; }
    public ICollection<AgriculturalLand>? AgriculturalLands { get; set; }
}