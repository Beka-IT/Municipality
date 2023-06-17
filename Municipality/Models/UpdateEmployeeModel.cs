namespace Municipality.Models;

public class UpdateEmployeeModel
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Content { get; set; }
    public IFormFile Image { get; set; }
    public string Position { get; set; }
}