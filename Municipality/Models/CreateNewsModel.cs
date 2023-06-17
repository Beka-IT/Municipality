namespace Municipality.Models;

public class CreateNewsModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile Image { get; set; }
}