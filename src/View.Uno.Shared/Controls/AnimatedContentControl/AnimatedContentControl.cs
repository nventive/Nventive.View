﻿#if __ANDROID__ || __IOS__ || __WASM__ || WINDOWS_WINUI
using System;
using System.Collections.Generic;
using System.Text;
#if WINUI
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

namespace Nventive.View.Controls
{
	public partial class AnimatedContentControl : ContentControl
	{
		private const string AnimationVisualStateGroup = "Animation";
		private const string AnimatingVisualState = "Animating";
		private const string NotAnimatingVisualState = "NotAnimating";

		private bool _isReady;

		public AnimatedContentControl()
		{
			DefaultStyleKey = typeof(AnimatedContentControl);
			Loaded += OnControlLoaded;
			Unloaded += OnControlUnloaded;
		}

#region IsAnimating DEPENDENCY PROPERTY

		/// <summary>
		/// Sets whether the control is in the animating state.
		/// </summary>
		public bool IsAnimating
		{
			get { return (bool)GetValue(IsAnimatingProperty); }
			set { SetValue(IsAnimatingProperty, value); }
		}

		public static readonly DependencyProperty IsAnimatingProperty =
			DependencyProperty.Register("IsAnimating", typeof(bool), typeof(AnimatedContentControl), new PropertyMetadata(false, OnIsAnimatingChanged));

		private static void OnIsAnimatingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			var self = obj as AnimatedContentControl;

			if (self != null)
			{
				self.GoToState((bool)args.NewValue);
			}
		}

#endregion

		/// <summary>
		/// Whether the animation should be disabled while the control is unloaded. 
		/// </summary>
		/// <remarks>By default this is set to true, since having animations running indefinitely while not visible is a performance drain. </remarks>
		public bool DisableOnUnload
		{
			get { return (bool)GetValue(DisableOnUnloadProperty); }
			set { SetValue(DisableOnUnloadProperty, value); }
		}

		public static readonly DependencyProperty DisableOnUnloadProperty =
			DependencyProperty.Register("DisableOnUnload", typeof(bool), typeof(AnimatedContentControl), new PropertyMetadata(true));

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_isReady = true;

			this.GoToState(IsAnimating);
		}

		private void OnControlLoaded(object sender, RoutedEventArgs e)
		{
			if (DisableOnUnload)
			{
				GoToState(IsAnimating);
			}
		}

		private void OnControlUnloaded(object sender, RoutedEventArgs e)
		{
			if (DisableOnUnload)
			{
				GoToState(isAnimating: false);
			}
		}

		private void GoToState(bool isAnimating)
		{
			if (_isReady)
			{
				VisualStateManager.GoToState(this, isAnimating ? AnimatingVisualState : NotAnimatingVisualState, true);
			}
		}
	}
}
#endif
