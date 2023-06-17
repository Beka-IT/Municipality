using Microsoft.EntityFrameworkCore;
using Municipality.Entities;
using WorkerService.Configurations;
using WorkerService.Constants;
using WorkerService.Data;

namespace WorkerService.Processes;

public class InformatorProcesor
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
                var irrigations = _dbContext.Irrigations.AsNoTracking().ToArray();
                if (irrigations is not null)
                {
                    foreach (var irrigation in irrigations)
                    {
                        if (!irrigation.IsMessageSended && IsTimeToInformUserToPay(irrigation.StartDate))
                        {
                            var cost = irrigation.Cost;
                            var pin = _dbContext.AgriculturalLands
                                .FirstOrDefault(x => x.LandQueueNumber == irrigation.AgriculturalLandId).OwnerPin;
                            
                            var user = _dbContext.Users.FirstOrDefault(x => x.Pin == pin);
                            var message = new Message()
                            {
                                AddresseePin = user.Pin,
                                Text = $"Урматтуу, {user.Fullname}!Сиз суугары системасында алдынкы кезектесиз! Андыктан кеч калбай толонуз!/n" +
                                       "Реквизит: 118 0000 137 330 483/n" +
                                       $"Сумма: {cost} сом.",
                                CreatedAt = DateTime.Now
                            };

                            irrigation.IsMessageSended = true;
                            _dbContext.Messages.Add(message);
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
    private bool IsTimeToInformUserToPay(DateTime startDate)
    {
        TimeSpan differenceOfDates = startDate - DateTime.Now;
        return differenceOfDates.TotalDays < TimeComponentConstants.OverdueTimeToInformInDays;
    }
}