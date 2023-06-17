using System.ComponentModel.DataAnnotations;

namespace Municipality.Entities;

public class AgriculturalLand
{
    [Key]
    public int LandQueueNumber { get; set; }
    public decimal Area { get; set; }
    public int AgricultureAreaId { get; set; }
    public string? OwnerPin { get; set; }
}