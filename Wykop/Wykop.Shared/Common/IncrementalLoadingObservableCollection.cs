using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wykop.Common
{
    internal class IncrementalLoadingObservableCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private readonly Func<int, CancellationToken, Task<IEnumerable<T>>> _provideMoreItemsTask;
        private readonly SemaphoreSlim _semaphoreSlimPageSynchronizer;

        public IncrementalLoadingObservableCollection(Func<int, CancellationToken, Task<IEnumerable<T>>> provideMoreItemsTask)
        {
            _provideMoreItemsTask = provideMoreItemsTask;
            _semaphoreSlimPageSynchronizer = new SemaphoreSlim(1);
            CurrentPage = 0;
        }

        public int CurrentPage { get; private set; }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run(async cancelToken =>
            {
                int requestedPage;
                await _semaphoreSlimPageSynchronizer.WaitAsync(cancelToken);
                CurrentPage++;
                requestedPage = CurrentPage;
                _semaphoreSlimPageSynchronizer.Release();

                var providedItems = await _provideMoreItemsTask.Invoke(requestedPage, cancelToken);

                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (var item in providedItems)
                        Add(item);
                });

                return new LoadMoreItemsResult {Count = (uint) providedItems.Count()};
            });
        }

        public bool HasMoreItems
        {
            get { return true; }
        }
    }
}