using Municipality.Enums;

namespace Municipality.Entities.PastureModule;

public class PasturePayment : BaseEntity
{
    public int PastureId { get; set; }
    public decimal Area { get; set; }
    public string SenderPin { get; set; }
    public byte[] ReceiptImage { get; set; }
    public DateTime? CreatedAt { get; set; }
    public PaymentStatusType Status { get; set; }
}