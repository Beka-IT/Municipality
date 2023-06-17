namespace Municipality.Models;

public class CreatePaymentModel
{
    public int IrrigationId { get; set; }
    public int SenderId { get; set; }
    public IFormFile ReceiptImage { get; set; }
}