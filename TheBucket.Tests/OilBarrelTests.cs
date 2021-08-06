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
    }
}
