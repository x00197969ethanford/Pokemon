using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PokemonProject.Tests
{
    public class UiTests
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
    }
}
