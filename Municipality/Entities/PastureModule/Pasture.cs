using Municipality.Enums.Pastures;

namespace Municipality.Entities.PastureModule;

public class Pasture : BaseEntity
{
    public string Title { get; set; }
    public decimal Area { get; set; }
    public decimal CurrentFreeArea { get; set; }
    public int VillageId { get; set; }
    public ICollection<PasturePayment>? PasturePayments { get; set; }
}