using Municipality.Enums;

namespace Municipality.Entities;

public class Irrigation : BaseEntity
{
    public int RoundId { get; set; }
    public int AgriculturalLandId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Cost { get; set; }
    public bool IsPaid { get; set; }
    public bool IsMessageSended { get; set; }
    public IrrigationStatusType Status { get; set; }
}