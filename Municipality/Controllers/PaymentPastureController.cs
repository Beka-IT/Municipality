using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Entities.PastureModule;
using Municipality.Enums;
using Municipality.Models;

namespace Municipality.Controllers;

public class PaymentPastureController: ControllerBase
{
    private readonly AppDbContext _db;

    public PaymentPastureController(AppDbContext context)
    {
        _db = context;
    }

    [AllowAnonymous]
    [HttpPost]
    public void Create([FromForm]CreatePasturePaymentModel model)
    {
        var payment = new PasturePayment()
        {
            PastureId = model.PastureId,
            ReceiptImage = null,
            Status = PaymentStatusType.NotViewed,
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
    public IEnumerable<PasturePayment> GetAll()
    {
        return _db.PasturePayments.AsNoTracking().ToArray();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void Adopt(int id)
    {
        var payment = _db.PasturePayments.Find(id);
        payment.Status = PaymentStatusType.Adopted;
        var user = _db.Users.FirstOrDefault(x => x.Pin == payment.SenderPin);
        var message = new Message()
        {
            AddresseePin = user.Pin,
            Text = $"Урматтуу, {user.Fullname}!Сиздин жайыт боюнча толомунуз ийгиликтуу кабыл алынды!",
            CreatedAt = DateTime.Now
        };
        
        _db.Messages.Add(message);
        _db.SaveChanges();
        _db.SaveChanges();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void Reject(int id)
    {
        var payment = _db.PasturePayments.Find(id);
        payment.Status = PaymentStatusType.Rejected;
        var user = _db.Users.FirstOrDefault(x => x.Pin == payment.SenderPin);
        var message = new Message()
        {
            AddresseePin = user.Pin,
            Text = $"Урматтуу, {user.Fullname}!Сиздин жайыт боюнча толомунуз ишенимдуу деп эсептелген жок!",
            CreatedAt = DateTime.Now
        };
        
        _db.Messages.Add(message);
        _db.SaveChanges();
    }
}