using Konyvtar_nyilvantarto.Blazor;
using Konyvtar_nyilvantarto.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7073") });
builder.Services.AddScoped<ILibraryMemberService, LibraryMemberService>();
await builder.Build().RunAsync();
