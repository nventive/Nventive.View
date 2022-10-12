#if WINDOWS10_0_18362_0
// TODO: Implement a CoreDispatcherScheduler equivalence for Windows .NET 6 https://github.com/nventive/Nventive.View/issues/50
using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace Nventive.View
{
	internal partial class MainDispatcherScheduler : IScheduler
	{
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
	}
}
#endif
