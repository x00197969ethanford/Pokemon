using System.Net.Http.Json;
using pokemon_project.Models;

namespace pokemon_project.Data
{
    public class PokemonService
    {
        private readonly HttpClient _http;

        private List<Pokemon>? _cachedPokemon;
        private readonly SemaphoreSlim _loadLock = new(1, 1);

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

        public int GetRandomId()
        {
            return new Random().Next(1, 898); // There are 898 pokemon
        }

        public async Task<List<Pokemon>> GetManyPokemonAsync(int count = 898)
        {
            if (_cachedPokemon != null && _cachedPokemon.Count > 0)
            {
                return _cachedPokemon;
            }

            await _loadLock.WaitAsync();
            try
            {
                if (_cachedPokemon != null && _cachedPokemon.Count > 0)
                {
                    return _cachedPokemon;
                }

                var pokemons = new List<Pokemon>(count);

                for (int i = 1; i <= count; i++)
                {
                    try
                    {
                        var match = await GetPokemonAsync(i.ToString());
                        if (match != null) pokemons.Add(match);
                    }
                    catch
                    {
                        // ignore errors for missing pokemon
                    }
                }

                _cachedPokemon = pokemons;
                return _cachedPokemon;
            }
            finally
            {
                _loadLock.Release();
            }
        }

        public (Pokemon best, List<(Pokemon match, double score)> top3)
            FindClosestMatches(
                List<Pokemon> pokemons,
                double userHeightCm,
                double userWeightKg)
        {
            var maches = pokemons.Select(match =>
            {
                double pokeHeight = match.Height * 10; // cm
                double pokeWeight = match.Weight / 10.0; // kg

                double score = Math.Abs(userHeightCm - pokeHeight) +
                               Math.Abs(userWeightKg - pokeWeight);

                return (match, score);

            }).OrderBy(s => s.score).ToList();

            var best = maches.First().match;
            var top3 = maches.Take(3).ToList();

            return (best, top3);
        }
    }
}
