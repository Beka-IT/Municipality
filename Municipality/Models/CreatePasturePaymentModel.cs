namespace Municipality.Models;

public class CreatePasturePaymentModel
{
    public int PastureId { get; set; }
    public string SenderPin { get; set; }
    public IFormFile ReceiptImage { get; set; }
}