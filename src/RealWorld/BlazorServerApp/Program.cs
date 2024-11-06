using BlazorServerApp;
using BlazorServerApp.BackgroundServices;
using BlazorServerApp.Components;
using BlazorServerApp.Components.Pages;
using BlazorServerApp.Hubs;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IEnumerable<Customer>>(sp => new List<Customer>
{
    new Customer { Id = 1, Name = "Customer 1" },
    new Customer { Id = 2, Name = "Customer 2" },
    new Customer { Id = 3, Name = "Customer 3" },
    new Customer { Id = 4, Name = "Customer 4" },
    new Customer { Id = 5, Name = "Customer 5" },
});

builder.Services.AddScoped<IEnumerable<User>>(sp => new List<User>
{
    new User { Id = 1, FirstName = "a", LastName = "b", Email = "a.b@domain.com" },
    new User { Id = 2, FirstName = "b", LastName = "d", Email = "b.d@domain.com" },
    new User { Id = 3, FirstName = "e", LastName = "f", Email = "e.f@domain.com" },
});

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddScoped<IUserRepository, FakeUserResopitory>();

builder.Services.AddSingleton<ApplicationState>();

builder.Services.AddSignalR();

// TODO: Pobierz adres bazowy ze zmiennej 
builder.Services.AddSingleton<HubConnection>(sp => new HubConnectionBuilder()
        .WithUrl("https://localhost:7118/signalr/measures")
        .WithAutomaticReconnect()
        .Build());
 
builder.Services.AddHostedService<MeasureBackgroundService>();

builder.Services.AddScoped<LocalStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<MeasuresHub>("/signalr/measures");

app.Run();
