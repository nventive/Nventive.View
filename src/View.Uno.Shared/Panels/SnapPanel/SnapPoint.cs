#if WINDOWS_WINUI

using Microsoft.UI.Xaml;

namespace Nventive.View.Controls
{
	public class SnapPoint
	{
		public bool IsSnapping { get; set; }
		public GridLength Position { get; set; }
	}
}
#endif
