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
        [InlineData(1, 80)]
        [InlineData(80, 80)]
        [InlineData(100, 100)]
        [InlineData(120, 120)]
        [InlineData(double.MinValue, 80)]
        [InlineData(100.45, 80)]
        public void SetCapacityTest(double passedCapacity, double expectedCapacity)
        {
            RainBarrel testContainer = new RainBarrel(passedCapacity);

            Assert.Equal(expectedCapacity, testContainer.Capacity);
        }

        [Fact]
        public void AttemptSettingCapacityAfterInitTest()
        {
            RainBarrel testContainer = new RainBarrel(80);

            testContainer.Capacity = 30;

            Assert.Equal(80, testContainer.Capacity);

        }
    }
}
