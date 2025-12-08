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
        }
    }
}
