namespace Municipality.Entities;

public class Employee : BaseEntity
{
    public string Fullname { get; set; }
    public string Content { get; set; }
    public byte[] Image { get; set; }
    public string Position { get; set; }
}