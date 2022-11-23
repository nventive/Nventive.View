#if WINDOWS_UWP || WINDOWS_WINUI

#if WINDOWS_UWP
using Windows.UI.Xaml;
#else
using Microsoft.UI.Xaml;
#endif

namespace Nventive.View.Controls
{
	public class SnapPoint
	{
		public bool IsSnapping { get; set; }
		public GridLength Position { get; set; }
	}
}
#endif
