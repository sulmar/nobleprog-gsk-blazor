
using BlazorServerApp.Hubs;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace BlazorServerApp.BackgroundServices;

public class MeasureBackgroundService : BackgroundService
{
    private readonly IHubContext<MeasuresHub> hubContext;
    private Random _random = new Random();

    public MeasureBackgroundService(IHubContext<MeasuresHub> hubContext)
    {
        this.hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var duration = _random.Next(1000, 3000);

            await Task.Delay(duration);

            Measure measure = new Measure ("Temperature Room 1", _random.Next(20, 100), "C");

            Console.WriteLine($"Send {measure}");

            await hubContext.Clients.All.SendAsync("ReceivedMeasure", measure);
        }
    }
}
