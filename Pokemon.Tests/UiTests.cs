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
        public async Task SearchPage()
        {
            var page = await browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5136/pokemon");

            await page.FillAsync("input[type=text]", "pikachu");

            await page.ClickAsync("button");

            string content = await page.ContentAsync().ConfigureAwait(false);
            Assert.Contains("pikachu", content.ToLower());
        }
    }
}
