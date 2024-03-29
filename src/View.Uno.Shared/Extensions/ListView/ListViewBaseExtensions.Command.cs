﻿#if WINUI
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Uno.Extensions;
#if WINUI
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif
using System.Runtime.CompilerServices;
using Uno.Logging;

namespace Nventive.View.Extensions
{
	/// <summary>
	/// Contains attached properties that can be applied to a <see cref="ListViewBase"/> to work with commands.
	/// </summary>
	public partial class ListViewBaseExtensions
	{
		private static readonly ConditionalWeakTable<ListViewBase, ItemClickEventHandler> _registeredItemClickEventHandler = new ConditionalWeakTable<ListViewBase, ItemClickEventHandler>();

#region Attached Properties

		/// <summary>
		/// An ICommand that can be attached to a <see cref="ListViewBase"/> control.
		/// This allows the click of each item in the list to execute the specified ICommand.
		/// </summary>
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ListViewBaseExtensions), new PropertyMetadataHelper(new PropertyChangedCallback(OnCommandChanged)));

		/// <summary>
		/// Value which can be used to specify a parameter to use alongside Command when executing.
		/// </summary>
		public static readonly DependencyProperty CommandParameterProperty =
			DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(ListViewBaseExtensions), new PropertyMetadata(null));

		public static ICommand GetCommand(ListViewBase obj)
		{
			return (ICommand)obj.GetValue(CommandProperty);
		}

		public static void SetCommand(ListViewBase obj, ICommand value)
		{
			obj.SetValue(CommandProperty, value);
		}

		public static object GetCommandParameter(ListViewBase obj)
		{
			return obj.GetValue(CommandParameterProperty);
		}

		public static void SetCommandParameter(ListViewBase obj, object value)
		{
			obj.SetValue(CommandParameterProperty, value);
		}

#endregion

		private static void OnCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var listView = sender as ListViewBase;
			if (listView != null)
			{
				if (!listView.IsItemClickEnabled)
				{
					sender.Log().Warn("IsItemClickEnabled is not enabled on the associated list. This must be enabled to make this behavior work");
				}

				// Be sure to not have multiples handlers for the same listview command if command change.
				TryClearCurrentItemCommandEventHandler(listView);

				var hasCommand = e.NewValue as ICommand != null;
				if (hasCommand)
				{
					var eventHandler = new ItemClickEventHandler(ListViewItemClick);

					_registeredItemClickEventHandler.Add(listView, eventHandler);
					listView.ItemClick += eventHandler;
				}
			}
		}

		private static void TryClearCurrentItemCommandEventHandler(ListViewBase listView)
		{
			ItemClickEventHandler eventHandler;
			if (_registeredItemClickEventHandler.TryGetValue(listView, out eventHandler))
			{
				listView.ItemClick -= eventHandler;
				_registeredItemClickEventHandler.Remove(listView);
			}
		}

		private static void ListViewItemClick(object sender, ItemClickEventArgs e)
		{
			RunItemCommand((ListViewBase)sender, e);
		}

		private static void RunItemCommand(ListViewBase listView, ItemClickEventArgs e)
		{
			// Invoke the GetCommand in a static method will help avoid memory leak by not keeping a reference to command in the handler directly, but getting it on demand.
			var command = GetCommand(listView);
			var param = GetCommandParameter(listView) ?? e.ClickedItem;

			if (command.SelectOrDefault(cmd => cmd.CanExecute(param)))
			{
				command.Execute(param);
			}
		}
	}
}
#endif
