using System;
using System.Globalization;
#if WINUI || __WASM__
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
using GenericCulture = System.String;
#elif __ANDROID__ || __IOS__
using GenericCulture = System.String;
using Microsoft.UI.Xaml.Data;
#else
using GenericCulture = System.Globalization.CultureInfo;
#endif

namespace Nventive.View.Converters
{
	public interface IAutoRefreshConverter : IValueConverter
	{
		TimeSpan GetNextUpdateInterval(object value, Type targetType, object parameter, GenericCulture culture);
	}
}
