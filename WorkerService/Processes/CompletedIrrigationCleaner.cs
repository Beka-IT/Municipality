using Microsoft.EntityFrameworkCore;
using WorkerService.Configurations;
using WorkerService.Constants;
using WorkerService.Data;

namespace WorkerService.Processes;

public class CompletedIrrigationCleaner
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
                var irrigations = _dbContext.Irrigations.ToArray();
                if (irrigations is not null)
                {
                    foreach (var irrigation in irrigations)
                    {
                        if (IsCompletedIrrigation(irrigation.EndDate))
                        {
                            _dbContext.Remove(irrigation);
                        }
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
    private bool IsCompletedIrrigation(DateTime endDate)
    {
        var result = endDate < DateTime.Now;
        return result;
    }
}