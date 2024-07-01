using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using mshdemo3;
using mshdemo3.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.meshcapade.com/api/v1/") });
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<AvatarService>();
builder.Services.AddScoped<CommonAvtarService>();
builder.Services.AddScoped<AvatarVideoService>();
await builder.Build().RunAsync();
