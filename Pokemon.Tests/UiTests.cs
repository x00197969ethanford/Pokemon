using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PokemonProject.Tests
{
    public class UiTests : IAsyncLifetime
    {
        private IPlaywright _playwright = null!;
        private IBrowser _browser = null!;

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }
        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

    }
}
