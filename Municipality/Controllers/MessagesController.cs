using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Municipality.Data;
using Municipality.Entities;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class MessagesController: ControllerBase
{
    private readonly AppDbContext _db;

    public MessagesController(AppDbContext context)
    {
        _db = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<Message> GetByUserId(int id)
    {
        return _db.Messages.Where(x => x.Addressee == id).ToArray();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void SendWarning(int userId, int irrrigationId)
    {
        var cost = _db.Irrigations.Find(irrrigationId).Cost;
        var fullname = _db.Users.Find(userId).Fullname;
        var message = new Message()
        {
            Addressee = userId,
            Text = $"Урматтуу, {fullname}!Сиз суугары системасында алдынкы кезектесиз! Андыктан кеч калбай толонуз!/n" +
                   "Реквизит: 118 0000 137 330 483/n" +
                   $"Сумма: {cost} сом.",
            CreatedAt = DateTime.Now
        };
        
        _db.Messages.Add(message);
        _db.SaveChanges();
    }
}