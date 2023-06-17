using Microsoft.EntityFrameworkCore;
using Municipality.Entities;
using WorkerService.Configurations;
using WorkerService.Constants;
using WorkerService.Data;

namespace WorkerService.Processes;

public class CleanerProcessor
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
                            if (IsNotPaidOnTime(irrigation))
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
        private bool IsNotPaidOnTime(Irrigation irrigation)
        {
            if (irrigation.IsPaid) return true;
            TimeSpan differenceOfDates = irrigation.StartDate - DateTime.Now;
            return differenceOfDates.TotalHours < TimeComponentConstants.TimeLimitInHours;
        }
    }