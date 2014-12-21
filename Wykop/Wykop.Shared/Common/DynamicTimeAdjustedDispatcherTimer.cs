using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Wykop.Common
{
    public class DynamicTimeAdjustedDispatcherTimer : IDisposable
    {
        private readonly TimeInterval _tickInterval;
        private readonly Func<Task> _onTick;
        private readonly DispatcherTimer _dispatcherTimer;
        private bool isTickProcessing;

        public DynamicTimeAdjustedDispatcherTimer(TimeInterval tickInterval, Func<Task> onTick)
        {
            _tickInterval = tickInterval;
            _onTick = onTick;
            _dispatcherTimer = new DispatcherTimer()
            {
                Interval = _tickInterval.GetIntervalMiddle()
            };
            _dispatcherTimer.Tick += DispatcherTimerOnTick;
        }

        private async void DispatcherTimerOnTick(object sender, object o)
        {
            if (isTickProcessing)
                return;

            try
            {
                isTickProcessing = true;
                await _onTick.Invoke();
            }
            finally
            {
                isTickProcessing = false;
            }
        }

        public void Start()
        {
            _dispatcherTimer.Start();
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
        }

        public void IncreaseTickLength()
        {
            
        }

        public void DecreaseTickLength()
        {
            double decreaseBy = _tickInterval.GetIntervalLengthInMiliseconds()/2.0;
            double newTickLength = Math.Max(
                _tickInterval.Minimum.TotalMilliseconds,
                _dispatcherTimer.Interval.TotalMilliseconds - decreaseBy);

            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(newTickLength);
        }

        public void Dispose()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
        }
    }
}