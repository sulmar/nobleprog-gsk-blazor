using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp.Hubs;

public class MeasuresHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Connected: {this.Context.ConnectionId}");

        this.Groups.AddToGroupAsync(Context.ConnectionId, "Room1");

        return base.OnConnectedAsync();
    }
}
