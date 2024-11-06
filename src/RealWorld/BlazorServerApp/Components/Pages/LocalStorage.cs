using Microsoft.JSInterop;

namespace BlazorServerApp.Components.Pages;

public class LocalStorage
{
    private readonly IJSRuntime jS;

    public LocalStorage(IJSRuntime JS)
    {
        jS = JS;
    }

    public async Task SetItem(string key, string value)
    {
        await jS.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task<string> GetItem(string key)
    {
        return await jS.InvokeAsync<string>("localStorage.getItem", key);
    }

}
