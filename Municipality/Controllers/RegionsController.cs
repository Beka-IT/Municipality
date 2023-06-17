using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality.Data;
using Municipality.Entities;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly AppDbContext _db;

    public RegionsController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public Village GetVillage(int id)
    {
        return _db.Villages
            .Include(x => x.AgricultureAreas)
            .ThenInclude(x => x.AgriculturalLands)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<Region> GetAll()
    {
        return _db.Regions
            .Include(x => x.Districts)
            .ThenInclude(x => x.Villages)
            .ToArray();
    }

    [HttpGet]
    [AllowAnonymous]
    public void StartPastureSeason(int villageId)
    {
        var village = _db.Villages.FirstOrDefault(x => x.Id == villageId);
        village.IsPastureTime = true;
        _db.SaveChanges();
    }
}