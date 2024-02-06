namespace PracticeBackgroundService;

public class SecondBackground : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(true)
        {
            await LoopHundered();
            await Task.Delay(1000);
        }
    }

    private async Task LoopHundered()
    {
        for(int i = 0; i < 100; i++)
        {
            await Console.Out.WriteLineAsync($"2 - background service - {i} ni chop etdi");

            await Task.Delay(1000);
        }
    }
}
