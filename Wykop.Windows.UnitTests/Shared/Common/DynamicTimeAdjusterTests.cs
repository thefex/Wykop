using NUnit.Framework;
using Wykop.Common;

namespace Wykop.Windows.UnitTests.Shared.Common
{
    [TestFixture]
    public class DynamicTimeAdjusterTests
    {
        readonly TimeInterval mockedTimeInterval = new TimeInterval(20, 120);
        readonly int timeIntervalCenterInMs = 70; // (120-20)/2 + 20
        private readonly double exponentBase = 2.0;
        private readonly double increaseByValue = 5.0;
        private DynamicTimeAdjuster systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new DynamicTimeAdjuster(mockedTimeInterval, 2d, increaseByValue);
        }

        [Test]
        public void WhenCreated_TimeShouldBeEqualToHalfOfPassedTimeInterval()
        {
            Assert.AreEqual(timeIntervalCenterInMs, systemUnderTest.CurrentTime.TotalMilliseconds);
        }

        [Test]
        public void DecreaseTime_TimeShouldBeDecreasedByHalfOfInterval()
        {
            systemUnderTest.DecreaseTime();
            Assert.AreEqual(20, systemUnderTest.CurrentTime.TotalMilliseconds, "Half of interval wasn't substracted."); // 70 - 50 = 20
        }

        [Test]
        public void DecreaseTime_DecreasedTimeShouldNeverBeLessThanIntervalMinimum()
        {
            for (int i=0; i<5; ++i)
                systemUnderTest.DecreaseTime();

            Assert.AreEqual(mockedTimeInterval.Minimum.TotalMilliseconds, systemUnderTest.CurrentTime.TotalMilliseconds, 
                "Time was decreased too much(expected time interval minimum)");
        }

        [Test]
        public void IncreaseTime_TimeShouldBeIncreasedInExponentialManner() // by powers of two
        {
            double startTimeInMs = systemUnderTest.CurrentTime.TotalMilliseconds; // 70;
            // 5, 10, 20, 40, 80, .. expontent growth.
            systemUnderTest.IncreaseTime();
            Assert.AreEqual(startTimeInMs+5, systemUnderTest.CurrentTime.TotalMilliseconds);

            systemUnderTest.IncreaseTime();
            Assert.AreEqual(startTimeInMs + 5+10, systemUnderTest.CurrentTime.TotalMilliseconds);

            systemUnderTest.IncreaseTime();
            Assert.AreEqual(startTimeInMs + 5+10+20, systemUnderTest.CurrentTime.TotalMilliseconds);
        }

        [Test]
        public void IncreaseTime_IncreasedTimeShouldNeverBeBiggerThanIntervalMaximum()
        {
            for (int i=0; i<10; ++i)
                systemUnderTest.IncreaseTime();

            Assert.AreEqual(mockedTimeInterval.Maximum.TotalMilliseconds, systemUnderTest.CurrentTime.TotalMilliseconds);
        }

        [Test]
        public void DecreaseTimeShouldResetIncreaseTimeToStartValue()
        {
            for (int i=0; i<3; ++i)
                systemUnderTest.IncreaseTime();

            systemUnderTest.DecreaseTime();

            double currentTimeInMs = systemUnderTest.CurrentTime.TotalMilliseconds;
            systemUnderTest.IncreaseTime();

            Assert.AreEqual(currentTimeInMs+5, systemUnderTest.CurrentTime.TotalMilliseconds);
        }
    }
}