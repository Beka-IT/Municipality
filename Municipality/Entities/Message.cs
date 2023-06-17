namespace Municipality.Entities;

public class Message : BaseEntity
{
    public string Text { get; set; }
    public int Addressee { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool IsViewed { get; set; }
}