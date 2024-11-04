using BlazorServerApp.Components;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IEnumerable<Customer>>(sp => new List<Customer>
{
    new Customer { Id = 1, Name = "Customer 1" },
    new Customer { Id = 2, Name = "Customer 2" },
    new Customer { Id = 3, Name = "Customer 3" },
    new Customer { Id = 4, Name = "Customer 4" },
    new Customer { Id = 5, Name = "Customer 5" },
});

builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
 
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

app.Run();
