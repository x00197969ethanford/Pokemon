using System.Net.Http.Json;
using pokemon_project.Models;

namespace pokemon_project.Data
{
    public class PokemonService
    {
        private readonly HttpClient _http;

        private List<Pokemon>? _cachedPokemon;
        private readonly SemaphoreSlim _loadLock = new(1, 1);
        private static readonly Random _random = new();

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
            return _random.Next(1, 898); // There are 898 pokemon
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
            (Pokemon match, double score)? first = null;
            (Pokemon match, double score)? second = null;
            (Pokemon match, double score)? third = null;

            foreach (var p in pokemons)
            {
                double pokeHeight = p.Height * 10;
                double pokeWeight = p.Weight / 10.0;

                double score =
                    Math.Abs(userHeightCm - pokeHeight) +
                    Math.Abs(userWeightKg - pokeWeight);

                if (first == null || score < first.Value.score)
                {
                    third = second;
                    second = first;
                    first = (p, score);
                }
                else if (second == null || score < second.Value.score)
                {
                    third = second;
                    second = (p, score);
                }
                else if (third == null || score < third.Value.score)
                {
                    third = (p, score);
                }
            }

            return (
                first!.Value.match,
                new List<(Pokemon match, double score)>
                {
                    first!.Value,
                    second!.Value,
                    third!.Value
                }
            );
        }
    }
}
