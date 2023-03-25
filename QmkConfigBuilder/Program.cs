using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QmkConfigBuilder;
using QmkConfigBuilder.Models.Json.Serializer;
using QmkConfigBuilder.StateContainer;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IJsonSerializer, JsonSerializer>();
builder.Services.AddSingleton<IKeyboardStateContainer, KeyboardStateContainer>();
builder.Services.AddSingleton<IMatrixStateContainer>(x => x.GetRequiredService<IKeyboardStateContainer>());
builder.Services.AddSingleton<ILayoutStateContainer>(x => x.GetRequiredService<IKeyboardStateContainer>());

await builder.Build().RunAsync();
