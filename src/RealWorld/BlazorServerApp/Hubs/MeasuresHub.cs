using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp.Hubs;

public class MeasuresHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Connected: {this.Context.ConnectionId}");

        return base.OnConnectedAsync();
    }
}
