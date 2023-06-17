using Microsoft.EntityFrameworkCore;
using Municipality.Entities;
using Municipality.Enums;
using WorkerService.Configurations;
using WorkerService.Constants;
using WorkerService.Data;

namespace WorkerService.Processes;

public class RoundsStatusTrackerProcessor
{
    private AppDbContext _dbContext;

    private DbContextOptions<AppDbContext> GetAllOptions()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite( AppSettings.ConnectionString);
        return optionsBuilder.Options;
    }

    public void Run(ILogger<Worker> logger)
    {
        using (_dbContext = new AppDbContext(GetAllOptions()))
        {
            try
            {
                var rounds = _dbContext.Rounds
                    .Include(x => x.Irrigations)
                    .ToArray();
                if (rounds is not null)
                {
                    foreach (var round in rounds)
                    {
                        CheckRoundToStatus(round);
                    }
                    _dbContext.SaveChanges();
                    logger.LogInformation("The operation executed at: {time}", DateTimeOffset.Now);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    private void CheckRoundToStatus(Round round)
    {
        if (round.StartDate < DateTime.Now)
        {
            var lastirrgation = round.Irrigations.LastOrDefault();
            if (lastirrgation.EndDate > DateTime.Now)
            {
                round.Status = IrrigationStatusType.InProcess;
                return;
            }

            round.Status = IrrigationStatusType.Finished;

        }
    }
}