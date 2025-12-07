using System.Net.Http.Json;

namespace pokemon_project.Data
{
    public class PokemonService
    {
        private readonly HttpClient _http;

        public PokemonService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress ??= new Uri("https://pokeapi.co/api/v2/");
        }

        // Search
        public async Task<Pokemon?> GetPokemonAsync(string nameOrId)
        {
            if (string.IsNullOrWhiteSpace(nameOrId))
            {
                return null;
            } 

            nameOrId = nameOrId.ToLower().Trim();

            try
            {
                return await _http.GetFromJsonAsync<Pokemon>($"pokemon/{nameOrId}");
            }
            catch
            {
                return null;
            }
        }
    }
}