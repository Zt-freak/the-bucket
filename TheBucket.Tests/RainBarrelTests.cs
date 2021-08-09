using Xunit;
using TheBucket.Models;
using TheBucket.Models.Interfaces;

namespace TheBucket.Tests
{
    public class RainBarrelTests
    {
        [Fact]
        public void DefaultValueTest()
        {
            RainBarrel testContainer = new RainBarrel();

            Assert.Equal(80, testContainer.Capacity);
        }

        [Theory]
        [InlineData(RainBarrelVolume.Small, 80)]
        [InlineData(RainBarrelVolume.Medium, 100)]
        [InlineData(RainBarrelVolume.Large, 120)]
        public void SetCapacityTest(RainBarrelVolume passedCapacity, double expectedCapacity)
        {
            RainBarrel testContainer = new RainBarrel(passedCapacity);

            Assert.Equal(expectedCapacity, testContainer.Capacity);
        }
    }
}
