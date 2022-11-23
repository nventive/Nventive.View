#if WINDOWS_UWP || WINDOWS_WINUI
using System;

namespace Nventive.View.Controls
{
	[Flags]
	public enum SnapAnchor
	{
		None = 0x0,
		Near = 0x1,
		Center = 0x2,
		Far = 0x4,
	}
}
#endif
