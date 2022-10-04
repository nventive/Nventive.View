﻿#if WINDOWS_UWP || __ANDROID__ || __IOS__ || __WASM__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Nventive.View.Extensions
{
#if __IOS__
	[Foundation.PreserveAttribute(AllMembers = true)]
#elif __ANDROID__
	[Android.Runtime.PreserveAttribute(AllMembers = true)]
#endif
	public static class SplitViewExtensions
	{
		#region IsPaneEnabled

		public static DependencyProperty IsPaneEnabledProperty { get; } =
			DependencyProperty.RegisterAttached(
				"IsPaneEnabled",
				typeof(bool),
				typeof(SplitViewExtensions),
				new PropertyMetadata(true)
			);

		public static void SetIsPaneEnabled(this SplitView splitView, bool isPaneEnabled)
		{
			splitView.SetValue(IsPaneEnabledProperty, isPaneEnabled);
		}

		public static bool GetIsPaneEnabled(this SplitView splitView)
		{
			return (bool)splitView.GetValue(IsPaneEnabledProperty);
		}

		#endregion
	}
}
#endif
