using System;
using System.Diagnostics.Contracts;
using Windows.UI.Xaml.Input;

namespace Wykop.Common
{
    public class DynamicTimeAdjuster
    {
        private readonly double _increaseByExponentBase;
        private readonly TimeInterval _timeInterval;
        private const double StartIncreasingByValue = 5.0;

        private double currentlyIncreasingBy = StartIncreasingByValue;

        public DynamicTimeAdjuster(TimeInterval timeInterval, double increaseByExponentBase = 2.0)
        {
            Contract.Assert(increaseByExponentBase > 1.0,
                "It's increasing exponent base, it needs to be bigger than 1.0.");

            _timeInterval = timeInterval;
            _increaseByExponentBase = increaseByExponentBase;

            CurrentTime = _timeInterval.GetIntervalMiddle();
        }

        public TimeSpan CurrentTime { get; private set; }

        public void DecreaseTime()
        {
            var halfOfIntervalMs = _timeInterval.GetIntervalLengthInMiliseconds()/2.0;
            var newTimeInMiliseconds = Math.Max(CurrentTime.TotalMilliseconds - halfOfIntervalMs,
                _timeInterval.Minimum.TotalMilliseconds);

            CurrentTime = TimeSpan.FromMilliseconds(newTimeInMiliseconds);
            ResetIncreaseByValue();
        }

        private void ResetIncreaseByValue()
        {
            currentlyIncreasingBy = StartIncreasingByValue;
        }

        public void IncreaseTime()
        {
            double increaseByInMs = currentlyIncreasingBy;
            double newTimeValueInMs = Math.Min(CurrentTime.TotalMilliseconds + increaseByInMs,
                                               _timeInterval.Maximum.TotalMilliseconds);

            if (newTimeValueInMs < _timeInterval.Maximum.TotalMilliseconds)
                currentlyIncreasingBy *= _increaseByExponentBase;

            CurrentTime = TimeSpan.FromMilliseconds(newTimeValueInMs);
        }
    }
}