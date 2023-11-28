﻿#if __ANDROID__ || __IOS__ || __WASM__ || WINDOWS
using Uno.Extensions;
#if WINUI
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
#endif
using Uno.Logging;
using System.Reactive.Linq;
#if WINDOWS
using IFrameworkElement = Microsoft.UI.Xaml.FrameworkElement;
#elif __IOS__
using UIKit;
using Uno.UI.Controls;
#else
using Uno.UI;
using Uno.UI.Controls;
#endif

namespace Nventive.View.Extensions
{
	/// <summary>
	/// This behavior adds features to the SplitView.
	/// </summary>
	public class SplitViewBehavior
	{
#region OpenOnClick

		public static bool GetOpenOnClick(DependencyObject obj)
		{
			return (bool)obj.GetValue(OpenOnClickProperty);
		}

		public static void SetOpenOnClick(DependencyObject obj, bool value)
		{
			obj.SetValue(OpenOnClickProperty, value);
		}

		/// <summary>
		/// When True, opens the parent SplitView when clicked.
		/// The control attached with this property must satisfy the following.
		/// - It must be a child of the SplitView.
		/// - It must derive from ButtonBase or be an item of a ListViewBase.
		/// </summary>
		public static readonly DependencyProperty OpenOnClickProperty =
			DependencyProperty.RegisterAttached("OpenOnClick", typeof(bool), typeof(SplitViewBehavior), new PropertyMetadata(default(bool), OnOpenOnClickChanged));

		private static void OnOpenOnClickChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			RegisterToClick(dependencyObject);
		}

#endregion

#region CloseOnClick
		
		public static bool GetCloseOnClick(DependencyObject obj)
		{
			return (bool)obj.GetValue(CloseOnClickProperty);
		}

		public static void SetCloseOnClick(DependencyObject obj, bool value)
		{
			obj.SetValue(CloseOnClickProperty, value);
		}

		/// <summary>
		/// When True, closes the SplitView when clicked.
		/// The control attached with this property must satisfy the following.
		/// - It must be a child of the SplitView.
		/// - It must derive from ButtonBase or be an item of a ListViewBase.
		/// </summary>
		public static readonly DependencyProperty CloseOnClickProperty =
			DependencyProperty.RegisterAttached("CloseOnClick", typeof(bool), typeof(SplitViewBehavior), new PropertyMetadata(default(bool), OnCloseOnClickChanged));

		private static void OnCloseOnClickChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			RegisterToClick(dependencyObject);
		}

#endregion

		private static void RegisterToClick(DependencyObject dependencyObject)
		{
#region ButtonBase registration
			var button = dependencyObject as ButtonBase;
			if (button != null)
			{
				Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
					h => button.Click += h,
					h => button.Click -= h,
					new MainDispatcherScheduler(
#if WINUI
					button.DispatcherQueue
#else
					button.Dispatcher
#endif
					)
				)
				.SubscribeToElement(
					button,
					e => OnClicked(button),
					e => e.Log().Error("Error in subscription to Click", e)
				);

				return;
			}
#endregion

#region ListViewBase registration
			var listBase = dependencyObject as ListViewBase;

			if (listBase != null)
			{
				Observable.FromEventPattern<ItemClickEventHandler, ItemClickEventArgs>(
					h => listBase.ItemClick += h,
					h => listBase.ItemClick -= h,
					new MainDispatcherScheduler(
#if WINUI
					listBase.DispatcherQueue
#else
					listBase.Dispatcher
#endif
					)
				)
				.SubscribeToElement(
					listBase,
					e => OnClicked(listBase),
					e => e.Log().Error("Error in subscription to ItemClick", e)
				);

				return;
			}
#endregion
		}

		private static void OnClicked(FrameworkElement element)
		{
#region SplitView
			var splitView = element.FindFirstParent<SplitView>();
			if (splitView != null)
			{
				if (splitView.IsPaneOpen && GetCloseOnClick(element))
				{
					splitView.IsPaneOpen = false;
				}
				else if (!splitView.IsPaneOpen && GetOpenOnClick(element))
				{
					splitView.IsPaneOpen = true;
				}

				return;
			}
#endregion

#region BindableDrawerLayout
#if __ANDROID__
			//This handles if projects still use BindableDrawerLayout for android.
			var bindableDrawer = element.FindFirstParent<BindableDrawerLayout>();

			if (bindableDrawer != null)
			{
				if (bindableDrawer.IsLeftPaneOpen && GetCloseOnClick(element))
				{
					bindableDrawer.IsLeftPaneOpen = false;
				}
				else if (!bindableDrawer.IsLeftPaneOpen && GetOpenOnClick(element))
				{
					bindableDrawer.IsLeftPaneOpen = true;
				}

				return;
			}
#endif
#endregion
		}
	}
}
#endif
