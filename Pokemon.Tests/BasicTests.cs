using Xunit;
using pokemon_project.Data;


namespace PokemonProject.Tests
{
    public class HeightTest
    {
        [Fact]
        public void HeightConversion()
        {
            double feet = 5;
            double inches = 10;

            double cm = ((feet * 12) + inches) * 2.54;

            Assert.Equal(177.8, cm, precision: 1);
        }
    }

    public class ClosestMatchTests
    {
        [Fact]
        public void FindClosestMatches_ReturnsTop3SortedByScore()
        {
            List<Pokemon> pokemons = new()
        {
            new Pokemon { Name = "A", Height = 10, Weight = 10 },
            new Pokemon { Name = "B", Height = 20, Weight = 20 },
            new Pokemon { Name = "C", Height = 30, Weight = 30 },
            new Pokemon { Name = "D", Height = 40, Weight = 40 },
        };

            var service = new PokemonService(new HttpClient());

            var result = service.FindClosestMatches(pokemons, 200, 20);

            var top3 = result.top3;

            Assert.Equal(3, top3.Count); // needs 3 rresults
            Assert.True(top3[0].score <= top3[1].score);
            Assert.True(top3[1].score <= top3[2].score);
        }
    }

    public class PokemonSearchTest
    {
        [Fact]
        public void SearchPokemon()
        {
            
        }
    }
}
