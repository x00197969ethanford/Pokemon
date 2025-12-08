using Xunit;

namespace Pokemon.Tests
{
    public class BasicTests
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
}
