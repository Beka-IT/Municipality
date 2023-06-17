using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Enums;
using Municipality.Helpers;
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
    
    [HttpGet]
    public void Stop(int roundId)
    {
        var round = _db.Rounds.Find(roundId);
        round.StoppedAt = DateTime.Now;
        round.Status = IrrigationStatusType.Stoped;
        _db.SaveChanges();
    }
    
    [HttpGet]
    public void Continue(int roundId)
    {
        var round = _db.Rounds
            .Include(x => x.Irrigations)
            .FirstOrDefault(x => x.Id == roundId);
        
        if (round.Status is not IrrigationStatusType.Stoped)
        {
            throw new AppException("Кезек токтокогон эмес, ошол себептен улантуу мумкун эмес!");
        }
        
        round.ContinuedAt = DateTime.Now;
        round.Status = IrrigationStatusType.InProcess;
        TimeSpan? timeInterval = round.StoppedAt - round.StoppedAt;
        
        foreach (var irrigation in round.Irrigations)
        {
            irrigation.StartDate = irrigation.StartDate.AddMinutes(timeInterval?.TotalMinutes ?? 0);
            irrigation.EndDate = irrigation.EndDate.AddMinutes(timeInterval?.TotalMinutes ?? 0);
            _db.Update(irrigation);
        }

        round.StoppedAt = round.ContinuedAt = null;
        _db.SaveChanges();
    }
}