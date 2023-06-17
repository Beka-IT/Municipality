using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Enums;
using Municipality.Models;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class RoundsCotrolller: ControllerBase
{
    private readonly AppDbContext _db;

    public RoundsCotrolller(AppDbContext context)
    {
        _db = context;
    }

    [HttpPost]
    public void Start(RoundModel model)
    {
        var round = new Round
        {
            Title = model.Title,
            StartDate = model.StartDate,
            CoastForAnHectare = model.CoastForAnHectare,
            VillageId = model.VillageId,
            Status = IrrigationStatusType.Appointed
        };

        var agricultureAreaIds = _db.AgricultureAreas
            .Where(x => x.VillageId == model.VillageId)
            .Select(x => x.Id)
            .ToArray();

        var agricultureLands = _db.AgriculturalLands
            .Where(x => agricultureAreaIds.Contains(x.AgricultureAreaId))
            .ToArray();

        round.Irrigations = new List<Irrigation>();

        foreach (var agricultureLand in agricultureLands)
        {
            var startDate = round.StartDate;
            if (round.Irrigations.Count > 0)
            {
                startDate = round.Irrigations.Last().EndDate;
            }
            round.Irrigations.Add(new Irrigation()
            {
                RoundId = round.Id,
                AgriculturalLandId = agricultureLand.LandQueueNumber,
                Status = IrrigationStatusType.Appointed,
                Cost = round.CoastForAnHectare * agricultureLand.Area,
                StartDate = startDate,
                EndDate = startDate.AddHours(Convert.ToInt32(agricultureLand.Area))
            });
        }
        
        _db.Add(round);
        _db.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<Round> GetForVillage(int villageId)
    {
        return _db.Rounds
            .Include(x => x.Irrigations)
            .AsNoTracking()
            .Where(x => x.VillageId == villageId)
            .ToArray();
    }
}