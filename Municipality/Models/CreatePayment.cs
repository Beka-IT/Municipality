namespace Municipality.Models;

public class CreatePaymentModel
{
    public int IrrigationId { get; set; }
    public string SenderPin { get; set; }
    public IFormFile ReceiptImage { get; set; }
}