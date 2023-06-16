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
    public IEnumerable<Region> GetAll()
    {
        return _db.Regions.Include(x => x.Districts).ThenInclude(x => x.Villages).ToArray();
    }
}