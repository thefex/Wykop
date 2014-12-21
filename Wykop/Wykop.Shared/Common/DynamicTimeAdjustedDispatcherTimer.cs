using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Wykop.Common
{
    public class DynamicTimeAdjustedDispatcherTimer : IDisposable
    {
        private bool isTickProcessing;
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly DynamicTimeAdjuster _dynamicTimeAdjuster;
        private readonly Func<Task> _onTick;

        public DynamicTimeAdjustedDispatcherTimer(TimeInterval tickInterval, Func<Task> onTick)
        {
            _dynamicTimeAdjuster = new DynamicTimeAdjuster(tickInterval);

            _onTick = onTick;
            _dispatcherTimer = new DispatcherTimer
            {
                Interval = _dynamicTimeAdjuster.CurrentTime
            };
            _dispatcherTimer.Tick += DispatcherTimerOnTick;
        }

        public void Dispose()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
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
            _dynamicTimeAdjuster.IncreaseTime();
            _dispatcherTimer.Interval = _dynamicTimeAdjuster.CurrentTime;
        }

        public void DecreaseTickLength()
        {
            _dynamicTimeAdjuster.DecreaseTime();
            _dispatcherTimer.Interval = _dynamicTimeAdjuster.CurrentTime;
        }
    }
}