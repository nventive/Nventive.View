#if __ANDROID__ || __IOS__ || __MACOS__ || __WASM__ || __WINDOWS10_0_18362_0__
using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
#if WINUI
using Microsoft.UI.Dispatching;
#else
using Windows.UI.Core;
#endif
using ScheduleCore = Nventive.View;


namespace Nventive.View
{
	internal partial class MainDispatcherScheduler : IScheduler
	{
#if WINUI
		private readonly DispatcherQueue _dispatcher;
		private readonly DispatcherQueuePriority _priority;
#else
		private readonly CoreDispatcher _dispatcher;
		private readonly CoreDispatcherPriority _priority;
#endif
		public MainDispatcherScheduler(

#if WINUI
		DispatcherQueue dispatcher
#else
		CoreDispatcher dispatcher
#endif
			)
		{
			_dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
#if WINUI
			_priority = DispatcherQueuePriority.Normal;
#else
			_priority = CoreDispatcherPriority.Normal;
#endif
		}


		public MainDispatcherScheduler(
#if WINUI
			DispatcherQueue dispatcher,
			DispatcherQueuePriority priority
#else
			CoreDispatcher dispatcher,
			CoreDispatcherPriority priority
#endif
			)
		{
			_dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
			_priority = priority;
		}

		public DateTimeOffset Now => DateTimeOffset.Now;

		public IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
		{
			var subscription = new SerialDisposable();
			var d = new CancellationDisposable();

			_ = _dispatcher.RunAsync(
				_priority, () =>
				{
					if (!subscription.IsDisposed)
					{
						subscription.Disposable = action(this, state);
					}
#if WINUI
				});
#else
				})
				.AsTask(d.Token);
#endif

			return new CompositeDisposable(subscription, d);
		}
		private IDisposable ScheduleCore<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action)
		{
			if (dueTime <= TimeSpan.Zero)
			{
				return Schedule(state, action);
			}

			var disposable = new SerialDisposable();
			var timer = new System.Threading.Timer(t =>
			{
				if (!disposable.IsDisposed)
				{
					try
					{
						disposable.Disposable = action(this, state);
					}
					catch (Exception)
					{
						disposable.Dispose();
					}
				}
			});

			timer.Change((int)dueTime.TotalMilliseconds, System.Threading.Timeout.Infinite);

			return disposable;
		}

		public IDisposable Schedule<TState>(TState state, DateTimeOffset dueTime, Func<IScheduler, TState, IDisposable> action) =>
			ScheduleCore(state, dueTime - Now, action);

		public IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action) =>
			ScheduleCore(state, dueTime, action);
	}
}
#endif
