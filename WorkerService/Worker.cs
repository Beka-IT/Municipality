using WorkerService.Constants;
using WorkerService.Processes;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    public delegate void ProcessorDelegaete(ILogger<Worker> logger);

    private readonly RoundsStatusTrackerProcessor _roundsStatusTrackerProcessor = new RoundsStatusTrackerProcessor();
    private readonly CleanerProcessor _cleanerProcessor = new CleanerProcessor();
    private readonly InformatorProcesor _informatorProcesor = new InformatorProcesor();
    private readonly CompletedIrrigationCleaner _completedIrrigationCleaner = new CompletedIrrigationCleaner();

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            ProcessorDelegaete processorDelegaete = new ProcessorDelegaete(_cleanerProcessor.Run);
            processorDelegaete += _informatorProcesor.Run;
            processorDelegaete += _completedIrrigationCleaner.Run;
            processorDelegaete += _roundsStatusTrackerProcessor.Run;
            processorDelegaete.Invoke(_logger);
            await Task.Delay(TimeComponentConstants.DelayInMilliSeconds, stoppingToken);
        }
    }
}