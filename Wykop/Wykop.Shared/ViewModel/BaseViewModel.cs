using System;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PostSharp.Patterns.Model;
using Wykop.Common.Interfaces;
using Wykop.View;

namespace Wykop.ViewModel
{
    [NotifyPropertyChanged]
    public abstract class BaseViewModel : ViewModelBase, ILoadable, IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;
        private readonly ViewServices _viewServices;

        protected BaseViewModel(ViewServices viewServices)
        {
            _viewServices = viewServices;
            _cancellationTokenSource = new CancellationTokenSource();
            NavigateBackCommand = new RelayCommand(Navigation.GoBack);
        }

        protected CancellationToken CurrentCancellationToken
        {
            get { return _cancellationTokenSource.Token; }
        }

        public RelayCommand NavigateBackCommand { get; private set; }
        public bool IsOperationInProgress { get; set; }
        public bool IsOperationCancelling { get; set; }

        public INavigationService Navigation
        {
            get { return _viewServices.Navigation; }
        }

        public IDialogService Dialog
        {
            get { return _viewServices.Dialog; }
        }

        public virtual void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }

        public virtual Task Load()
        {
            return Task.FromResult(true);
        }

        public virtual Task Unload()
        {
            return Task.FromResult(true);
        }

        public async Task<bool> TryRunAsynchronousOperation(Func<Task> operationToExecute)
        {
            if (IsOperationInProgress)
                return false;
            IsOperationInProgress = true;

            try
            {
                await operationToExecute.Invoke();
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                RenewCancellationToken();
            }
            finally
            {
                IsOperationCancelling = false;
                IsOperationInProgress = false;
            }

            return true;
        }

        private void RenewCancellationToken()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public bool CancelPendingOperation()
        {
            if (IsOperationInProgress || IsOperationCancelling)
                return false;

            IsOperationCancelling = true;
            _cancellationTokenSource.Cancel();
            return true;
        }

        // postsharp limitation
        protected virtual void OnPropertyChanged(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }
}