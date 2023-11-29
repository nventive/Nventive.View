#if __ANDROID__ || __IOS__ || MACOS || __WASM__ || WINDOWS_WINUI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WINUI
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
#else
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
#endif

namespace Nventive.View.Controls
{
	public partial class PeekingFlipViewItem : SelectorItem
	{
		public PeekingFlipViewItem()
		{
			DefaultStyleKey = typeof(PeekingFlipViewItem);
		}
	}
}
#endif
