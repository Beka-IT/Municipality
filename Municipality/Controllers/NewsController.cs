using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Models;

namespace Municipality.Controllers;

[Microsoft.AspNetCore.Mvc.Route("[controller]/[action]")]
[ApiController]
public class NewsController: ControllerBase
{
    private readonly AppDbContext _db;

    public NewsController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet("{id}")]
    public News Get(int id)
    {
        return _db.News.Find(id);
    }
    
    [HttpGet]
    public IEnumerable<News> GetAll()
    {
        return _db.News.ToArray();
    }

    [HttpPost]
    public IActionResult Create([FromBody]CreateNewsModel newsRequest )
    {
        if (newsRequest is null)
        {
            return BadRequest();
        }

        var news = new News()
        {
            Title = newsRequest.Title,
            Content = newsRequest.Content,
            CreatedAt = DateTime.Now,
            Image = newsRequest.Image
        };

        _db.News.Add(news);
        _db.SaveChanges();

        return Ok("Added succesfully");
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var news = _db.News.Find(id);
        
        if (news is null)
        {
            return BadRequest();
        }
        _db.Remove(news);
        _db.SaveChanges();

        return Ok("Deleted succesfully");
    }
}