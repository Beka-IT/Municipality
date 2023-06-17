using Municipality.Enums.Pastures;

namespace Municipality.Entities.PastureModule;

public class Pet : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
    public PastureType Type { get; set; }
    public int OwnerId { get; set; }
}