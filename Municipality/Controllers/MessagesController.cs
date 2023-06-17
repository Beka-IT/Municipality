using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IEnumerable<Message> GetByUserPin(string pin)
    {
        return _db.Messages
            .AsNoTracking()
            .Where(x => x.AddresseePin == pin)
            .ToArray();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public void SendWarning(string pin, int irrrigationId)
    {
        var cost = _db.Irrigations.Find(irrrigationId).Cost;
        var user = _db.Users.FirstOrDefault(x => x.Pin == pin);
        var message = new Message()
        {
            AddresseePin = user.Pin,
            Text = $"Урматтуу, {user.Fullname}!Сиз суугары системасында алдынкы кезектесиз! Андыктан кеч калбай толонуз!/n" +
                   "Реквизит: 118 0000 137 330 483/n" +
                   $"Сумма: {cost} сом.",
            CreatedAt = DateTime.Now
        };
        
        _db.Messages.Add(message);
        _db.SaveChanges();
    }
}