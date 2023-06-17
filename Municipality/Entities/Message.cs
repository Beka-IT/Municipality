namespace Municipality.Entities;

public class Message : BaseEntity
{
    public string Text { get; set; }
    public string AddresseePin { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool IsViewed { get; set; }
}