using System;
using System.Diagnostics.Contracts;

namespace Wykop.Common
{
    public struct TimeInterval
    {
        private readonly TimeSpan _maximum;
        private readonly TimeSpan _minimum;

        public TimeInterval(int minimumMiliseconds, int maximumMiliseconds)
        {
            Contract.Assert(maximumMiliseconds >= minimumMiliseconds, "Maximum miliseconds should be bigger or equal to minimum.");

            _minimum = TimeSpan.FromMilliseconds(minimumMiliseconds);
            _maximum = TimeSpan.FromMilliseconds(maximumMiliseconds);
        }

        public TimeSpan Minimum
        {
            get { return _minimum; }
        }

        public TimeSpan Maximum
        {
            get { return _maximum; }
        }

        [Pure]
        public TimeSpan GetIntervalMiddle()
        {
            double middle = (Maximum.TotalMilliseconds - Minimum.TotalMilliseconds)/2.0;

            return TimeSpan.FromMilliseconds(middle+Minimum.TotalMilliseconds);
        }

        [Pure]
        public double GetIntervalLengthInMiliseconds()
        {
            return Maximum.TotalMilliseconds - Minimum.TotalMilliseconds;
        }
    }
}