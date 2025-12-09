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

    }
}
