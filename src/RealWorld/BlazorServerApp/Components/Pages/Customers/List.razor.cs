using Domain.Models;

namespace BlazorServerApp.Components.Pages.Customers;

public partial class List
{
    private IQueryable<Customer> customers;
    
    protected override void OnInitialized()
    {
        customers = Repository.GetAll();
    }
}
