using Microsoft.AspNetCore.Mvc;
using Municipality.Data;
using Municipality.Entities.PastureModule;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class PetsController: ControllerBase
{
    private readonly AppDbContext _db;

    public PetsController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    public IEnumerable<Pet> GetPetsByOwnerPin(string pin)
    {
        return _db.Pets
            .Where(x => x.OwnerPin == pin)
            .ToArray();
    }
}