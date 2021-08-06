using Xunit;
using TheBucket.Models;
using TheBucket.Models.Interfaces;

namespace TheBucket.Tests
{
    public class OilBarrelTests
    {
        [Fact]
        public void DefaultValueTest()
        {
            OilBarrel testContainer = new OilBarrel();

            Assert.Equal(159, testContainer.Capacity);
        }

        [Fact]
        public void AttemptSettingCapacityAfterInitTest()
        {
            OilBarrel testContainer = new OilBarrel();

            testContainer.Capacity = 30;

            Assert.Equal(159, testContainer.Capacity);

        }
    }
}
