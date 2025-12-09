using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PokemonProject.Tests
{
    public class UiTests
    {
        private IPlaywright play;
        private IBrowser browser;

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
