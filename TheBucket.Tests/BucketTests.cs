using Xunit;
using TheBucket.Models;
using TheBucket.Models.Interfaces;

namespace TheBucket.Tests
{
    public class BucketTests
    {
        [Fact]
        public void DefaultValueTest()
        {
            Bucket testContainer = new Bucket();

            Assert.Equal(12, testContainer.Capacity);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(16, 16)]
        [InlineData(double.MinValue, 10)]
        [InlineData(0, 10)]
        [InlineData(69.69, 69.69)]
        public void SetCapacityTest(double passedCapacity, double expectedCapacity)
        {
            Bucket testContainer = new Bucket(passedCapacity);

            Assert.Equal(expectedCapacity, testContainer.Capacity);
        }

        [Fact]
        public void AttemptSettingCapacityAfterInitTest()
        {
            Bucket testContainer = new Bucket(15);

            testContainer.Capacity = 30;

            Assert.Equal(15, testContainer.Capacity);

        }

        [Theory]
        [InlineData(1, -11)]
        [InlineData(5, -7)]
        [InlineData(12, 0)]
        [InlineData(13, 1)]
        [InlineData(69.69, 57.69)]

        public void GetOverflowTest(double fillVolume, double expectedOverflow)
        {
            Bucket testContainer = new Bucket();

            Assert.Equal(expectedOverflow, testContainer.GetOverflow(fillVolume));
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(13, 0)]
        [InlineData(69, 0)]
        [InlineData(-10, 0)]
        public void FillTest(double fillVolume, double expectedContents)
        {
            Bucket testContainer = new Bucket();

            testContainer.Fill(fillVolume);

            Assert.Equal(expectedContents, testContainer.Contents);
        }

        [Fact]
        public void EmptyTest()
        {
            Bucket testContainer = new Bucket(30, 15);

            testContainer.Empty();

            Assert.Equal(0, testContainer.Contents);
        }

        [Theory]
        [InlineData(5, FillProtocol.Cancel, 7)]
        [InlineData(10, FillProtocol.Cancel, 12)]
        [InlineData(10, FillProtocol.Fill, 2)]
        [InlineData(10, FillProtocol.Overflow, 2)]
        public void PourOutTest(double fillVolume, FillProtocol howToFill, double expectedContents)
        {
            Bucket testContainer1 = new Bucket();
            Bucket testContainer2 = new Bucket();

            testContainer1.Fill(12);
            testContainer2.Fill(6);

            testContainer1.Pour(fillVolume, testContainer2, howToFill);

            Assert.Equal(expectedContents, testContainer1.Contents);
        }

        [Theory]
        [InlineData(5, FillProtocol.Cancel, 11)]
        [InlineData(10, FillProtocol.Cancel, 6)]
        [InlineData(10, FillProtocol.Fill, 12)]
        [InlineData(10, FillProtocol.Overflow, 12)]
        public void PourInTest(double fillVolume, FillProtocol howToFill, double expectedContents)
        {
            Bucket testContainer1 = new Bucket();
            Bucket testContainer2 = new Bucket();

            testContainer1.Fill(12);
            testContainer2.Fill(6);

            testContainer1.Pour(fillVolume, testContainer2, howToFill);

            Assert.Equal(expectedContents, testContainer2.Contents);
        }
    }
}
