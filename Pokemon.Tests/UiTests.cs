using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PokemonProject.Tests
{
    public class UiTests : IAsyncLifetime
    {
        private IPlaywright play = null!;
        private IBrowser browser = null!;

        public async Task InitializeAsync()
        {
            play = await Playwright.CreateAsync();
            browser = await play.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true 
            });
        }

        public async Task DisposeAsync()
        {
            await browser.CloseAsync();
            play.Dispose();
        }

        [Fact]
        public async Task HomePage()
        {
            var page = await browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5136");

            string title = await page.TitleAsync();

            Assert.Contains("Pokemon Project", title);
        }

        [Fact]
        public async Task SearchPage_ShouldReturnPokemon()
        {
            var page = await browser.NewPageAsync();
        }
    }
}
