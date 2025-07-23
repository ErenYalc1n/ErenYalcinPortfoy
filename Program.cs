using ErenYalcinPortfoy;
using ErenYalcinPortfoy.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<I18nService>();

var host = builder.Build();
var i18n = host.Services.GetRequiredService<I18nService>();

await i18n.InitAsync();
await host.RunAsync();
