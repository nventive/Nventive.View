#if WINDOWS_UWP || __ANDROID__ || __IOS__ || __WASM__
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
#if WINUI
using Microsoft.UI.Xaml.Input;
#else
using Windows.UI.Xaml.Input;
#endif

namespace Nventive.View.Converters
{
	public class FromInputScopeNameValueToInputScopeConverter : ConverterBase
	{
		protected override object Convert(object value, Type targetType, object parameter)
		{
			var inputScope = value as InputScopeNameValue?;
			if (inputScope == null)
			{
				inputScope = InputScopeNameValue.Default;
			}
			if (inputScope.HasValue)
			{
#if WINUI
				return new Microsoft.UI.Xaml.Input.InputScope()
#else
				return new Windows.UI.Xaml.Input.InputScope()
#endif
				{
					Names = { new InputScopeName(inputScope.Value) }
				};
			}

			return null;
		}
	}
}
#endif
