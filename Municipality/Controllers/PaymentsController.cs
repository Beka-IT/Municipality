using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Enums;
using Municipality.Models;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class PaymentsController: ControllerBase
{
    private readonly AppDbContext _db;

    public PaymentsController(AppDbContext context)
    {
        _db = context;
    }

    [AllowAnonymous]
    [HttpPost]
    public void Create([FromForm]CreatePaymentModel model)
    {
        var payment = new IrrigationPayment()
        {
            IrrigationId = model.IrrigationId,
            ReceiptImage = null,
            Type = PaymentStatusType.NotViewed,
            CreatedAt = DateTime.Now,
            SenderPin = model.SenderPin
        };
        
        using (var ms = new MemoryStream())
        {
            model.ReceiptImage.CopyTo(ms);

            payment.ReceiptImage = ms.ToArray();
        }

        _db.Add(payment);
        _db.SaveChanges();
    }

    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<IrrigationPayment> GetAll()
    {
        return _db.IrrigationPayments.AsNoTracking().ToArray();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void Adopt(int id)
    {
        var payment = _db.IrrigationPayments.Find(id);
        payment.Type = PaymentStatusType.Adopted;
        _db.SaveChanges();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void Reject(int id)
    {
        var payment = _db.IrrigationPayments.Find(id);
        payment.Type = PaymentStatusType.Rejected;
        _db.SaveChanges();
    }
}