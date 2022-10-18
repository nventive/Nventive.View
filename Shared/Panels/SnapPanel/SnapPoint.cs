#if WINDOWS_UWP || WINDOWS
using System;
using System.Collections.Generic;
using System.Text;
#if WINUI
using Microsoft.UI.Xaml;
#else
using Windows.UI.Xaml;
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
