using Municipality.Enums;

namespace Municipality.Entities;

public class Round : BaseEntity
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public decimal CoastForAnHectare { get; set; }
    public int VillageId { get; set; }
    public IrrigationStatusType Status { get; set; }
    public ICollection<Irrigation>? Irrigations { get; set; }
}