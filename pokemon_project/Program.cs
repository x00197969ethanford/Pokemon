using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using pokemon_project;
using pokemon_project.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://pokeapi.co/api/v2/") });

builder.Services.AddScoped<PokemonService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
