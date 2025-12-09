using System.Threading.Tasks;
using Microsoft.Playwright;
using System;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new()
{
    Headless = false,
});
var context = await browser.NewContextAsync();

var page = await context.NewPageAsync();
await page.GotoAsync("http://localhost:5136/pokemon");
await page.GetByRole(AriaRole.Textbox, new() { Name = "Enter Pokemon name or ID..." }).ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Enter Pokemon name or ID..." }).FillAsync("pikachu");
await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
await page.GetByRole(AriaRole.Heading, new() { Name = "pikachu (25)" }).ClickAsync();
await page.GetByRole(AriaRole.Button, new() { Name = "Random" }).ClickAsync();
await page.GetByText("Height:").ClickAsync();
await page.GetByRole(AriaRole.Link, new() { Name = "Match Me" }).ClickAsync();
await page.GetByRole(AriaRole.Spinbutton).First.ClickAsync();
await page.GetByRole(AriaRole.Spinbutton).First.PressAsync("ArrowUp");
await page.GetByRole(AriaRole.Spinbutton).First.FillAsync("1");
await page.GetByRole(AriaRole.Spinbutton).First.PressAsync("ArrowUp");
await page.GetByRole(AriaRole.Spinbutton).First.FillAsync("2");
await page.GetByRole(AriaRole.Spinbutton).First.PressAsync("ArrowUp");
await page.GetByRole(AriaRole.Spinbutton).First.FillAsync("3");
await page.GetByRole(AriaRole.Spinbutton).First.PressAsync("ArrowUp");
await page.GetByRole(AriaRole.Spinbutton).First.FillAsync("4");
await page.GetByRole(AriaRole.Spinbutton).First.PressAsync("ArrowUp");
await page.GetByRole(AriaRole.Spinbutton).First.FillAsync("5");
await page.GetByRole(AriaRole.Spinbutton).Nth(1).ClickAsync();
await page.GetByRole(AriaRole.Spinbutton).Nth(1).FillAsync("10");
await page.GetByRole(AriaRole.Spinbutton).Nth(2).ClickAsync();
await page.GetByRole(AriaRole.Spinbutton).Nth(2).FillAsync("60");
await page.GetByRole(AriaRole.Button, new() { Name = "Find My Pokémon" }).ClickAsync();
await page.GetByRole(AriaRole.Heading, new() { Name = "Your Closest Match: golbat" }).ClickAsync();
await page.GetByRole(AriaRole.Img).First.ClickAsync();
