using Municipality.Enums;

namespace Municipality.Entities;

public class IrrigationPayment : BaseEntity
{
    public int IrrigationId { get; set; }
    public byte[] ReceiptImage { get; set; }
    public PaymentStatusType Type { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int SenderId { get; set; }
}