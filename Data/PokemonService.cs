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
    }
}