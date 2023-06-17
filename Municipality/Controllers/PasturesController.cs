using Microsoft.AspNetCore.Mvc;
using Municipality.Data;
using Municipality.Entities.PastureModule;
using Municipality.Enums.Pastures;
using Municipality.Helpers;
using Municipality.Models;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class PasturesController: ControllerBase
{
    private readonly AppDbContext _db;

    public PasturesController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    public IEnumerable<Pasture> GetByVillageId(int id)
    {
        var village = _db.Villages.FirstOrDefault(x => x.Id == id);
        if (!village.IsPastureTime) throw new AppException("Жайыт сезону баштала элек!");
        return _db.Pastures
            .Where(x => x.VillageId == id)
            .ToArray();
    }

    [HttpPost]
    public PastureRoundDetails GetForUser(List<PastureDetailsCounting> pets)
    {
        double smallPets = pets.Where(x => IsSmallPet(x.Type)).Sum(x => x.Size);
        double bigPets = pets.Where(x => !IsSmallPet(x.Type)).Sum(x => x.Size);
        var result = new PastureRoundDetails
        {
            Area = smallPets * 0.2 + bigPets,
            Coast = smallPets * 12 + bigPets * 60
        };
        return result;
    }

    [NonAction]
    private bool IsSmallPet(PastureType type)
    {
        return type == PastureType.Sheep || type == PastureType.Goat;
    }
}