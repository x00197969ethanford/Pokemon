using System.Text.Json.Serialization;

namespace pokemon_project.Data
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonTypeSlot> Types { get; set; } = new();

        [JsonPropertyName("stats")]
        public List<PokemonStat> Stats { get; set; } = new();

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; } = new();

    }

    public class PokemonTypeSlot
    {
        [JsonPropertyName("type")]
        public NamedApiResource Type { get; set; } = new NamedApiResource();
    }

    public class NamedApiResource
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class PokemonStat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("stat")]
        public NamedApiResource Stat { get; set; } = new();
    }

    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }
    }

}