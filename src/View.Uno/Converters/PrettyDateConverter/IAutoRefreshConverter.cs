using System;
using System.Globalization;
#if WINUI
using Microsoft.UI.Xaml.Data;
using GenericCulture = System.String;
#elif WINDOWS_UWP || __WASM__
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using GenericCulture = System.String;
#elif __ANDROID__ || __IOS__
using GenericCulture = System.String;
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
using GenericCulture = System.Globalization.CultureInfo;
#endif

namespace Nventive.View.Converters
{
	public interface IAutoRefreshConverter : IValueConverter
	{
		TimeSpan GetNextUpdateInterval(object value, Type targetType, object parameter, GenericCulture culture);
	}
}
